using Hw2.Exercise5.Models;
using System.Linq;

namespace Hw2.Exercise5.Services
{
    /// <summary>
    /// Billing system core.
    /// </summary>
    public class BillingService : IBillingService
    {

        private static Dictionary<string, Dictionary<string, Dictionary<string, decimal>>> usersData = null!;

        /// <inheritdoc/>
        public ITransactionResponse ProcessTransaction(ITransactionRequest request)
        {
            if(usersData is null)
            {
                usersData = new Dictionary<string, Dictionary<string, Dictionary<string, decimal>>>();
            }

            if(request is null)
            {
                return ReturnInvalidResponse();
            }

            if (!ReturnInvalidResponseNull(request))
            {
                return ReturnInvalidResponse();
            }


            if (!usersData.ContainsKey(request.SourceUserId))
            {
                CreateUser(request.SourceUserId, request.Currency, request.SourceBalance);
            }
            else if (!usersData[request.SourceUserId]
                .ContainsKey(request.Currency))
            {
                CreateCurrency(request.SourceUserId, request.Currency, request.SourceBalance);
            }
            else if(!usersData[request.SourceUserId][request.Currency]
                .ContainsKey(request.SourceBalance))
            {
                CreateBalance(request.SourceUserId, request.Currency, request.SourceBalance);
            }

            if (!usersData.ContainsKey(request.DestUserId))
            {
                CreateUser(request.DestUserId, request.Currency, request.DestBalance);
            }
            else if (!usersData[request.DestUserId]
                .ContainsKey(request.Currency))
            {
                CreateCurrency(request.DestUserId, request.Currency, request.DestBalance);
            }
            else if (!usersData[request.DestUserId][request.Currency]
                .ContainsKey(request.DestBalance))
            {
                CreateBalance(request.DestUserId, request.Currency, request.DestBalance);
            }

            if (request.SourceBalance.Equals(request.DestBalance)
                && request.SourceUserId.Equals(request.DestUserId))
            {
                return ReturnInvalidResponse(request.Currency,
                    usersData[request.SourceUserId][request.Currency],
                    usersData[request.SourceUserId][request.Currency]);
            }

            if (request.Amount <= 0)
            {
                return ReturnInvalidResponse(request.Currency,
                    usersData[request.SourceUserId][request.Currency],
                    usersData[request.DestUserId][request.Currency]);
            }

            try
            {
                if(usersData[request.SourceUserId][request.Currency][request.SourceBalance]
                    - request.Amount < 0 && !request.OverdraftAllowed)
                {
                    return ReturnInsufficientFundsResponse(request.Currency,
                    usersData[request.SourceUserId][request.Currency],
                    usersData[request.DestUserId][request.Currency]);
                }

                usersData[request.DestUserId][request.Currency][request.DestBalance] += request.Amount;
                usersData[request.SourceUserId][request.Currency][request.SourceBalance] -= request.Amount;

            }
            catch
            {
                return ReturnFailResponse(request.Currency,
                    usersData[request.SourceUserId][request.Currency],
                    usersData[request.DestUserId][request.Currency]);
            }

            return ReturnSuccessResponse(request.Currency,
                    usersData[request.SourceUserId][request.Currency],
                    usersData[request.DestUserId][request.Currency]);
        }

        public IUserBalancesResponse? GetUserBalances(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return null;
            }

            if (usersData is not null && usersData.ContainsKey(userId))
            {
                return new UserBalancesResponse(usersData[userId]);
            }
            return null;
        }

        public BillingService()
        {
            usersData = new Dictionary<string, Dictionary<string, Dictionary<string, decimal>>>();
        }

        public static Dictionary<string, Dictionary<string, decimal>> GetCurrency(string currency, string balance)
        {
            var dictionary = new Dictionary<string, Dictionary<string, decimal>>
            {
                {currency, new Dictionary<string, decimal>
                    {
                        { balance, 0m }
                    }
                }
            };

            return dictionary;
        }

        public void CreateUser(string userId, string currency, string balance)
        {
            usersData.Add(userId, GetCurrency(currency, balance));
        }

        public void CreateCurrency(string userId, string currency, string balance)
        {
            var temp = GetCurrency(currency, balance);
            usersData[userId].Add(currency, temp[balance]);
        }

        public void CreateBalance(string userId, string currency, string balance)
        {
            usersData[userId][currency].Add(balance, 0m);
        }

        public static ITransactionResponse ReturnInvalidResponse()
        {
            return new TransactionResponse(TransactionResult.InvalidRequest, "0",
                    new Dictionary<string, decimal>(), new Dictionary<string, decimal>());
        }

        public static ITransactionResponse ReturnInvalidResponse(string currency,
            Dictionary<string, decimal> sourceBalance, Dictionary<string, decimal> destinationBalance)
        {
            return new TransactionResponse(TransactionResult.InvalidRequest, currency,
                    sourceBalance, destinationBalance);
        }

        public static ITransactionResponse ReturnFailResponse(string currency,
            Dictionary<string, decimal> sourceBalance, Dictionary<string, decimal> destinationBalance)
        {
            return new TransactionResponse(TransactionResult.Fail, currency,
                    sourceBalance, destinationBalance);
        }

        public static ITransactionResponse ReturnInsufficientFundsResponse(string currency,
            Dictionary<string, decimal> sourceBalance, Dictionary<string, decimal> destinationBalance)
        {
            return new TransactionResponse(TransactionResult.InsufficientFunds, currency,
                    sourceBalance, destinationBalance);
        }

        public static ITransactionResponse ReturnSuccessResponse(string currency,
            Dictionary<string, decimal> sourceBalance, Dictionary<string, decimal> destinationBalance)
        {
            return new TransactionResponse(TransactionResult.Success, currency,
                    sourceBalance, destinationBalance);
        }

        public static bool ReturnInvalidResponseNull(ITransactionRequest request)
        {
            if(string.IsNullOrEmpty(request.Currency) || string.IsNullOrEmpty(request.DestBalance)
                || string.IsNullOrEmpty(request.DestUserId) || string.IsNullOrEmpty(request.SourceBalance)
                || string.IsNullOrEmpty(request.SourceUserId) || string.IsNullOrEmpty(request.TransactionId))
            {
                return false;
            }
            if(request.Timestamp.ToUniversalTime() <= DateTimeOffset.MinValue.UtcDateTime)
            {
                return false;
            }
            return true;
        }
    }
}
