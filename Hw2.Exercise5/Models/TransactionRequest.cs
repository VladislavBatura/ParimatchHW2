using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw2.Exercise5.Models
{
    internal class TransactionRequest : ITransactionRequest
    {
        public string TransactionId { get; }

        public decimal Amount { get; }

        public string Currency { get; }

        public string SourceUserId { get; }

        public string DestUserId { get; }

        public string SourceBalance { get; }

        public string DestBalance { get; }

        public bool OverdraftAllowed { get; }

        public DateTimeOffset Timestamp { get; }

        public string Metadata { get; }

        // Исправить форматирование. Оставить 1 аргумент на 1 строке или 1 логичекая группа на строке (хуже, но допустимо)
        public TransactionRequest(string transactionId, decimal amount,
            string currency, string sourceUserId, string destUserId,
            string sourceBalance, string destBalance, bool overdraftAllowed,
            DateTimeOffset timestamp, string metadata)
        {
            TransactionId = transactionId;
            Amount = amount;
            Currency = currency;
            SourceUserId = sourceUserId;
            DestUserId = destUserId;
            SourceBalance = sourceBalance;
            DestBalance = destBalance;
            OverdraftAllowed = overdraftAllowed;
            Timestamp = timestamp;
            Metadata = metadata;
        }
    }
}
