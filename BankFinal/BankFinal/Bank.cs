using System;
using System.Collections.Generic;

namespace BankingSystem
{
    class Bank
    {
        private List<Account> _accounts;
        private List<Transaction> _transactions;

        public Bank()
        {
            _accounts = new List<Account>();
            _transactions = new List<Transaction>();
        }

        public void AddAccount(Account account)
        {
            _accounts.Add(account);
        }

        public void ExecuteTransaction(Transaction transaction)
        {
            transaction.Execute();
            _transactions.Add(transaction);
        }

        public void RollbackTransaction(Transaction transaction)
        {
            transaction.Rollback();
            _transactions.Remove(transaction);
        }

        public void PrintTransactionHistory()
        {
            Console.WriteLine("Transaction History:\n");

            for (int i = 0; i < _transactions.Count; i++)
            {
                Console.WriteLine($"Transaction #{i + 1}\n");
                _transactions[i].Print();
            }
        }

        public Account GetAccountById(int accountId)
        {
            foreach (Account account in _accounts)
            {
                if (account.Id == accountId)
                {
                    return account;
                }
            }
            return null;
        }
    }
}
