using System.Collections.Generic;

using ZipPlus4.Model.Internal;

namespace ZipPlus4.Model
{
    /// <summary>
    ///     A word that indicates the directional taken by the
    ///     thoroughfare from an arbitrary starting point, or the sector where it is located.
    /// </summary>
    public class Direction : Abbreviations
    {
        #region Fields

        /// <summary>
        /// The abbreviations
        /// </summary>
        private static readonly List<Abbreviation> Abbreviations = Abbreviation.CreateDirectionalAbbreviations();

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