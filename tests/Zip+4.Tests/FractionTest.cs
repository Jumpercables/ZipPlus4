using Microsoft.VisualStudio.TestTools.UnitTesting;

using ZipPlus4.Model;

namespace ZipPlus4.Tests
{
    [TestClass]
    public class FractionTest
    {
        #region Public Methods

        [TestMethod]
        public void Fraction_SlashOnly()
        {
            var value = Address.Parse<Fraction>("/");

            Assert.AreEqual(null, value);
        }

        [TestMethod]
        public void Fraction_DenominatorOnly()
        {
            var value = Address.Parse<Fraction>("/2");

            Assert.AreEqual(null, value);
        }

        [TestMethod]
        public void Fraction_NumeratorOnly()
        {
            var value = Address.Parse<Fraction>("1/");
            
            Assert.AreEqual(null, value);
        }

        [TestMethod]
        public void Fraction_NumeratorAndDenomiator()
        {
            var value = Address.Parse<Fraction>("1/2");

            Assert.AreEqual("1/2", value);
        }

        #endregion
    }
}