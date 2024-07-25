using Chainblock.Contracts;
using System.Security.Cryptography.X509Certificates;

namespace Chainblock.Tests
{
    public class ChainblockTests
    {
        IChainblock chainblock;
        ITransaction transaction;

        [SetUp]
        public void SetUp()
        {
            chainblock = new Chainblock();
            transaction = new Transaction();
        }

        [Test]
        public void AddMethodShouldAddUniqueRecords()
        {
            chainblock.Add(transaction);

            bool exist = chainblock.Contains(transaction);

            Assert.IsTrue(exist);
            Assert.That(chainblock.Count, Is.EqualTo(1));
        }

        [Test]
        public void ChangeTransactionMethodStatusShouldChangeTheStatusOfTheProvidedTransaction()
        {
            transaction.Status = TransactionStatus.Unauthorized;

            chainblock.Add(transaction);

            chainblock.ChangeTransactionStatus(0, TransactionStatus.Successfull);

            var transactionById = chainblock.GetById(0);

            Assert.That(TransactionStatus.Successfull, Is.EqualTo(transactionById.Status));
        }

        [Test]
        public void ChangeTransactionMethodStatusShouldThrowExceptionIfTransactionWithGivenIdIsNotFound() =>
            Assert.That(() => chainblock.ChangeTransactionStatus(0, TransactionStatus.Successfull), Throws.ArgumentException);

        [Test]
        public void RemoveTransactionByIdMethodShouldRemoveTheTransactionWithTheGivenId()
        {
            chainblock.Add(transaction);

            Assert.That(chainblock.Count, Is.EqualTo(1));

            chainblock.RemoveTransactionById(0);

            Assert.That(chainblock.Count, Is.EqualTo(0));
        }

        [Test]
        public void RemoveTransactionByIdMethodShouldThrowExceptionWhenTransactionWithTheGivenIdDoesNotExist() =>
            Assert.Throws<InvalidOperationException>(() => chainblock.RemoveTransactionById(0));

        [Test]
        public void GetByIdMethodShouldReturnTheTransactionWithTheGivenId()
        {
            chainblock.Add(transaction);
            chainblock.Add(new Transaction { Id = 1 });

            var returnedTransaction = chainblock.GetById(0);

            Assert.That(returnedTransaction, Is.EqualTo(transaction));
        }

        [Test]
        public void GetByIdMethodShouldThrowExceptionIfNoTransactionWithProvidedIdIsFound() =>
            Assert.That(() => chainblock.GetById(0), Throws.InvalidOperationException);

        [Test]
        public void GetByTransactionStatusMethodShouldReturnTheTransactionsWithTheStatusOrderedByAmountDescending()
        {
            transaction.Amount = 1;
            transaction.Status = TransactionStatus.Successfull;

            ITransaction secondTransaction = new Transaction()
            {
                Id = 2,
                Amount = 2,
                Status = TransactionStatus.Successfull,
            };

            ITransaction thirdTransaction = new Transaction()
            {
                Id = 3,
                Amount = 3,
                Status = TransactionStatus.Successfull,
            };

            ITransaction fourthTransaction = new Transaction()
            {
                Id = 4,
                Amount = 4,
                Status = TransactionStatus.Unauthorized,
            };

            chainblock.Add(transaction);
            chainblock.Add(secondTransaction);
            chainblock.Add(thirdTransaction);
            chainblock.Add(fourthTransaction);

            List<ITransaction> transactionsToCompare = new List<ITransaction>();

            transactionsToCompare.Add(transaction);
            transactionsToCompare.Add(secondTransaction);
            transactionsToCompare.Add(thirdTransaction);

            transactionsToCompare = transactionsToCompare.OrderByDescending(x => x.Amount).ToList();

            CollectionAssert.AreEqual(transactionsToCompare, chainblock.GetByTransactionStatus(TransactionStatus.Successfull).ToList());
        }

        [Test]
        public void GetEnumeratorMethodShouldReturnTheTransactionsValues()
        {
            chainblock.Add(transaction);
            chainblock.Add(new Transaction() { Id = 1 });
            chainblock.Add(new Transaction() { Id = 2 });
            chainblock.Add(new Transaction() { Id = 3 });

            int id = 0;

            foreach (var transaction in chainblock)
            {
                Assert.That(transaction.Id, Is.EqualTo(id++));
            }
        }
    }
}
