using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ZipPlus4
{
    /// <summary>
    ///     Official name of a street as assigned by a local governing authority, or an alternate
    ///     (alias) name that is used and recognized, excluding street types, directionals, and
    ///     modifiers.
    /// </summary>
    public class Street : AddressDescriptor
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

            // One and only one character.
            var m = Regex.Match(data.Value, @"(^[a-zA-Z]$)");
            if (m.Success)
            {
                if (depth == 0)
                {
                    collection.Remove(data);

                    value = m.Value;
                }
                else
                {
                    return null;
                }
            }

            // Remove the cross streets and street intersections, as they are not supported.
            if (data.Value.Equals("/") || Regex.IsMatch(data.Value, @"([a-zA-Z]+\/[a-zA-Z]+)") || Regex.IsMatch(data.Value, @"^(AND)|(BETWEEN)$", RegexOptions.IgnoreCase))
            {
                collection.Remove(data);

                if (collection.Count > 0)
                    this.Parse(collection, ++depth); // The data is not used on purpose.
            }
            else
            {
                // Zero or more digits and/or one or more characters
                m = Regex.Match(data.Value, @"(\d+)?([a-zA-Z]+)");
                if (m.Success)
                {
                    collection.Remove(data);

                    value = collection.Count > 0 ? (this.Parse(collection, ++depth) + " " + m.Value).Trim() : m.Value;
                }

                // When the 2 matches remaining are only digits.
                if (collection.Count == 2 && collection.All(o => Regex.IsMatch(o.Value, @"^(\d+)$")))
                {
                    collection.Remove(data);

                    value = (this.Parse(collection, ++depth) + " " + data.Value).Trim();
                }
            }

            return value;
        }

        #endregion
    }
}