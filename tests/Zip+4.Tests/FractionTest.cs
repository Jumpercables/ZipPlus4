﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZipPlus4.Tests
{
    [TestClass]
    public class FractionTest
    {
        #region Public Methods

        [TestMethod]
        public void Fraction_SlashOnly()
        {
            var value = AddressDescriptor.Parse<Fraction>("/");

            Assert.AreEqual(null, value);
        }

        [TestMethod]
        public void Fraction_DenominatorOnly()
        {
            var value = AddressDescriptor.Parse<Fraction>("/2");

            Assert.AreEqual(null, value);
        }

        [TestMethod]
        public void Fraction_NumeratorOnly()
        {
            var value = AddressDescriptor.Parse<Fraction>("1/");
            
            Assert.AreEqual(null, value);
        }

        [TestMethod]
        public void Fraction_NumeratorAndDenomiator()
        {
            var value = AddressDescriptor.Parse<Fraction>("1/2");

            Assert.AreEqual("1/2", value);
        }

        #endregion
    }
}