using System.Collections.Generic;

namespace ZipPlus4
{
    /// <summary>
    ///     In many areas of the country, street names are influenced by Hispanic
    ///     culture. In these areas, Spanish prefix words such as AVENIDA, CALLE, and
    ///     CAMINO are frequently used as the first word of the street name and often
    ///     combined with prepositional phrases such as de, la, de las, and the noun
    ///     they are describing.
    /// </summary>
    public class Prefix : Abbreviations
    {
        #region Fields

        private static readonly List<Abbreviation> Abbreviations = CreateAbbreviations("Spanish-Abbreviations.json");

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Prefix" /> class.
        /// </summary>
        public Prefix()
            : base(Abbreviations)
        {
        }

        #endregion
    }
}