public class BankAccount
{
    public Guid AccountId { get; private set; }
    public User User { get; private set; }
    public decimal Balance { get; private set; }
    private string PinCode { get; set; }

    public BankAccount(User user, string pinCode)
    {
        AccountId = Guid.NewGuid();
        User = user;
        Balance = 0;
        PinCode = pinCode;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Deposit amount must be positive.", nameof(amount));
        }

        Balance += amount;
    }

    public bool Withdraw(decimal amount)
    {
        if (Balance >= amount)
        {
            Balance -= amount;
            return true;
        }
        return false;
    }

    public bool VerifyPinCode(string pinCode)
    {
        return PinCode == pinCode;
    }

    public void ChangePinCode(string newPinCode)
    {
        PinCode = newPinCode;
    }
}
