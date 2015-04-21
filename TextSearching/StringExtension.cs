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
                if (CheckPattern(text, pattern, pos)) posList.Add(pos);
                pos++;
            }
            return posList.ToArray();
        }

        /// <summary>
        /// Principles - ??
        /// Complexity - O(m × n) time, O(1) extra space ??
        /// Number of symbol comparisons
        ///    maximum ≈ m × n
        ///    expected ≈ 2 × n   on a two-letter alphabet, with equiprobablity and independence conditions
        /// </summary>
        /// <param name="text">text being search</param>
        /// <param name="pattern">pattern to find in text</param>
        /// <returns>array of position</returns>
        public static int[] HashedSearch(this string text, string pattern)
        {
            if (string.IsNullOrEmpty(text)
                || string.IsNullOrEmpty(pattern)
                || pattern.Length > text.Length) return new int[0];

            var patternHash = Hash(pattern);
            var posList = new List<int>();

            for (var pos = 0; pos < text.Length - pattern.Length; pos++)
            {
                if (patternHash != Hash(text.Substring(pos, pattern.Length))) continue;

                CheckPattern(text, pattern, pos, posList);
            }

            return posList.ToArray();
        }

        /// <summary>
        /// Check that a pattern matches the text at pos
        /// </summary>
        /// <param name="text">text being search</param>
        /// <param name="pattern">pattern to find in text</param>
        /// <param name="pos">position on text</param>
        /// <returns>true if matched</returns>
        private static bool CheckPattern(string text, string pattern, int pos)
        {
            var i = 0;
            while (i < pattern.Length && pattern[i] == text[pos + i])
            {
                i++;
            }
            return (i == pattern.Length);
        }

        /// <summary>
        /// Horner's Rule Hash of string 
        /// </summary>
        /// <param name="text">text being hashed</param>
        /// <returns>a unique number representing the string</returns>
        private static long Hash(string text)
        {
            return -1;
        }
        //http://en.wikipedia.org/wiki/Horner's_method
        //double HornerEvaluate (double x, double * CoefficientsOfPolynomial, unsigned int DegreeOfPolynomial)
        //{
        //    /*
        //        We want to evaluate the polynomial in x, of coefficients CoefficientsOfPolynomial, using Horner's method.
        //        The result is stored in dbResult.
        //    */
        //    double dbResult = 0.;
        //    int i;
        //    for(i = 0; i <= DegreeOfPolynomial; i++)
        //    {
        //        dbResult = dbResult * x + CoefficientsOfPolynomial[i];
        //    }
        //    return dbResult;
        //}
    }
}
