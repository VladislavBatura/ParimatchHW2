using Hw2.Exercise5.Models;

namespace Hw2.Exercise5.Services
{
    /// <summary>
    /// Billing system core.
    /// </summary>
    public class BillingService : IBillingService
    {
        /// <inheritdoc/>
        public ITransactionResponse ProcessTransaction(ITransactionRequest request)
        {
            throw new NotImplementedException("Should be implemented by executor");
        }

        public IUserBalancesResponse? GetUserBalances(string userId)
        {
            throw new NotImplementedException("Should be implemented by executor");
        }
    }
}
