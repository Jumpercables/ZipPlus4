using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ZipPlus4
{
    /// <summary>
    ///     An abstract class used to represent the data for an address element and used as a factory class to parse the elements.
    /// </summary>
    public abstract class AddressVerb 
    {
        #region Public Methods

        /// <summary>
        ///     Parses the specified data into the tokenized data based on the type.
        /// </summary>
        /// <typeparam name="TAddress">The type of the component.</typeparam>
        /// <param name="data">The data.</param>
        /// <returns>
        ///     Returns a <see cref="string" /> representing the parsed value, otherwise <c>null</c>.
        /// </returns>
        public static string Parse<TAddress>(string data) where TAddress : AddressVerb, new()
        {
            if (data == null)
                return null;

            return Parse<TAddress>(Regex.Matches(data, @".+").Cast<Match>().ToList());
        }

        /// <summary>
        ///     Parses the specified data into the tokenized data based on the type.
        /// </summary>
        /// <typeparam name="TAddress">The type of the component.</typeparam>
        /// <param name="data">The data.</param>
        /// <returns>
        ///     Returns a <see cref="string" /> representing the parsed value, otherwise <c>null</c>.
        /// </returns>
        public static string Parse<TAddress>(List<Match> data) where TAddress : AddressVerb, new()
        {
            if (data == null || data.Count == 0)
                return null;

            var address = new TAddress();
            return address.Parse(data, 0);
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
        protected abstract string Parse(List<Match> collection, int depth);

        /// <summary>
        ///     Removes the punctuation from the string.
        /// </summary>
        /// <param name="s1">The string that will have the punctuation removed.</param>
        /// <returns>
        ///     Returns a <see cref="string" /> representing a string without punctuation.
        /// </returns>
        protected string RemovePunctuation(string s1)
        {
            return s1.Where(c => !char.IsPunctuation(c))
                .Aggregate(new StringBuilder(),
                    (current, next) => current.Append(next), sb => sb.ToString().Trim());
        }

        #endregion
    }
}