using System;

namespace ZipPlus4.Internal
{
    /// <summary>
    ///     The "Edit Distance" also known as "Levenshtein Distance" (named after the Russian scientist
    ///     Vladimir Levenshtein, who devised the algorithm in 1965),
    ///     is a measure of Similarity between two strings, s1 and s2.
    ///     The distance is the number of insertions, deletions or substitutions required to transform s1 to s2.
    /// </summary>
    internal static class LevenshteinDistance
    {
        #region Public Methods

        /// <summary>
        ///     Calculates the number of changes required to transform string-1 into string-2
        /// </summary>
        /// <param name="s1">The string to be transformed.</param>
        /// <param name="s2">The string into which s1 is to be transformed.</param>
        /// <returns>
        ///     Returns a <see cref="int" /> representing the number of changes required to transform string-1 into string-2.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     s1
        ///     or
        ///     s2
        /// </exception>
        public static int Distance(string s1, string s2)
        {
            if (s1 == null) throw new ArgumentNullException("s1");
            if (s2 == null) throw new ArgumentNullException("s2");

            int[,] d = new int[s1.Length + 1, s2.Length + 1];

            for (int i = 0; i <= s1.Length; i++)
                d[i, 0] = i;

            for (int j = 0; j <= s2.Length; j++)
                d[0, j] = j;

            for (int j = 1; j <= s2.Length; j++)
                for (int i = 1; i <= s1.Length; i++)
                    if (s1[i - 1] == s2[j - 1])
                        d[i, j] = d[i - 1, j - 1]; // no operation
                    else
                        d[i, j] = Math.Min(Math.Min(
                            d[i - 1, j] + 1, // a deletion
                            d[i, j - 1] + 1), // an insertion
                            d[i - 1, j - 1] + 1 // a substitution
                            );

            return d[s1.Length, s2.Length];
        }

        /// <summary>
        ///     Calculates the number of insertions, deletions or substations required to transform string-1 into string-2,
        ///     and returns the Normalized value of the distance between the strings.
        /// </summary>
        /// <param name="s1">The string to be transformed.</param>
        /// <param name="s2">The string into which s1 is to be transformed.</param>
        /// <returns>
        ///     Returns a <see cref="int" /> representing the normalized value that is between 0 (no match) and 100 (perfect
        ///     match).
        /// </returns>
        public static int Normalized(string s1, string s2)
        {
            s1 = s1 ?? string.Empty;
            s2 = s2 ?? string.Empty;

            double distance = Distance(s1, s2);

            double length = s1.Length;
            if (s1.Length < s2.Length)
                length = s2.Length;

            if (Math.Abs(length - 0) <= 0)
                return 100;

            return (int) ((1 - distance/length)*100);
        }

        #endregion
    }
}