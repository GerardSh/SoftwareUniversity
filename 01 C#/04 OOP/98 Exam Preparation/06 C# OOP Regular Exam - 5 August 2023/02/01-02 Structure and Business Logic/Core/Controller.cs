using BankLoan.Core.Contracts;
using BankLoan.Models;
using BankLoan.Models.Contracts;
using BankLoan.Repositories.Contracts;
using BankLoan.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace BankLoan.Core
{
    public class Controller : IController
    {
        IRepository<ILoan> loans;
        IRepository<IBank> banks;

        public Controller()
        {
            loans = new LoanRepository();
            banks = new BankRepository();
        }

        public string AddBank(string bankTypeName, string name)
        {
            IBank bank = null;

            if (bankTypeName == nameof(BranchBank))
            {
                bank = new BranchBank(name);
            }
            else if (bankTypeName == nameof(CentralBank))
            {
                bank = new CentralBank(name);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.BankTypeInvalid);
            }

            banks.AddModel(bank);

            return string.Format(OutputMessages.BankSuccessfullyAdded, bankTypeName);
        }

        public string AddClient(string bankName, string clientTypeName, string clientName, string id, double income)
        {
            IClient client = null;

            if (clientTypeName == nameof(Student))
            {
                client = new Student(clientName, id, income);
            }
            else if (clientTypeName == nameof(Adult))
            {
                client = new Adult(clientName, id, income);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.ClientTypeInvalid);
            }

            IBank bank = banks.FirstModel(bankName);

            string bankTypeName = bank.GetType().Name;

            //Adult This class will be only accepted in combination with CentralBank.
            //Student This class will be only accepted in combination with BranchBank.
            if (clientTypeName == nameof(Adult) && bankTypeName == nameof(BranchBank)
                || clientTypeName == nameof(Student) && bankTypeName == nameof(CentralBank))
            {
                return string.Format(OutputMessages.UnsuitableBank);
            }

            bank.AddClient(client);

            return string.Format(OutputMessages.ClientAddedSuccessfully, clientTypeName, bankName);
        }

        public string AddLoan(string loanTypeName)
        {
            ILoan loan = null;

            if (loanTypeName == nameof(StudentLoan))
            {
                loan = new StudentLoan();
            }
            else if (loanTypeName == nameof(MortgageLoan))
            {
                loan = new MortgageLoan();
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.LoanTypeInvalid);
            }

            loans.AddModel(loan);

            return string.Format(OutputMessages.LoanSuccessfullyAdded, loanTypeName);
        }

        public string FinalCalculation(string bankName)
        {
            IBank bank = banks.FirstModel(bankName);

            double funds = bank.Loans.Sum(x => x.Amount) + bank.Clients.Sum(x => x.Income);

            return $"The funds of bank {bankName} are {funds:f2}.";
        }

        public string ReturnLoan(string bankName, string loanTypeName)
        {
            IBank bank = banks.FirstModel(bankName);
            ILoan loan = loans.FirstModel(loanTypeName);

            if (loan == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.MissingLoanFromType, loanTypeName));
            }

            bank.AddLoan(loan);
            loans.RemoveModel(loan);

            return string.Format(OutputMessages.LoanReturnedSuccessfully, loanTypeName, bankName);
        }

        public string Statistics()
        {
            var sb = new StringBuilder();

            foreach (var bank in banks.Models)
            {
                sb.AppendLine(bank.GetStatistics());
            }

            return sb.ToString().Trim();
        }
    }
}