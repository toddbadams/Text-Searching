using System.Collections.Generic;

namespace TextSearching
{
    /// <summary>
    /// String matching given a pattern x, find all its locations in any text y
    /// Pattern: a string x of symbols, of length m:  t a t a
    /// Text: a string y of symbols, of length n:  c a c g t a t a t a t g c g t t a t a a t
    /// Occurrences at positions 4, 6, 15
    /// </summary>
    public static class FixedStringSearchExtension
    {
        /// <summary>
        /// Principles - No memorization, shift by 1 position
        /// Complexity - O(m × n) time, O(1) extra space
        /// Number of symbol comparisons
        ///    maximum ≈ m × n
        ///    expected ≈ 2 × n   on a two-letter alphabet, with equiprobablity and independence conditions
        /// </summary>
        /// <param name="text">text being search</param>
        /// <param name="pattern">pattern to find in text</param>
        /// <returns>array of position</returns>
        public static int[] NaiveSearch(this string text, string pattern)
        {
            if (string.IsNullOrEmpty(text)
                || string.IsNullOrEmpty(pattern)
                || pattern.Length > text.Length) return new int[0];

            var pos = 0;
            var posList = new List<int>();
            while (pos <= text.Length - pattern.Length)
            {
                var i = 0;
                while (i < pattern.Length && pattern[i] == text[pos + i])
                {
                    i++;
                }
                if (i == pattern.Length)
                {
                    posList.Add(pos);
                }
                pos++;
            }
            return posList.ToArray();
        }
    }
}
