using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ZipPlus4
{
    /// <summary>
    /// An address that follows the USPS addressing standards.
    /// </summary>
    public class PostalAddress : Address
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the non-integer portion of the identifier for the house, building or other feature which follows the
        ///     address number itself, as defined by the official address authority for the given jurisdiction.
        /// </summary>
        /// <value>
        ///     The fraction.
        /// </value>
        public string Fraction { get; set; }

        /// <summary>
        ///     Gets or sets the numeric identifier for a land parcel, house, building or other feature, as defined by the official
        ///     address authority for the given jurisdiction.
        /// </summary>
        /// <value>
        ///     The number.
        /// </value>
        public string Number { get; set; }

        /// <summary>
        ///     Gets or sets the word following the street name that indicates the directional taken by the thoroughfare from an
        ///     arbitrary starting point, or the sector where it is located
        /// </summary>
        /// <value>
        ///     The post directional.
        /// </value>
        public string PostDirectional { get; set; }

        /// <summary>
        ///     Gets or sets the word preceding the street name that indicates the directional taken by the thoroughfare from an
        ///     arbitrary starting point, or the sector where it is located.
        /// </summary>
        /// <value>
        ///     The pre directional.
        /// </value>
        public string PreDirectional { get; set; }

        /// <summary>
        ///     Gets or sets  the official name of a street as assigned by a local governing authority, or an alternate
        ///     (alias) name that is used and recognized, excluding street types, directionals, and
        ///     modifiers.
        /// </summary>
        /// <value>
        ///     The street.
        /// </value>
        public string Street { get; set; }

        /// <summary>
        ///     Gets or sets the suffix abbreviation of the street.
        /// </summary>
        public string Suffix { get; set; }

        /// <summary>
        ///     Gets or sets the secondary address unit designator, such as APARTMENT or SUITE, are required to be printed on the
        ///     mailpiece for address locations containing secondary unit designators. The preferred location is at the end of the
        ///     Delivery Address Line. The
        /// </summary>
        /// <value>
        ///     The unit.
        /// </value>
        public string Unit { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        ///     Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        ///     A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            string[] values = {this.Number, this.Fraction, this.PreDirectional, this.Street, this.Suffix, this.PostDirectional, this.Unit};
            StringBuilder sb = new StringBuilder(values.Length);
            string s = null;
            foreach (var v in values)
            {
                if (!string.IsNullOrEmpty(v))
                {
                    sb.Append(s);
                    sb.Append(v);
                    s = " ";
                }
            }

            return sb.ToString().Trim();
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Tries the parse the data into the correct format.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <returns>
        /// Returns <see cref="string" /> representing the parsed value.
        /// </returns>
        protected override string Parse(List<Match> collection)
        {
            if (collection.Count > 0)
            {
                // When parsing the into the individual components, start from the right-most element of the address and work
                // toward the left.
                var reverse = collection.Cast<Match>().Reverse().ToList();

                if (Highway.Is(collection))
                {
                    string highway = AddressDescriptor.Parse<Highway>(reverse);

                    this.PreDirectional = AddressDescriptor.Parse<Direction>(reverse);
                    this.Street = string.Concat(AddressDescriptor.Parse<Street>(reverse), " ", highway).Trim();
                    
                    if(string.IsNullOrEmpty(this.PreDirectional))
                        this.PreDirectional = AddressDescriptor.Parse<Direction>(reverse);

                    this.Number = AddressDescriptor.Parse<Number>(reverse);
                }
                else
                {
                    this.Unit = AddressDescriptor.Parse<UnitDesignator>(reverse);
                    this.PostDirectional = AddressDescriptor.Parse<Direction>(reverse);
                    this.Suffix = AddressDescriptor.Parse<Suffix>(reverse);
                    this.Street = AddressDescriptor.Parse<Street>(reverse);
                    this.PreDirectional = AddressDescriptor.Parse<Direction>(reverse);
                    this.Fraction = AddressDescriptor.Parse<Fraction>(reverse);
                    this.Number = AddressDescriptor.Parse<Number>(reverse);
                    
                }
            }

            return this.ToString();
        }

        #endregion        
    }
}