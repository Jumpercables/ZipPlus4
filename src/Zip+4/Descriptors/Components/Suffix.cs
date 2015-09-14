using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

using ZipPlus4.Internal;

namespace ZipPlus4
{
    /// <summary>
    ///     The suffix abbreviation of the street.
    /// </summary>
    public class Suffix : Abbreviations
    {
        #region Fields

        private static readonly List<Abbreviation> Abbreviations = Abbreviation.CreateStreetAbbreviations();

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Suffix" /> class.
        /// </summary>
        public Suffix()
            : base(Abbreviations)
        {
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
            string value = null;
            var data = collection.First();
            var m = Regex.Match(data.Value, @"(\d*)?" + // optionally zero or more digits
                                            @"([a-zA-z]{2,})"); // two or more characters;
            if (m.Success)
            {
                value = base.Parse(collection, depth);
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