using Microsoft.VisualStudio.TestTools.UnitTesting;

using ZipPlus4.Model;

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
            var value = Address.Parse<Number>("101");
            Assert.AreEqual("101", value);
        }
        
        #endregion
    }
}