using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

using ZipPlus4.Model.Internal;

namespace ZipPlus4.Model
{
    public class Highway : Street
    {
        #region Fields

        /// <summary>
        /// The abbreviations
        /// </summary>
        private static readonly List<Abbreviation> Abbreviations = Abbreviation.CreateHighwayAbbreviations();

        #endregion

        #region Public Methods

        /// <summary>
        ///     Determines whether the data is a highway.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static bool Is(string data)
        {
            return Abbreviations.Any(o => o.Name.Equals(data, StringComparison.InvariantCultureIgnoreCase));
        }

        #endregion

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
            var data = collection.First();
            var m = Regex.Match(data.Value, @"^(\d{2,3})$"); // between 2 and 3 digits.
            if (m.Success)
            {
                collection.Remove(data);

                if (collection.Count > 0)
                    return this.Parse(collection, ++depth) + " " + m.Value.Trim();

                return m.Value.Trim();
            }

            m = Regex.Match(data.Value, @"([a-zA-Z]+)"); // one or more characters
            if (m.Success)
            {
                collection.Remove(data);

                if (collection.Count > 0)
                    return this.Parse(collection, ++depth) + " " + m.Value.Trim();

                return m.Value.Trim();
            }

            return null;
        }

        #endregion
    }
}