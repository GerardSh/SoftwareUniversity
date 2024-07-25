using Chainblock.Contracts;
using System;
using System.Collections;
using System.Threading.Tasks.Dataflow;

namespace Chainblock
{
    public class Chainblock : IChainblock
    {
        readonly Dictionary<int, ITransaction> transactions;

        public Chainblock()
        {
            this.transactions = new Dictionary<int, ITransaction>();
        }

        public int Count => transactions.Count;

        public void Add(ITransaction tx)
        {
            if (!transactions.ContainsKey(tx.Id))
            {
                transactions.Add(tx.Id, tx);
            }
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            if (!transactions.ContainsKey(id))
            {
                throw new ArgumentException();
            }

            transactions[id].Status = newStatus;
        }

        public bool Contains(ITransaction tx)
        {
            foreach (var kvp in transactions)
            {
                if (kvp.Value.Equals(tx))
                {
                    return true;
                }
            }

            return false;
        }

        public bool Contains(int id) => transactions.ContainsKey(id);


        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            throw new NotImplementedException();
        }

        public ITransaction GetById(int id)
        {
            if (transactions.ContainsKey(id))
            {
                return transactions[id];
            }

            throw new InvalidOperationException();
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            IEnumerable<ITransaction> sortedAndFilteredTransactions = transactions
                 .Values
                 .Where(x => x.Status == status)
                 .OrderByDescending(x => x.Amount);

            return sortedAndFilteredTransactions;
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            foreach (var transaction in transactions)
            {
                yield return transaction.Value;
            }
        }

        public void RemoveTransactionById(int id)
        {
            if (!transactions.ContainsKey(id))
            {
                throw new InvalidOperationException();
            }

            transactions.Remove(id);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
