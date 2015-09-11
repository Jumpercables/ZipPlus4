using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ZipPlus4
{
    /// <summary>
    ///     The numeric identifier for a land parcel, house, building or other feature, as
    ///     defined by the official address authority for the given jurisdiction.
    /// </summary>
    public class Number : AddressVerb
    {
        #region Protected Methods

        /// <summary>
        ///     Tries the parse the data into the correct format.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="depth">The depth.</param>
        /// <returns>
        ///     Returns <see cref="string" /> representing the parsed value.
        /// </returns>
        protected override string Parse(List<Match> collection, int depth)
        {
            string value = null;
            var data = collection.First();
            var m = Regex.Match(data.Value, @"\d+" + // one or more digits
                                            @"(\.?\d+)"); // optionally zero or more periods and one or more digits.
            if (m.Success)
            {
                value = m.Value.Trim();
            }

            collection.Remove(data);

            return value;
        }

        #endregion
    }
}