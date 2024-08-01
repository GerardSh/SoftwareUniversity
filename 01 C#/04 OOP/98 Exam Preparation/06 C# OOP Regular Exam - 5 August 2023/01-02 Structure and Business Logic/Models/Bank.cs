using BankLoan.Models.Contracts;
using BankLoan.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models
{
    public abstract class Bank : IBank
    {
        private string name;
        private List<ILoan> loans;
        private List<IClient> clients;

        protected Bank(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;

            loans = new List<ILoan>();
            clients = new List<IClient>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.BankNameNullOrWhiteSpace);
                }

                name = value;
            }
        }

        public int Capacity { get; private set; }

        public IReadOnlyCollection<ILoan> Loans => loans;

        public IReadOnlyCollection<IClient> Clients => clients;

        public void AddClient(IClient Client)
        {
            if (clients.Count < Capacity)
            {
                clients.Add(Client);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.NotEnoughCapacity);
            }
        }

        public void AddLoan(ILoan loan) => loans.Add(loan);

        public string GetStatistics()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Name: {Name}, Type: {GetType().Name}");
            sb.AppendLine($"Clients: {(clients.Count > 0 ? string.Join(", ", clients.Select(x=>x.Name)) : "none")}");
            sb.Append($"Loans: {loans.Count}, Sum of Rates: {SumRates()}");

            return sb.ToString();
        }

        public void RemoveClient(IClient Client) => clients.Remove(Client);

        public double SumRates() => loans.Sum(x => x.InterestRate);
    }
}
