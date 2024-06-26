namespace ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            string[] bankAccountsData = Console.ReadLine().Split(",");
            var bankAccounts = new Dictionary<int, double>();

            foreach (string bankAccount in bankAccountsData)
            {
                string[] currentBankAccountData = bankAccount.Split("-");

                bankAccounts[int.Parse(currentBankAccountData[0])] = double.Parse(currentBankAccountData[1]);
            }

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] elements = input.Split();

                string command = elements[0];
                int bankAccount = int.Parse(elements[1]);
                double sum = double.Parse(elements[2]);

                try
                {
                    if (command == "Deposit")
                    {
                        ValidateAccount(bankAccounts, bankAccount);

                        bankAccounts[bankAccount] += sum;
                    }
                    else if (command == "Withdraw")
                    {
                        ValidateBalance(bankAccounts, bankAccount, sum);

                        bankAccounts[bankAccount] -= sum;
                    }
                    else
                    {
                        throw new ArgumentException("Invalid command!");
                    }

                    Console.WriteLine($"Account {bankAccount} has new balance: {bankAccounts[bankAccount]:f2}");

                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }
            }
        }

        private static void ValidateBalance(Dictionary<int, double> bankAccounts, int bankAccount, double sum)
        {
            if (bankAccounts[bankAccount] < sum)
            {
                throw new ArgumentException("Insufficient balance!");
            }
        }

        private static void ValidateAccount(Dictionary<int, double> bankAccounts, int bankAccount)
        {
            if (!bankAccounts.ContainsKey(bankAccount))
            {
                throw new ArgumentException("Invalid account!");
            }
        }
    }
}