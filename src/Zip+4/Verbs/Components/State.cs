using System.Collections.Generic;

using ZipPlus4.Internal;

namespace ZipPlus4
{
    /// <summary>
    ///     Parses the US state into the approprariate abbreviations.
    /// </summary>
    public class State : Abbreviations
    {
        #region Fields

        /// <summary>
        ///     The abbreviations
        /// </summary>
        private static readonly List<Abbreviation> Abbreviations = Abbreviation.CreateStateAbbreviations();

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="State" /> class.
        /// </summary>
        public State()
            : base(Abbreviations)
        {
        }

        #endregion
    }
}