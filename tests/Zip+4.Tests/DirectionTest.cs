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
            var value = AddressDescriptor.Parse<Direction>("E");
            Assert.AreEqual("E", value);
        }

        [TestMethod]
        public void Direction_East()
        {
            var value = AddressDescriptor.Parse<Direction>("East");
            Assert.AreEqual("E", value);
        }

        [TestMethod]
        public void Direction_N()
        {
            var value = AddressDescriptor.Parse<Direction>("N");
            Assert.AreEqual("N", value);
        }

        [TestMethod]
        public void Direction_North()
        {
            var value = AddressDescriptor.Parse<Direction>("North");
            Assert.AreEqual("N", value);
        }

        [TestMethod]
        public void Direction_Northeast()
        {
            var value = AddressDescriptor.Parse<Direction>("Northeast");
            Assert.AreEqual("NE", value);
        }

        [TestMethod]
        public void Direction_Northwest()
        {
            var value = AddressDescriptor.Parse<Direction>("Northwest");
            Assert.AreEqual("NW", value);
        }

        [TestMethod]
        public void Direction_S()
        {
            var value = AddressDescriptor.Parse<Direction>("S");
            Assert.AreEqual("S", value);
        }

        [TestMethod]
        public void Direction_South()
        {
            var value = AddressDescriptor.Parse<Direction>("South");
            Assert.AreEqual("S", value);
        }

        [TestMethod]
        public void Direction_Southeast()
        {
            var value = AddressDescriptor.Parse<Direction>("Southeast");
            Assert.AreEqual("SE", value);
        }

        [TestMethod]
        public void Direction_Southwest()
        {
            var value = AddressDescriptor.Parse<Direction>("Southwest");
            Assert.AreEqual("SW", value);
        }

        [TestMethod]
        public void Direction_W()
        {
            var value = AddressDescriptor.Parse<Direction>("W");
            Assert.AreEqual("W", value);
        }

        [TestMethod]
        public void Direction_West()
        {
            var value = AddressDescriptor.Parse<Direction>("West");
            Assert.AreEqual("W", value);
        }

        #endregion
    }
}