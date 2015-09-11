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
            var value = AddressVerb.Parse<State>("CO");
            Assert.AreEqual("CO", value);
        }

        [TestMethod]
        public void State_Col()
        {
            var value = AddressVerb.Parse<State>("Col");
            Assert.AreEqual(null, value);
        }

        [TestMethod]
        public void State_Colo()
        {
            var value = AddressVerb.Parse<State>("Colo");
            Assert.AreEqual(null, value);
        }

        [TestMethod]
        public void State_Color()
        {
            var value = AddressVerb.Parse<State>("Color");
            Assert.AreEqual(null, value);
        }

        [TestMethod]
        public void State_Colora()
        {
            var value = AddressVerb.Parse<State>("Colora");
            Assert.AreEqual("CO", value);
        }

        [TestMethod]
        public void State_Colorad()
        {
            var value = AddressVerb.Parse<State>("Colorad");
            Assert.AreEqual("CO", value);
        }

        [TestMethod]
        public void State_Colorado()
        {
            var value = AddressVerb.Parse<State>("Colorado");
            Assert.AreEqual("CO", value);
        }

        #endregion
    }
}