using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

using ZipPlus4.Internal;

namespace ZipPlus4
{
    public class Highway : Abbreviations
    {
        #region Fields

        /// <summary>
        ///     The abbreviations
        /// </summary>
        private static readonly List<Abbreviation> Abbreviations = Abbreviation.CreateHighwayAbbreviations();

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Highway" /> class.
        /// </summary>
        public Highway()
            : base(Abbreviations)
        {
        }

        #endregion

        #region Public Methods

        /// <summary>
        ///     Determines whether the collection is a highway.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <returns>Returns a <see cref="bool" /> representing <c>true</c> when the collection is a higway</returns>
        public static bool Is(List<Match> collection)
        {
            var reverse = collection.Cast<Match>().Reverse().ToList();
            return !string.IsNullOrEmpty(Parse<Highway>(reverse));
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
                var next = collection.Skip(1).First();
                if (next != null)
                {
                    var value = base.Parse(new List<Match>(new[] {next}), depth);
                    if (!string.IsNullOrEmpty(value))
                    {
                        collection.Remove(data);
                        collection.Remove(next);

                        return string.Concat(value, " ", data.Value).Trim();
                    }
                }
            }

            return base.Parse(collection, depth);
        }

        #endregion
    }
}