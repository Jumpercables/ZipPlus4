﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

using ZipPlus4.Model.Internal;

namespace ZipPlus4.Model
{
    /// <summary>
    ///     An abbreviated address element.
    /// </summary>
    public abstract class Abbreviations : Address
    {
        #region Fields

        /// <summary>
        ///     The abbreviated data.
        /// </summary>
        private readonly List<Abbreviation> _Abbreviations;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Abbreviations" /> class.
        /// </summary>
        /// <param name="abbreviations">The abbreviations.</param>
        internal Abbreviations(List<Abbreviation> abbreviations)
        {
            _Abbreviations = abbreviations;
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

            return this.Fuzzy(collection);
        }

        #endregion

        #region Private Methods

        /// <summary>
        ///     Tries the parse the data into the correct format using a fuzzy match.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <returns>
        ///     Returns <see cref="string" /> representing the parsed value.
        /// </returns>
        private string Fuzzy(List<Match> collection)
        {
            string value = null;
            var data = collection.First();

            var abbreviations = _Abbreviations.Select(a => new {a.Name, a.Value, Normalized = LevenshteinDistance.Normalized(data.Value, a.Name)});
            var abbreviation = abbreviations.FirstOrDefault(a => a.Normalized > 70);
            if (abbreviation != null)
            {
                value = abbreviation.Value;
            }
            else
            {
                abbreviations = _Abbreviations.Select(a => new {a.Name, a.Value, Normalized = LevenshteinDistance.Normalized(data.Value, a.Value)});
                abbreviation = abbreviations.FirstOrDefault(a => a.Normalized > 70);
                if (abbreviation != null) value = abbreviation.Value;
            }

            if (!string.IsNullOrEmpty(value))
            {
                collection.Remove(data);

                return value;
            }

            return null;
        }

        #endregion
    }
}