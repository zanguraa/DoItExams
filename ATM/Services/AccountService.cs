
using ATM.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ATM.Services
{
    public class AccountService : IAccountService
    {
        private readonly List<BankAccount> accounts = new List<BankAccount>();
        private readonly ILogger logger;

        public AccountService(ILogger logger)
        {
            this.logger = logger;
        }

        public BankAccount CreateAccount(User user, string pinCode)
        {
            var newAccount = new BankAccount(user, pinCode);
            accounts.Add(newAccount);
            return newAccount;
        }

        public void ChangePinCode(User user, string newPinCode)
        {
            var account = accounts.FirstOrDefault(acc => acc.User == user);
            if (account != null)
            {
                account.ChangePinCode(newPinCode);
                // Log pin change activity
                logger.LogTransaction(new Transaction(account.AccountId, 0, "PIN change"));
            }
        }

        public decimal CheckBalance(User user)
        {
            var account = accounts.FirstOrDefault(acc => acc.User == user);
            if (account != null)
            {
                // Log balance check activity
                logger.LogTransaction(new Transaction(account.AccountId, 0, "Balance check"));
                return account.Balance;
            }
            throw new InvalidOperationException("Account not found.");
        }

        public void Deposit(User user, decimal amount)
        {
            var account = accounts.FirstOrDefault(acc => acc.User == user);
            if (account != null)
            {
                account.Deposit(amount);
                logger.LogTransaction(new Transaction(account.AccountId, amount, "Deposit"));
            }
        }

        public bool Withdraw(User user, decimal amount)
        {
            var account = accounts.FirstOrDefault(acc => acc.User == user);
            if (account != null && account.Withdraw(amount))
            {
                logger.LogTransaction(new Transaction(account.AccountId, amount, "Withdrawal"));
                return true;
            }
            return false;
        }

        public List<Transaction> GetTransactionHistory(User user)
        {
            var account = accounts.FirstOrDefault(acc => acc.User == user);
            if (account != null)
            {
                // Here you need to filter the transactions related to the user's account
                return logger.GetTransactions().Where(t => t.AccountId == account.AccountId).ToList();
            }
            return new List<Transaction>();
        }

        public async Task<BankAccount> GetAccountByUserId(Guid userId)
        {
            // Simulate async operation
            await Task.Delay(1); // Remove this line in a real database call scenario
            return accounts.FirstOrDefault(acc => acc.User.UserId == userId);
        }

        public async Task DepositMoneyAsync(Guid accountId, decimal amount)
        {
            var account = accounts.FirstOrDefault(a => a.AccountId == accountId);
            if (account == null)
            {
                throw new ArgumentException("Account not found.");
            }

            // Simulate an asynchronous operation, e.g., database access
            await Task.Run(() =>
            {
                account.Deposit(amount);
               
            });

            // Optionally, you can implement transaction logging here
            // Example: logger.LogTransaction(new Transaction(accountId, amount, "Deposit"));

            // Log deposit activity
            logger.LogTransaction(new Transaction(accountId, amount, "Deposit"));

            
        }
    }
}
