using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Script.Serialization;

namespace ZipPlus4.Internal
{
    /// <summary>
    ///     An key/value pair of the name and value of the abbreviations.
    /// </summary>
    [DebuggerDisplay("Name = {Name}, Value = {Value}")]
    internal class Abbreviation
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

        #region Public Methods

        /// <summary>
        ///     Creates the spanish abbreviations.
        /// </summary>
        /// <returns>
        ///     Returns a <see cref="List{Abbreviation}" /> representing the list of abbreviations.
        /// </returns>
        public static List<Abbreviation> CreateSpanishAbbreviations()
        {
            return CreateAbbreviations("Spanish-Abbreviations.json");
        }

        /// <summary>
        ///     Creates the directional abbreviations.
        /// </summary>
        /// <returns>
        ///     Returns a <see cref="List{Abbreviation}" /> representing the list of abbreviations.
        /// </returns>
        public static List<Abbreviation> CreateDirectionalAbbreviations()
        {
            return CreateAbbreviations("Directional-Abbreviations.json");
        }

        /// <summary>
        ///     Creates the highway abbreviations.
        /// </summary>
        /// <returns>
        ///     Returns a <see cref="List{Abbreviation}" /> representing the list of abbreviations.
        /// </returns>
        public static List<Abbreviation> CreateHighwayAbbreviations()
        {
            return CreateAbbreviations("Highway-Abbreviations.json");
        }

        /// <summary>
        ///     Creates the secondary unit abbreviations.
        /// </summary>
        /// <returns>
        ///     Returns a <see cref="List{Abbreviation}" /> representing the list of abbreviations.
        /// </returns>
        public static List<Abbreviation> CreateUnitAbbreviations()
        {
            return CreateAbbreviations("Unit-Abbreviations.json");
        }

        /// <summary>
        ///     Creates the state abbreviations.
        /// </summary>
        /// <returns>
        ///     Returns a <see cref="List{Abbreviation}" /> representing the list of abbreviations.
        /// </returns>
        public static List<Abbreviation> CreateStateAbbreviations()
        {
            return CreateAbbreviations("State-Abbreviations.json");
        }

        /// <summary>
        ///     Creates the street abbreviations.
        /// </summary>
        /// <returns>
        ///     Returns a <see cref="List{Abbreviation}" /> representing the list of abbreviations.
        /// </returns>
        public static List<Abbreviation> CreateStreetAbbreviations()
        {
            return CreateAbbreviations("Street-Abbreviations.json");
        }

        #endregion

        #region Private Methods

        /// <summary>
        ///     Creates the abbreviations.
        /// </summary>
        /// <param name="resourceName">Name of the resource.</param>
        /// <returns>
        ///     Returns a <see cref="List{Abbreviation}" /> representing the list of abbreviations.
        /// </returns>
        private static List<Abbreviation> CreateAbbreviations(string resourceName)
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

        #endregion
    }
}