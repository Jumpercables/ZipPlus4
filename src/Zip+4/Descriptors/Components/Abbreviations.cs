using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

using ZipPlus4.Internal;

namespace ZipPlus4
{
    /// <summary>
    ///     An abbreviated address element.
    /// </summary>
    public abstract class Abbreviations : AddressDescriptor
    {
        #region Fields

        /// <summary>
        ///     The abbreviated data.
        /// </summary>
        private readonly List<Abbreviation> _Abbreviations;

        /// <summary>
        ///     The minimum fuzzy score.
        /// </summary>
        private readonly int _MinimumFuzzyScore;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Abbreviations" /> class.
        /// </summary>
        /// <param name="abbreviations">The abbreviations.</param>
        /// <param name="minimumFuzzyScore">The minimum fuzzy score.</param>
        internal Abbreviations(List<Abbreviation> abbreviations, int minimumFuzzyScore = 100)
        {
            _Abbreviations = abbreviations;
            _MinimumFuzzyScore = minimumFuzzyScore;
        }

        #endregion

        #region Protected Properties

        /// <summary>
        ///     Gets the minimum fuzzy score.
        /// </summary>
        /// <value>
        ///     The minimum fuzzy score.
        /// </value>
        protected virtual int MinimumFuzzyScore
        {
            get { return _MinimumFuzzyScore; }
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

            var abbreviation = _Abbreviations.FirstOrDefault(o => o.Name.Equals(data.Value, StringComparison.InvariantCultureIgnoreCase));
            if (abbreviation != null)
            {
                value = abbreviation.Value;
            }
            else
            {
                abbreviation = _Abbreviations.FirstOrDefault(o => o.Value.Equals(data.Value, StringComparison.InvariantCultureIgnoreCase));
                if (abbreviation != null) value = abbreviation.Value;
            }

            if (!string.IsNullOrEmpty(value))
            {
                collection.Remove(data);

                return value;
            }

            return this.Fuzzy(collection, this.MinimumFuzzyScore);
        }

        #endregion

        #region Private Methods

        /// <summary>
        ///     Tries the parse the data into the correct format using a fuzzy match.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="minimumFuzzyScore">The minimum fuzzy score.</param>
        /// <returns>
        ///     Returns <see cref="string" /> representing the parsed value.
        /// </returns>
        private string Fuzzy(List<Match> collection, int minimumFuzzyScore)
        {
            string value = null;
            var data = collection.First();

            var normalized = _Abbreviations.Select(a => new { a.Name, a.Value, Normalized = LevenshteinDistance.Normalized(data.Value.ToUpperInvariant(), a.Name.ToUpperInvariant()) }).ToArray();
            var max = normalized.Max(a => a.Normalized);
            if (max >= minimumFuzzyScore)
            {
                value = normalized.First(a => a.Normalized == max).Value;
            }

            if (string.IsNullOrEmpty(value))
            {
                normalized = _Abbreviations.Select(a => new { a.Name, a.Value, Normalized = LevenshteinDistance.Normalized(data.Value.ToUpperInvariant(), a.Value.ToUpperInvariant()) }).ToArray();
                max = normalized.Max(a => a.Normalized);
                if (max >= minimumFuzzyScore)
                {
                    value = normalized.First(a => a.Normalized == max).Value;
                }
            }

            if (!string.IsNullOrEmpty(value))
            {
                collection.Remove(data);
            }

            return value;
        }

        #endregion
    }
}