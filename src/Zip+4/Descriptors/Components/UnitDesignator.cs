using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

using ZipPlus4.Internal;

namespace ZipPlus4
{
    public class UnitDesignator : Abbreviations
    {
        #region Fields

        private static readonly List<Abbreviation> Abbreviations = Abbreviation.CreateUnitAbbreviations();

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="UnitDesignator" /> class.
        /// </summary>
        public UnitDesignator()
            : base(Abbreviations, 90)
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
            var data = collection.First();
            var number = Parse<Number>(new List<Match>(new[] {data}));

            if (!string.IsNullOrEmpty(number))
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
            
            return null;
        }

        #endregion
    }
}