using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZipPlus4.Tests
{
    [TestClass]
    public class DeliveryAddressTest
    {
        // "NEWTON AVE  BETWEEN CEASER CHAVEZ AND DEWEY"
        // "1529 ROSE ST. N/O CHERRY PL."
        // "276 N. EL CAMINO REAL # 51"
        // "4125 PACIFIC HWY"
        // "REC ROOM CAMINITO CORRIENTE"
        // 

        #region Public Methods
        
        [TestMethod]
        public void DeliveryAddress_DirectonalAsPartOfStreet()
        {
            var value = PostalAddress.Parse<StandardAddress>("BAY WEST DR");
            Assert.AreEqual(null, value.Number);
            Assert.AreEqual(null, value.Fraction);
            Assert.AreEqual(null, value.PreDirectional);
            Assert.AreEqual("BAY WEST", value.Street);
            Assert.AreEqual(null, value.PostDirectional);
            Assert.AreEqual("DR", value.Suffix);
        }

        [TestMethod]
        public void DeliveryAddress_HighwayEndsWithNumber()
        {
            var value = PostalAddress.Parse<StandardAddress>("15417 OLD HWY 80");
            Assert.AreEqual("15417", value.Number);
            Assert.AreEqual(null, value.Fraction);
            Assert.AreEqual(null, value.PreDirectional);
            Assert.AreEqual("OLD HWY 80", value.Street);
            Assert.AreEqual(null, value.PostDirectional);
            Assert.AreEqual(null, value.Suffix);
        }

        [TestMethod]
        public void DeliveryAddress_HighwayWithPerDirectionalEndsWithNumber()
        {
            var value = PostalAddress.Parse<StandardAddress>("1010 S.COAST HWY 101");
            Assert.AreEqual("1010", value.Number);
            Assert.AreEqual(null, value.Fraction);
            Assert.AreEqual(null, value.PreDirectional);
            Assert.AreEqual("S COAST HWY 101", value.Street);
            Assert.AreEqual(null, value.PostDirectional);
            Assert.AreEqual(null, value.Suffix);
        }

        [TestMethod]
        public void DeliveryAddress_HighwayWithPerDirectionalWithoutSuffixEndsWithNumber()
        {
            var value = PostalAddress.Parse<StandardAddress>("1604 N.COAST 101");
            Assert.AreEqual("1604", value.Number);
            Assert.AreEqual(null, value.Fraction);
            Assert.AreEqual(null, value.PreDirectional);
            Assert.AreEqual("N COAST 101", value.Street);
            Assert.AreEqual(null, value.PostDirectional);
            Assert.AreEqual(null, value.Suffix);
        }

        [TestMethod]
        public void DeliveryAddress_MalformedFraction()
        {
            var value = PostalAddress.Parse<StandardAddress>("3456 3/ E 7TH ST");
            Assert.AreEqual("3456", value.Number);
            Assert.AreEqual(null, value.Fraction);
            Assert.AreEqual("E", value.PreDirectional);
            Assert.AreEqual("7TH", value.Street);
            Assert.AreEqual(null, value.PostDirectional);
            Assert.AreEqual("ST", value.Suffix);
        }

        [TestMethod]
        public void DeliveryAddress_NumberAndFractionAndStreetAndSuffixAndPostDirectional()
        {
            var value = PostalAddress.Parse<StandardAddress>("5613 1/2 HUNTINGTON DR N");
            Assert.AreEqual("5613", value.Number);
            Assert.AreEqual("1/2", value.Fraction);
            Assert.AreEqual(null, value.PreDirectional);
            Assert.AreEqual("HUNTINGTON", value.Street);
            Assert.AreEqual("DR", value.Suffix);
            Assert.AreEqual("N", value.PostDirectional);
        }

        [TestMethod]
        public void DeliveryAddress_NumberAndPreDirectionalAndStreetAndSuffixAndPostDirectional()
        {
            var value = PostalAddress.Parse<StandardAddress>("1031 W GARVEY AVE N");
            Assert.AreEqual("1031", value.Number);
            Assert.AreEqual(null, value.Fraction);
            Assert.AreEqual("W", value.PreDirectional);
            Assert.AreEqual("GARVEY", value.Street);
            Assert.AreEqual("AVE", value.Suffix);
            Assert.AreEqual("N", value.PostDirectional);
        }


        [TestMethod]
        public void DeliveryAddress_NumberAndStreetAndSuffix()
        {
            var value = PostalAddress.Parse<StandardAddress>("49 Alvarado RD");
            Assert.AreEqual("49", value.Number);
            Assert.AreEqual(null, value.Fraction);
            Assert.AreEqual(null, value.PreDirectional);
            Assert.AreEqual("ALVARADO", value.Street);
            Assert.AreEqual(null, value.PostDirectional);
            Assert.AreEqual("RD", value.Suffix);
        }


        [TestMethod]
        public void DeliveryAddress_NumberAndStreetAndSuffixPeriod()
        {
            var value = PostalAddress.Parse<StandardAddress>("5148 63rd St.");
            Assert.AreEqual("5148", value.Number);
            Assert.AreEqual(null, value.Fraction);
            Assert.AreEqual(null, value.PreDirectional);
            Assert.AreEqual("63RD", value.Street);
            Assert.AreEqual(null, value.PostDirectional);
            Assert.AreEqual("ST", value.Suffix);
        }

        [TestMethod]
        public void DeliveryAddress_NumberAndTwoStreetsAndSuffix()
        {
            var value = PostalAddress.Parse<StandardAddress>("2002 JIMMY DURANTE BOULEVARD");
            Assert.AreEqual("2002", value.Number);
            Assert.AreEqual(null, value.Fraction);
            Assert.AreEqual(null, value.PreDirectional);
            Assert.AreEqual("JIMMY DURANTE", value.Street);
            Assert.AreEqual(null, value.PostDirectional);
            Assert.AreEqual("BLVD", value.Suffix);
        }

        [TestMethod]
        public void DeliveryAddress_NumberRange()
        {
            var value = PostalAddress.Parse<StandardAddress>("1173-1175 FLORIDA STREET");
            Assert.AreEqual("1173", value.Number);
            Assert.AreEqual(null, value.Fraction);
            Assert.AreEqual(null, value.PreDirectional);
            Assert.AreEqual("FLORIDA", value.Street);
            Assert.AreEqual(null, value.PostDirectional);
            Assert.AreEqual("ST", value.Suffix);
        }

        [TestMethod]
        public void DeliveryAddress_SingleLetterStreet()
        {
            var value = PostalAddress.Parse<StandardAddress>("2776 B ST");
            Assert.AreEqual("2776", value.Number);
            Assert.AreEqual(null, value.Fraction);
            Assert.AreEqual(null, value.PreDirectional);
            Assert.AreEqual("B", value.Street);
            Assert.AreEqual(null, value.PostDirectional);
            Assert.AreEqual("ST", value.Suffix);
        }

        [TestMethod]
        public void DeliveryAddress_SuffixAsPartOfStreet()
        {
            var value = PostalAddress.Parse<StandardAddress>("213 ALLEY S AVE");
            Assert.AreEqual("213", value.Number);
            Assert.AreEqual(null, value.Fraction);
            Assert.AreEqual(null, value.PreDirectional);
            Assert.AreEqual("ALLEY S", value.Street);
            Assert.AreEqual(null, value.PostDirectional);
            Assert.AreEqual("AVE", value.Suffix);
        }

        [TestMethod]
        public void DeliveryAddress_TwoSuffixesWithNumber()
        {
            var value = PostalAddress.Parse<StandardAddress>("1370 OAK DR FOOTHILL DR");
            Assert.AreEqual("1370", value.Number);
            Assert.AreEqual(null, value.Fraction);
            Assert.AreEqual(null, value.PreDirectional);
            Assert.AreEqual("OAK DR FOOTHILL", value.Street);
            Assert.AreEqual(null, value.PostDirectional);
            Assert.AreEqual("DR", value.Suffix);
        }

        [TestMethod]
        public void DeliveryAddress_TwoSuffixesWithoutNumber()
        {
            var value = PostalAddress.Parse<StandardAddress>("ROSE FLOWER DR. S/O SUNFLPWER ST.");
            Assert.AreEqual(null, value.Number);
            Assert.AreEqual(null, value.Fraction);
            Assert.AreEqual(null, value.PreDirectional);
            Assert.AreEqual("ROSE FLOWER DR S SUNFLPWER", value.Street);
            Assert.AreEqual(null, value.PostDirectional);
            Assert.AreEqual("ST", value.Suffix);
        }

        #endregion
    }
}