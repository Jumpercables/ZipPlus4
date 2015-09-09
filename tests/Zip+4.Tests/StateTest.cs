using Microsoft.VisualStudio.TestTools.UnitTesting;

using ZipPlus4.Model;

namespace ZipPlus4.Tests
{
    [TestClass]
    public class StateTest
    {
        #region Public Methods

        [TestMethod]
        public void State_CO()
        {
            var value = Address.Parse<State>("CO");
            Assert.AreEqual("CO", value);
        }

        [TestMethod]
        public void State_Col()
        {
            var value = Address.Parse<State>("Col");
            Assert.AreEqual(null, value);
        }

        [TestMethod]
        public void State_Colo()
        {
            var value = Address.Parse<State>("Colo");
            Assert.AreEqual(null, value);
        }

        [TestMethod]
        public void State_Color()
        {
            var value = Address.Parse<State>("Color");
            Assert.AreEqual(null, value);
        }

        [TestMethod]
        public void State_Colora()
        {
            var value = Address.Parse<State>("Colora");
            Assert.AreEqual("CO", value);
        }

        [TestMethod]
        public void State_Colorad()
        {
            var value = Address.Parse<State>("Colorad");
            Assert.AreEqual("CO", value);
        }

        [TestMethod]
        public void State_Colorado()
        {
            var value = Address.Parse<State>("Colorado");
            Assert.AreEqual("CO", value);
        }

        #endregion
    }
}