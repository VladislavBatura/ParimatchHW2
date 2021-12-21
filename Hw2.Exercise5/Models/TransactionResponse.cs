using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw2.Exercise5.Models
{
    internal class TransactionResponse : ITransactionResponse
    {
        public TransactionResult Result { get; }

        public string Currency { get; }

        public IDictionary<string, decimal> SourceBalances { get; }

        public IDictionary<string, decimal> DestBalances { get; }

        public TransactionResponse(TransactionResult result, string currency,
            IDictionary<string, decimal> sourceBalances, IDictionary<string, decimal> destBalances)
        {
            Result = result;
            Currency = currency;
            SourceBalances = sourceBalances;
            DestBalances = destBalances;
        }
    }
}
