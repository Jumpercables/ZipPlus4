using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZipPlus4.Tests
{
    [TestClass]
    public class StateTest
    {
        #region Public Methods

        [TestMethod]
        public void State_CO()
        {
            var value = AddressDescriptor.Parse<State>("CO");
            Assert.AreEqual("CO", value);
        }

        [TestMethod]
        public void State_Col()
        {
            var value = AddressDescriptor.Parse<State>("Col");
            Assert.AreEqual(null, value);
        }

        [TestMethod]
        public void State_Colo()
        {
            var value = AddressDescriptor.Parse<State>("Colo");
            Assert.AreEqual(null, value);
        }

        [TestMethod]
        public void State_Color()
        {
            var value = AddressDescriptor.Parse<State>("Color");
            Assert.AreEqual(null, value);
        }

        [TestMethod]
        public void State_Colora()
        {
            var value = AddressDescriptor.Parse<State>("Colora");
            Assert.AreEqual("CO", value);
        }

        [TestMethod]
        public void State_Colorad()
        {
            var value = AddressDescriptor.Parse<State>("Colorad");
            Assert.AreEqual("CO", value);
        }

        [TestMethod]
        public void State_Colorado()
        {
            var value = AddressDescriptor.Parse<State>("Colorado");
            Assert.AreEqual("CO", value);
        }

        #endregion
    }
}