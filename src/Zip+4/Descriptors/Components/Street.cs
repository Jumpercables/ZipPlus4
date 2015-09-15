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
            
            var m = Regex.Match(data.Value, @"(^[a-zA-Z]$)"); // one and only one character.
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

            if (data.Value.Equals("/") || Regex.IsMatch(data.Value, @"([a-zA-Z]+\/[a-zA-Z]+)") || Regex.IsMatch(data.Value, @"^(AND)|(BETWEEN)$", RegexOptions.IgnoreCase))
            {
                 collection.Remove(data);

                if (collection.Count > 0) 
                    this.Parse(collection, ++depth); // The data is not used on purpose.
            }
            else
            {
                m = Regex.Match(data.Value, @"(\d+)?([a-zA-Z]+)"); // zero or more digits and zero or more characters
                if (m.Success)
                {
                    collection.Remove(data);

                    value = collection.Count > 0 ? (this.Parse(collection, ++depth) + " " + m.Value).Trim() : m.Value;
                }

                if (collection.Count == 2)
                {
                    m = Regex.Match(data.Value, @"^(\d+)$"); // one or more digits only.
                    if (m.Success)
                    {
                        collection.Remove(data);

                        value = collection.Count > 0 ? (this.Parse(collection, ++depth) + " " + m.Value).Trim() : m.Value;
                    }
                }
            }

            return value;
        }

        #endregion
    }
}