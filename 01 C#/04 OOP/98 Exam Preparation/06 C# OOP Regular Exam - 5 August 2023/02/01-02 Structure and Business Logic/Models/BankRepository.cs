using BankLoan.Models.Contracts;
using BankLoan.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models
{
    public class BankRepository : IRepository<IBank>
    {
        List<IBank> loans;

        public BankRepository()
        {
            loans = new List<IBank>();
        }

        public IReadOnlyCollection<IBank> Models => loans;

        public void AddModel(IBank model) => loans.Add(model);

        public IBank FirstModel(string name) => loans.FirstOrDefault(x => x.Name == name);

        public bool RemoveModel(IBank model) => loans.Remove(model);
    }
}
