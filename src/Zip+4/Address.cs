using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ZipPlus4
{
    /// <summary>
    ///      A complete address as one that has all the address elements necessary to allow an exact match with the current Postal Service standards.
    /// </summary>
    public abstract class Address
    {
        #region Public Methods

        /// <summary>
        ///     Parses the specified data into the postal address type.
        /// </summary>
        /// <typeparam name="TPostalAddress">The type of the component.</typeparam>
        /// <param name="data">The data.</param>
        /// <returns>
        ///     Returns a <see cref="TPostalAddress" /> representing the object, otherwise <c>null</c>.
        /// </returns>
        public static TPostalAddress Parse<TPostalAddress>(string data) where TPostalAddress : Address, new()
        {
            return Parse<TPostalAddress>(data, completion => { });
        }

        /// <summary>
        ///     Parses the specified data into the postal address type.
        /// </summary>
        /// <typeparam name="TPostalAddress">The type of the component.</typeparam>
        /// <param name="data">The data.</param>
        /// <param name="completion">The action delegate that is called once the parsing completes.</param>
        /// <returns>
        ///     Returns a <see cref="TPostalAddress" /> representing the object, otherwise <c>null</c>.
        /// </returns>
        public static TPostalAddress Parse<TPostalAddress>(string data, Action<TPostalAddress> completion) where TPostalAddress : Address, new()
        {
            if (data == null)
                return null;

            return Parse(data, @"[^\s" + // anything but whitespace
                               @"\." + // ignore periods
                               @"]+",
                completion);
        }

        /// <summary>
        ///     Parses the specified data into the postal address type.
        /// </summary>
        /// <typeparam name="TPostalAddress">The type of the component.</typeparam>
        /// <param name="data">The data.</param>
        /// <param name="pattern">The regular expression pattern that is used to parse the data.</param>
        /// <param name="completion">The action delegate that is called once the parsing completes.</param>
        /// <returns>
        ///     Returns a <see cref="TPostalAddress" /> representing the object, otherwise <c>null</c>.
        /// </returns>
        public static TPostalAddress Parse<TPostalAddress>(string data, string pattern, Action<TPostalAddress> completion) where TPostalAddress : Address, new()
        {
            if (data == null)
                return null;

            var collection = Regex.Matches(data.ToUpperInvariant().Trim(), pattern);

            var address = new TPostalAddress();
            address.Parse(collection.Cast<Match>().ToList());

            completion(address);

            return address;
        }

        #endregion

        #region Protected Methods

        /// <summary>
        ///     Tries the parse the data into the correct format.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <returns>
        ///     Returns <see cref="string" /> representing the parsed value.
        /// </returns>
        protected abstract string Parse(List<Match> collection);

        #endregion
    }
}