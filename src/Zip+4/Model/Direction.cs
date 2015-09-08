using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

using ZipPlus4.Model.Internal;

namespace ZipPlus4.Model
{
    /// <summary>
    ///     A word that indicates the directional taken by the
    ///     thoroughfare from an arbitrary starting point, or the sector where it is located.
    /// </summary>
    public class Direction : Address
    {
        #region Fields

        private static readonly List<Abbreviation> Abbreviations = Abbreviation.CreateDirectionalAbbreviations();

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

            var abbreviation = Abbreviations.FirstOrDefault(o => o.Name.Equals(data.Value, StringComparison.InvariantCultureIgnoreCase));
            if (abbreviation != null)
            {
                value = abbreviation.Value;
            }
            else
            {
                abbreviation = Abbreviations.FirstOrDefault(o => o.Value.Equals(data.Value, StringComparison.InvariantCultureIgnoreCase));
                if (abbreviation != null) value = abbreviation.Value;
            }

            if (value != null)
            {
                collection.Remove(data);

                return value.Trim();
            }

            return null;
        }       

        #endregion
    }
}