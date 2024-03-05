public interface IUserService
{
    User RegisterUser(string username);
}

public interface IAccountService
{
    BankAccount CreateAccount(User user, string pinCode);
    void ChangePinCode(User user, string newPinCode);
    decimal CheckBalance(User user);
    void Deposit(User user, decimal amount);
    bool Withdraw(User user, decimal amount);
    List<Transaction> GetTransactionHistory(User user);
}

public interface ILogger
{
    void LogTransaction(Transaction transaction);
    List<Transaction> GetTransactions();
}
