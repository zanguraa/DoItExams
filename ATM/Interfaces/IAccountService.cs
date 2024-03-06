using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Interfaces
{
    public interface IAccountService
    {
        BankAccount CreateAccount(User user, string pinCode);
        void ChangePinCode(User user, string newPinCode);
        decimal CheckBalance(User user);
        void Deposit(User user, decimal amount);
        bool Withdraw(User user, decimal amount);
        List<Transaction> GetTransactionHistory(User user);
        Task<BankAccount> GetAccountByUserId(Guid userId);
        Task DepositMoneyAsync(Guid accountId, decimal amount);

    }
}
