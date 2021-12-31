using System.Globalization;

namespace Hw2.Exercise2
{
    /// <summary>
    /// Currency exchange request.
    /// </summary>
    public readonly struct ExchangeRequest
    {
        /// <summary> Source amount.</summary>
        public decimal Amount { get; }

        /// <summary> Source currency.</summary>
        public string SourceCurrnecy { get; }

        /// <summary> Destination currency.</summary>
        public string DestCurrency { get; }

        /// <summary>
        /// Indicates if current request is valid.
        /// </summary>
        public bool IsValid =>
            Amount > decimal.Zero
            && SourceCurrnecy is not null
            && DestCurrency is not null;

        /// <summary>
        /// Creates new instance of <see cref="ExchangeRequest"/>.
        /// </summary>
        public ExchangeRequest(decimal amount, string sourceCurrnecy, string destCurrnecy)
        {
            Amount = amount;
            SourceCurrnecy = sourceCurrnecy;
            DestCurrency = destCurrnecy;
        }

        /// <summary>
        /// Tries to parse command line arguments as <see cref="ExchangeRequest"/>.
        /// </summary>
        /// <param name="args">CLI arguments.</param>
        /// <param name="request">Parsed request.</param>
        /// <returns>
        /// Returns <c>true</c> in case of success, otherwise returns <c>false</c>.
        /// </returns>
        public static bool TryParse(string[] args, out ExchangeRequest request)
        {

            if (args is null || args.Length == 0)
            {
                request = new ExchangeRequest();
                return false;
            }

            var str = args[0].Replace(',', '.');
            var listArgs = args.ToList();
            listArgs.RemoveAt(0);
            string? firstCurrency = null;
            string? secondCurrency = null;

            // логика неочевидна - over-engineering
            // нет смысла так мудрить - достаточно обратится к аргументам по индексу
            // предварительно проверив, что передано строго 3 аргумента (args.Length == 3)

            foreach (var i in listArgs)
            {
                if (firstCurrency is not null)
                {
                    secondCurrency = i.ToUpper(CultureInfo.InvariantCulture);
                    break;
                }
                firstCurrency = i.ToUpper(CultureInfo.InvariantCulture);
            }

            if (firstCurrency is null || secondCurrency is null)
            {
                request = new ExchangeRequest();
                return false;
            }

            if (decimal.TryParse(str, NumberStyles.Number, CultureInfo.InvariantCulture, out var value))
            {
                request = new ExchangeRequest(value, firstCurrency, secondCurrency);
                return true;
            }

            request = new ExchangeRequest();
            return false;
        }
    }
}
