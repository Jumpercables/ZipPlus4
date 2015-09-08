using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ZipPlus4.Model
{
    /// <summary>
    ///     A word that indicates a fractional address number.
    /// </summary>
    public class Fraction : Address
    {
        #region Internal Methods

        /// <summary>
        /// Tries the parse the data into the correct format.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="depth">The depth.</param>
        /// <returns>
        /// Returns <see cref="string" /> representing the parsed value.
        /// </returns>
        protected override string Parse(List<Match> collection, int depth)
        {
            string value = null;
            var data = collection.First();
            var m = Regex.Match(data.Value, @"(\d?" + // zero or more digits
                                            @"\/" + // one slash
                                            @"\d?)"); // zero or more digits)
            if (m.Success)
            {
                m = Regex.Match(m.Value, @"(\d" + // one digit
                                         @"\/" + //  one slash (/)
                                         @"\d)"); // one digit
                if (m.Success)
                {
                    value = m.Value.Trim();
                }

                collection.Remove(data);
            }

            return value;
        }

        #endregion
    }
}