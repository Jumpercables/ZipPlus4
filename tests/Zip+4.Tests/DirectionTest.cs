using Microsoft.VisualStudio.TestTools.UnitTesting;

using ZipPlus4.Model;

namespace ZipPlus4.Tests
{
    [TestClass]
    public class DirectionTest
    {
        #region Public Methods

        [TestMethod]
        public void Direction_E()
        {
            var value = Address.Parse<Direction>("E");
            Assert.AreEqual("E", value);
        }

        [TestMethod]
        public void Direction_East()
        {
            var value = Address.Parse<Direction>("East");
            Assert.AreEqual("E", value);
        }

        [TestMethod]
        public void Direction_N()
        {
            var value = Address.Parse<Direction>("N");
            Assert.AreEqual("N", value);
        }

        [TestMethod]
        public void Direction_North()
        {
            var value = Address.Parse<Direction>("North");
            Assert.AreEqual("N", value);
        }

        [TestMethod]
        public void Direction_Northeast()
        {
            var value = Address.Parse<Direction>("Northeast");
            Assert.AreEqual("NE", value);
        }

        [TestMethod]
        public void Direction_Northwest()
        {
            var value = Address.Parse<Direction>("Northwest");
            Assert.AreEqual("NW", value);
        }

        [TestMethod]
        public void Direction_S()
        {
            var value = Address.Parse<Direction>("S");
            Assert.AreEqual("S", value);
        }

        [TestMethod]
        public void Direction_South()
        {
            var value = Address.Parse<Direction>("South");
            Assert.AreEqual("S", value);
        }

        [TestMethod]
        public void Direction_Southeast()
        {
            var value = Address.Parse<Direction>("Southeast");
            Assert.AreEqual("SE", value);
        }

        [TestMethod]
        public void Direction_Southwest()
        {
            var value = Address.Parse<Direction>("Southwest");
            Assert.AreEqual("SW", value);
        }

        [TestMethod]
        public void Direction_W()
        {
            var value = Address.Parse<Direction>("W");
            Assert.AreEqual("W", value);
        }

        [TestMethod]
        public void Direction_West()
        {
            var value = Address.Parse<Direction>("West");
            Assert.AreEqual("W", value);
        }

        #endregion
    }
}