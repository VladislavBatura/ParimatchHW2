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
            throw new NotImplementedException("Should be implemented by executor");
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
            throw new NotImplementedException("Should be implemented by executor");
        }
    }
}
