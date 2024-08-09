using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models
{
    public class Adult : Client
    {
        const int InitialInterest = 4;

        public Adult(string name, string id, double income)
            : base(name, id, InitialInterest, income)
        {
        }

        public override void IncreaseInterest() => Interest += 2;
    }
}
