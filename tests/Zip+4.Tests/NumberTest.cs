using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZipPlus4.Tests
{
    /// <summary>
    ///     Summary description for NumberTest
    /// </summary>
    [TestClass]
    public class NumberTest
    {
        #region Public Methods

        [TestMethod]
        public void Number_Numeric()
        {
            var value = AddressVerb.Parse<Number>("101");
            Assert.AreEqual("101", value);
        }
        
        #endregion
    }
}