using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models
{
    public class MortgageLoan : Loan
    {
        const int InitialInterestRate = 3;
        const double InitialAmount = 50000;

        public MortgageLoan()
            : base(InitialInterestRate, InitialAmount)
        {
        }
    }
}
