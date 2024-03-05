using System.Text.Json;
using System.Collections.Generic;
using System.IO;
using ATM.Interfaces;

namespace ATM.Logging
{
    public class JsonFileLogger : ILogger
    {
        private const string FilePath = "transactions.log";

        public void LogTransaction(Transaction transaction)
        {
            var transactions = GetTransactions();
            transactions.Add(transaction);
            var json = JsonSerializer.Serialize(transactions, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }

        public List<Transaction> GetTransactions()
        {
            if (!File.Exists(FilePath)) return new List<Transaction>();
            var json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<Transaction>>(json) ?? new List<Transaction>();
        }
    }
}
