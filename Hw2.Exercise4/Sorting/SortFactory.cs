namespace Hw2.Exercise4.Sorting
{
    /// <summary>
    /// Sort algorithm factory
    /// </summary>
    public class SortFactory
    {
        /// <summary>
        /// Tries to resolve sort algorithm.
        /// Supported algorithms :
        /// Bubble;
        /// System (<see cref="Array.Sort(Array)"/>);
        /// Quick.
        /// </summary>
        /// <param name="algorithm">Desired algorithm name.</param>
        /// <returns>Returns requested sort algorithm; returns <c>null</c> if algorithm wasn't resolved.</returns>
        public SortBase? ResolveSort(string algorithm)
        {

            if (algorithm is null)
            {
                return null;
            }

            switch (algorithm.ToLowerInvariant())
            {
                case "bubble":
                    return new BubbleSort();
                case "system":
                    return new SystemSort();
                case "quick":
                    return new QuickSort();
                default:
                    return null;
            }
        }
    }
}
