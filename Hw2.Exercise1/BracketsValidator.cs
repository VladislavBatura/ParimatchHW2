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

            var array = sequence.ToCharArray();
            if (array.Length == 0)
            {
                return true;
            }
            var stack = new Stack<char>();
            foreach (var item in array)
            {
                // In-place hardcode 
                // Более элегантное решение использовать Dictionary<char,char>
                // Тогда можно обращаться к откр. скобкам - Dictionary.Keys (или метод ContainsKey)
                // А к закр. скобкам - Dictionary.Values (или метод ContainsValue)
                /*
                    var brackets = new Dictionary<char, char>()
                    {
                        ['('] = ')',
                        ['['] = ']',
                        ['{'] = '}',
                        ['<'] = '>',
                    };
                */
                if (item is '(' or '[' or '{' or '<')
                {
                    stack.Push(item);
                }
                else if (item is ')' or ']' or '}' or '>')
                {
                    if (stack.TryPop(out var result))
                    {
                        if (result != GetFullBracket(item))
                        {
                            return false;
                        }
                        continue;
                    }
                    return false;
                }
            }
            if (stack.Count != 0)
            {
                return false;
            }

            return true;
        }

        private char GetFullBracket(char item)
        {
            // если работать со словарем, то можно обойтись без switch
            switch (item)
            {
                case ')':
                    return '(';
                case '}':
                    return '{';
                case ']':
                    return '[';
                case '>':
                    return '<';
                default:
                    return ' ';
            }
        }
    }
}
