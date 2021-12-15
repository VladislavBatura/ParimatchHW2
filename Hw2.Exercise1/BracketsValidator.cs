namespace Hw2.Exercise1
{
    /// <summary>
    /// Brackets sequence validator.
    /// </summary>
    public class BracketsValidator
    {
        /// <summary>
        /// Validates chars sequence if all brackets are closed in right order.
        /// Supported brackets : '{', '}', '[', ']', '(', ')', '<', '>'.
        /// </summary>
        /// <param name="sequence">Char sequence.</param>
        /// <returns>
        /// Returns <c>true</c> if all brackets are closed in the right order (or no brackets at all). 
        /// Otherwise returns <c>false</c>.
        /// </returns>
        /// <exception cref="ArgumentNullException">Sequence is null.</exception>
        public bool IsSequenceValid(string sequence)
        {
            if (sequence is null)
                throw new ArgumentNullException(nameof(sequence));

            throw new NotImplementedException("Should be implemented by executor");
        }
    }
}
