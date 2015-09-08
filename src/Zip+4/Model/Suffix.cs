using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

using ZipPlus4.Model.Internal;

namespace ZipPlus4.Model
{
    /// <summary>
    ///     The suffix abbreviation of the street.
    /// </summary>
    public class Suffix : Address
    {
        #region Fields

        private static readonly List<Abbreviation> Abbreviations = Abbreviation.CreateStreetAbbreviations();

        #endregion

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
            var m = Regex.Match(data.Value, @"(\d*)?" + // optionally zero or more digits
                                            @"([a-zA-z]{2,})"); // two or more characters;
            if (m.Success)
            {
                var abbreviation = Abbreviations.FirstOrDefault(o => o.Name.Equals(m.Value, StringComparison.InvariantCultureIgnoreCase));
                if (abbreviation != null)
                {
                    value = abbreviation.Value;
                }
                else
                {
                    abbreviation = Abbreviations.FirstOrDefault(o => o.Value.Equals(m.Value, StringComparison.InvariantCultureIgnoreCase));
                    if (abbreviation != null) value = abbreviation.Value;
                }
            }

            if (value != null)
            {
                collection.Remove(data);
            }

            return value;
        }

        #endregion
    }
}