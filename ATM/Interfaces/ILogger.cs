using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Interfaces
{
    public interface ILogger
    {
        void LogTransaction(Transaction transaction);
        List<Transaction> GetTransactions();
    }

}
