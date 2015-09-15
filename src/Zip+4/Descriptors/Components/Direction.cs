using System.Collections.Generic;

namespace ZipPlus4
{
    /// <summary>
    ///     A word that indicates the directional taken by the
    ///     thoroughfare from an arbitrary starting point, or the sector where it is located.
    /// </summary>
    public class Direction : Abbreviations
    {
        #region Fields

        /// <summary>
        ///     The abbreviations
        /// </summary>
        private static readonly List<Abbreviation> Abbreviations = CreateAbbreviations("Directional-Abbreviations.json");

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Direction" /> class.
        /// </summary>
        public Direction()
            : base(Abbreviations)
        {
        }

        #endregion
    }
}