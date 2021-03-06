using System.Globalization;

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
            if (rates is null)
            {
                throw new ArgumentNullException(nameof(rates));
            }

            foreach (var rate in rates)
            {
                if (rates.ContainsKey(rate.Key.ToLower(CultureInfo.InvariantCulture)))
                {
                    // message == null
                    // Так не принято. 
                    // Обязательно дать осмысленное лаконичное сообщение message
                    // Например : "Invalid currency rates"
                    throw new ArgumentException(null, nameof(rates));
                }
                if (rate.Value is <= 0)
                {
                    throw new ArgumentException(null, nameof(rates));
                }
            }

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
            if (!request.IsValid)
            {
                throw new ArgumentException(null, nameof(request));
            }

            decimal result;
            switch (request.DestCurrency.ToLower(CultureInfo.InvariantCulture))
            {
                /*
                Критично неправильная реализация.
                Приложение принимает курсы валют из вне.
                Там вообще может не быть USD, EUR
                Решение не проходит тест с отличными от USD, EUR валютами или курсами
                Нужно брать курс из rates
                */
                /*
                Пример реализации по-быстрому :
                return 
                !request.IsValid
                    ? throw new ArgumentException("Invalid request", nameof(request))
                    : !_rates.TryGetValue(request.SourceCurrnecy, out var src)
                        ? default
                        : !_rates.TryGetValue(request.DestCurrency, out var dest)
                            ? default
                            : (decimal?)(request.Amount * src / dest);
                */
                case "usd":
                    if (string.Equals(request.SourceCurrnecy.ToLower(CultureInfo.InvariantCulture),
                        "eur", StringComparison.Ordinal))
                    {
                        result = request.Amount * 1.2m;
                        break;
                    }
                    else if (string.Equals(request.SourceCurrnecy.ToLower(CultureInfo.InvariantCulture),
                        "usd", StringComparison.Ordinal))
                    {
                        result = request.Amount;
                        break;
                    }
                    return null;
                case "eur":
                    if (string.Equals(request.SourceCurrnecy.ToLower(CultureInfo.InvariantCulture),
                        "usd", StringComparison.Ordinal))
                    {
                        result = request.Amount / 1.2m;
                        break;
                    }
                    else if (string.Equals(request.SourceCurrnecy.ToLower(CultureInfo.InvariantCulture),
                        "eur", StringComparison.Ordinal))
                    {
                        result = request.Amount;
                        break;
                    }
                    return null;
                default:
                    return null;
            }

            return result;
        }
    }
}
