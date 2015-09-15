using System.Collections.Generic;

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
        private static readonly List<Abbreviation> Abbreviations = CreateAbbreviations("State-Abbreviations.json");

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="State" /> class.
        /// </summary>
        public State()
            : base(Abbreviations, 70)
        {
        }

        #endregion
    }
}