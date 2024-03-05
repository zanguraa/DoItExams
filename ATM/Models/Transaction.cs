public class Transaction
{
    public DateTime Timestamp { get; private set; }
    public Guid AccountId { get; private set; }
    public decimal Amount { get; private set; }
    public string TransactionType { get; private set; } // Types: Deposit, Withdrawal, BalanceCheck

    public Transaction(Guid accountId, decimal amount, string transactionType)
    {
        Timestamp = DateTime.UtcNow;
        AccountId = accountId;
        Amount = amount;
        TransactionType = transactionType;
    }
}
