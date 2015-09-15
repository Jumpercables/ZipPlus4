using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;

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
        ///     Creates the abbreviations.
        /// </summary>
        /// <param name="resourceName">Name of the resource.</param>
        /// <returns>
        ///     Returns a <see cref="List{Abbreviation}" /> representing the list of abbreviations.
        /// </returns>
        protected static List<Abbreviation> CreateAbbreviations(string resourceName)
        {
            List<Abbreviation> abbreviations = new List<Abbreviation>();
            Assembly assembly = Assembly.GetExecutingAssembly();
            var name = assembly.GetManifestResourceNames().FirstOrDefault(o => o.EndsWith(resourceName));
            if (name != null)
            {
                using (var rs = assembly.GetManifestResourceStream(name))
                {
                    if (rs != null)
                    {
                        using (var sr = new StreamReader(rs))
                        {
                            JavaScriptSerializer serializer = new JavaScriptSerializer();
                            abbreviations = serializer.Deserialize<List<Abbreviation>>(sr.ReadToEnd());
                        }
                    }
                }
            }

            return abbreviations;
        }

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

            var normalized = _Abbreviations.Select(a => new {a.Name, a.Value, Normalized = LevenshteinDistance.Normalized(data.Value.ToUpperInvariant(), a.Name.ToUpperInvariant())}).ToArray();
            var max = normalized.Max(a => a.Normalized);
            if (max >= minimumFuzzyScore)
            {
                value = normalized.First(a => a.Normalized == max).Value;
            }

            if (string.IsNullOrEmpty(value))
            {
                normalized = _Abbreviations.Select(a => new {a.Name, a.Value, Normalized = LevenshteinDistance.Normalized(data.Value.ToUpperInvariant(), a.Value.ToUpperInvariant())}).ToArray();
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

    /// <summary>
    ///     An key/value pair of the name and value of the abbreviations.
    /// </summary>
    [DebuggerDisplay("Name = {Name}, Value = {Value}")]
    public class Abbreviation
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the commonly used name abbreviation
        /// </summary>
        /// <value>
        ///     The commonly used.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the standard abbreviation.
        /// </summary>
        /// <value>
        ///     The postal.
        /// </value>
        public string Value { get; set; }

        #endregion
    }
}