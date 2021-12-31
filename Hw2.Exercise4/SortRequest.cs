using System.Globalization;

namespace Hw2.Exercise4
{
    /// <summary>
    /// Sort request.
    /// </summary>
    public class SortRequest
    {
        /// <summary>
        /// Requested sort algorithm.
        /// </summary>
        public string SortAlgorith { get; }

        /// <summary>
        /// Array to sort.
        /// </summary>
        public int[] Array { get; set; }

        /// <summary>
        /// Creates instance of <see cref="SortRequest"/>.
        /// </summary>
        /// <param name="sortAlgorithm">Sort algorithm name.</param>
        /// <param name="array">Array to sort.</param>
        /// <exception cref="ArgumentNullException">
        /// Throws when one of the given arguments is null.
        /// </exception>
        public SortRequest(string sortAlgorithm, int[] array)
        {
            if (sortAlgorithm is null)
            {
                throw new ArgumentNullException(nameof(sortAlgorithm));
            }
            else if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            SortAlgorith = sortAlgorithm;
            Array = array;
        }

        /// <summary>
        /// Tries to parse command line arguments as <see cref="SortRequest"/>.
        /// </summary>
        /// <param name="args">CLI arguments.</param>
        /// <param name="request">Parsed request.</param>
        /// <returns>
        /// Returns <c>true</c> in case of success, otherwise returns <c>false</c>.
        /// </returns>
        public static bool TryParse(string[] args, out SortRequest request)
        {
            if (args is null || args.Length is 0)
            {
                // Чтобы создать пустой массив
                // предпочтительно использовать Array.Empty<int>()
                // При этом не происходит выделения памяти
                request = new SortRequest("0", new int[] { 0 });
                return false;
            }

            var algorithm = args[0].ToLowerInvariant();
            var arrayWithoutAlgorithm = args.ToList();
            arrayWithoutAlgorithm.RemoveAt(0);
            var array = new int[args.Length - 1];

            if (arrayWithoutAlgorithm.Count is 0)
            {
                // для чего нужна переменная array ?
                // он же получается всегда пустой - исп. Array.Empty<int>()
                request = new SortRequest(algorithm, array);
                return true;
            }

            // Нет смысла в отдельном List<int>, чтобы потом перевести его ToArray()
            // Т.к. длинна массива аргуентов известна, то лучше сразу создать массив правильной длины
            // и наполнить его в цикле for (а не foreach)
            // Такой массив уже есть выше : var array = new int[args.Length - 1] 
            var listArray = new List<int>();
            foreach (var arg in arrayWithoutAlgorithm)
            {
                // С целыми числами, можно так не замарачиваться - использовать более лаконичные TryParse
                if (int.TryParse(arg, NumberStyles.Integer, CultureInfo.InvariantCulture, out var result))
                {
                    listArray.Add(result);
                }
                else
                {
                    request = new SortRequest("0", new int[] { 0 });
                    return false;
                }
            }

            array = listArray.ToArray();

            request = new SortRequest(algorithm, array);
            return true;
        }
    }
}
