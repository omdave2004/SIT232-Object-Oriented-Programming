using System;
using System.Collections.Generic;

namespace BankingSystem
{
    class BankSystem
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            int choice;
            do
            {
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Transfer");
                Console.WriteLine("4. Print transaction history");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter account number: ");
                        int accountNumber = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter amount to deposit: ");
                        decimal amount = Convert.ToDecimal(Console.ReadLine());
                        DepositTransaction depositTransaction = new DepositTransaction(amount, accountNumber);
                        bank.ExecuteTransaction(depositTransaction);
                        break;
                    case 2:
                        Console.Write("Enter account number: ");
                        accountNumber = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter amount to withdraw: ");
                        amount = Convert.ToDecimal(Console.ReadLine());
                        WithdrawTransaction withdrawTransaction = new WithdrawTransaction(amount, accountNumber);
                        bank.ExecuteTransaction(withdrawTransaction);
                        break;
                    case 3:
                        Console.Write("Enter account number to transfer from: ");
                        int fromAccount = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter account number to transfer to: ");
                        int toAccount = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter amount to transfer: ");
                        amount = Convert.ToDecimal(Console.ReadLine());
                        TransferTransaction transferTransaction = new TransferTransaction(amount, fromAccount, toAccount);
                        bank.ExecuteTransaction(transferTransaction);
                        break;
                    case 4:
                        bank.PrintTransactionHistory();
                        bank.DoRollback();
                        break;
                    case 5:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
                Console.WriteLine();
            } while (choice != 5);
        }
    }
}
