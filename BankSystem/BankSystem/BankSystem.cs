using System;

namespace BankSystem
{
    class BankSystem
    {
        static void Main(string[] args)
        {
            Account account1 = new Account("Om", 1000);
            Account account2 = new Account("Jotham Barazani", 50032);
            // display account details
            Console.WriteLine("Account Details:");
            Console.WriteLine(account1);
            Console.WriteLine(account2);
            Console.WriteLine("-----------------------------");

            while (true)
            {
                // displaying menu and prompt for user input
                Console.WriteLine("Enter choice: 1) Withdraw 2) Deposit 3) Transfer 4) Print 5) Exit");

                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("-----------------------------");

                    switch (choice)
                    {
                        // handle withdraw transaction
                        case 1:
                            Console.WriteLine("Enter amount to withdraw:");
                            decimal amount1 = Convert.ToDecimal(Console.ReadLine());
                            WithdrawTransaction withdrawTransaction1 = new WithdrawTransaction(account1, amount1);
                            withdrawTransaction1.Execute();
                            Console.WriteLine("-----------------------------");
                            break;
                        // handle deposit transaction
                        case 2:
                            Console.WriteLine("Enter amount to deposit:");
                            decimal amount2 = Convert.ToDecimal(Console.ReadLine());
                            DepositTransaction depositTransaction1 = new DepositTransaction(account1, amount2);
                            depositTransaction1.Execute();
                            Console.WriteLine("-----------------------------");
                            break;
                        // handle transfer transaction
                        case 3:
                            Console.WriteLine("Enter amount to transfer:");
                            decimal amount3 = Convert.ToDecimal(Console.ReadLine());
                            Console.WriteLine("Enter account to tran sfer from:");
                            int fromAccountNumber = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter account to transfer to:");
                            int toAccountNumber = Convert.ToInt32(Console.ReadLine());
                            Account fromAccount = null;
                            Account toAccount = null;
                            if (fromAccountNumber == 1 && toAccountNumber == 2)
                            {
                                fromAccount = account1;
                                toAccount = account2;
                            }
                            else if (fromAccountNumber == 2 && toAccountNumber == 1)
                            {
                                fromAccount = account2;
                                toAccount = account1;
                            }
                            else
                            {
                                Console.WriteLine("Invalid account numbers");
                                Console.WriteLine("-----------------------------");
                                break;
                            }
                            TransferTransaction transferTransaction = new TransferTransaction(fromAccount, toAccount, amount3);
                            transferTransaction.Execute();
                            Console.WriteLine("-----------------------------");
                            break;
                        // handle printing account details
                        case 4:
                            Console.WriteLine("Account Details:");
                            Console.WriteLine(account1);
                            Console.WriteLine(account2);
                            Console.WriteLine("-----------------------------");
                            break;
                        // handle exiting the program
                        case 5:
                            Console.WriteLine("Exiting...");
                            Environment.Exit(0);
                            break;
                        // handle invalid choice
                        default:
                            Console.WriteLine("Invalid choice");
                            Console.WriteLine("-----------------------------");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    Console.WriteLine("-----------------------------");
                }
            }
        }
    }
}
