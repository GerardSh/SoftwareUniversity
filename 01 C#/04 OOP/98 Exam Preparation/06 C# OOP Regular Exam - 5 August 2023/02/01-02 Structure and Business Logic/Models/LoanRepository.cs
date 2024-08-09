using BankLoan.Models.Contracts;
using BankLoan.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models
{
    public class LoanRepository : IRepository<ILoan>
    {
        List<ILoan> loans;

        public LoanRepository()
        {
            loans = new List<ILoan>();
        }

        public IReadOnlyCollection<ILoan> Models => loans;

        public void AddModel(ILoan model) => loans.Add(model);

        public ILoan FirstModel(string name) => loans.FirstOrDefault(x => x.GetType().Name == name);

        public bool RemoveModel(ILoan model) => loans.Remove(model);
    }
}
