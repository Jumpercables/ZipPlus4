using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ZipPlus4.Model
{
    /// <summary>
    ///     Official name of a street as assigned by a local governing authority, or an alternate
    ///     (alias) name that is used and recognized, excluding street types, directionals, and
    ///     modifiers.
    /// </summary>
    public class Street : Address
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

            var m = Regex.Match(data.Value, @"(^[a-zA-Z]$)"); // one and only one character.
            if (m.Success)
            {
                if (depth == 0)
                {
                    value = m.Value;
                    collection.Remove(data);
                }
                else
                {
                    return null;
                }
            }

            m = Regex.Match(data.Value, @"(\d+?" + // one or more digits
                                            @"[a-zA-Z]+)" + // one or more characters                                       
                                            @"|([a-zA-Z]{1,})"); // OR 2 or more characters)
            if (m.Success)
            {                
                collection.Remove(data);

                if (collection.Count > 0)
                    value = this.Parse(collection, ++depth) + " " + m.Value;
                else 
                    value = m.Value;
            }

            return value;
        }

        #endregion
    }
}