using BankLoan.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models
{
    public class StudentLoan : Loan
    {
        const int InitialInterestRate = 1;
        const double InitialAmount = 10000;

        public StudentLoan() 
            : base(InitialInterestRate, InitialAmount)
        {
        }
    }
}
