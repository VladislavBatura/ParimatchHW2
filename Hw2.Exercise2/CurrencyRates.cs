namespace Hw2.Exercise2
{
    /// <summary>
    /// Currency exchange service.
    /// </summary>
    public class CurrencyRates
    {
        /// <summary>
        /// Creates new instance of <see cref="CurrencyRates"/>.
        /// </summary>
        /// <param name="rates">Currency rates</param>
        /// <exception cref="ArgumentNullException">
        /// Throws when <paramref name="rates"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Throws when <paramref name="rates"/> is invalid :
        /// contains negative rates
        /// or
        /// contains duplicated currency codes (in different cases).
        /// </exception>
        public CurrencyRates(IDictionary<string, decimal> rates)
        {
            throw new NotImplementedException("Should be implemented by executor");
        }

        /// <summary>
        /// Exchanges currencies.
        /// </summary>
        /// <param name="request">Currency exchange request.</param>
        /// <returns>
        /// Returns amount of desired currency or <c>null</c> if requested currency is unknown.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Throws when <see cref="ExchangeRequest.IsValid"/> indicates invalid request.
        /// </exception>
        public decimal? Exchange(ExchangeRequest request)
        {
            throw new NotImplementedException("Should be implemented by executor");
        }
    }
}
