using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZipPlus4.Tests
{
    [TestClass]
    public class DirectionTest
    {
        #region Public Methods

        [TestMethod]
        public void Direction_E()
        {
            var value = AddressVerb.Parse<Direction>("E");
            Assert.AreEqual("E", value);
        }

        [TestMethod]
        public void Direction_East()
        {
            var value = AddressVerb.Parse<Direction>("East");
            Assert.AreEqual("E", value);
        }

        [TestMethod]
        public void Direction_N()
        {
            var value = AddressVerb.Parse<Direction>("N");
            Assert.AreEqual("N", value);
        }

        [TestMethod]
        public void Direction_North()
        {
            var value = AddressVerb.Parse<Direction>("North");
            Assert.AreEqual("N", value);
        }

        [TestMethod]
        public void Direction_Northeast()
        {
            var value = AddressVerb.Parse<Direction>("Northeast");
            Assert.AreEqual("NE", value);
        }

        [TestMethod]
        public void Direction_Northwest()
        {
            var value = AddressVerb.Parse<Direction>("Northwest");
            Assert.AreEqual("NW", value);
        }

        [TestMethod]
        public void Direction_S()
        {
            var value = AddressVerb.Parse<Direction>("S");
            Assert.AreEqual("S", value);
        }

        [TestMethod]
        public void Direction_South()
        {
            var value = AddressVerb.Parse<Direction>("South");
            Assert.AreEqual("S", value);
        }

        [TestMethod]
        public void Direction_Southeast()
        {
            var value = AddressVerb.Parse<Direction>("Southeast");
            Assert.AreEqual("SE", value);
        }

        [TestMethod]
        public void Direction_Southwest()
        {
            var value = AddressVerb.Parse<Direction>("Southwest");
            Assert.AreEqual("SW", value);
        }

        [TestMethod]
        public void Direction_W()
        {
            var value = AddressVerb.Parse<Direction>("W");
            Assert.AreEqual("W", value);
        }

        [TestMethod]
        public void Direction_West()
        {
            var value = AddressVerb.Parse<Direction>("West");
            Assert.AreEqual("W", value);
        }

        #endregion
    }
}