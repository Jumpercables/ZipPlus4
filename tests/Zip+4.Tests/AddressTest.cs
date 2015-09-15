using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZipPlus4.Tests
{
    [TestClass]
    public class AddressTest
    {
        // "NEWTON AVE  BETWEEN CEASER CHAVEZ AND DEWEY"
        // "1529 ROSE ST. N/O CHERRY PL."
        // "276 N. EL CAMINO REAL # 51"
        // "4125 PACIFIC HWY"
        // "REC ROOM CAMINITO CORRIENTE"
        // 4326 AND  4316 LONGBRANCH AVENUE

        #region Public Methods

        [TestMethod]
        public void Address_BusinessAddress()
        {
            var value = Address.Parse<PostalAddress>("REC ROOM CAMINITO CORRIENTE");
            Assert.AreEqual(null, value.Number);
            Assert.AreEqual(null, value.Fraction);
            Assert.AreEqual(null, value.PreDirectional);
            Assert.AreEqual("REC ROOM CAMINITO CORRIENTE", value.Street);
            Assert.AreEqual(null, value.PostDirectional);
            Assert.AreEqual(null, value.Suffix);
        }

        [TestMethod]
        public void Address_CrossStreetAnd()
        {
            var value = Address.Parse<PostalAddress>("4326 AND 4316  LONGBRANCH AVENUE");
            Assert.AreEqual("4316", value.Number);
            Assert.AreEqual(null, value.Fraction);
            Assert.AreEqual(null, value.PreDirectional);
            Assert.AreEqual("LONGBRANCH", value.Street);
            Assert.AreEqual(null, value.PostDirectional);
            Assert.AreEqual("AVE", value.Suffix);
        }

        [TestMethod]
        public void Address_CrossStreetSlash()
        {
            var value = Address.Parse<PostalAddress>("1370 Oak Dr./ Foothill Dr.");
            Assert.AreEqual("1370", value.Number);
            Assert.AreEqual(null, value.Fraction);
            Assert.AreEqual(null, value.PreDirectional);
            Assert.AreEqual("FOOTHILL", value.Street);
            Assert.AreEqual(null, value.PostDirectional);
            Assert.AreEqual("DR", value.Suffix);
        }

        [TestMethod]
        public void Address_DirectonalAsPartOfStreet()
        {
            var value = Address.Parse<PostalAddress>("BAY WEST DR");
            Assert.AreEqual(null, value.Number);
            Assert.AreEqual(null, value.Fraction);
            Assert.AreEqual(null, value.PreDirectional);
            Assert.AreEqual("BAY WEST", value.Street);
            Assert.AreEqual(null, value.PostDirectional);
            Assert.AreEqual("DR", value.Suffix);
        }

        [TestMethod]
        public void Address_HighwayNoNumber()
        {
            var value = Address.Parse<PostalAddress>("4125 PACIFIC HWY");
            Assert.AreEqual("4125", value.Number);
            Assert.AreEqual(null, value.Fraction);
            Assert.AreEqual(null, value.PreDirectional);
            Assert.AreEqual("PACIFIC", value.Street);
            Assert.AreEqual(null, value.PostDirectional);
            Assert.AreEqual("HWY", value.Suffix);
            Assert.AreEqual(null, value.Unit);
        }

        [TestMethod]
        public void Address_HighwayNumber()
        {
            var value = Address.Parse<PostalAddress>("15417 OLD HWY 80");
            Assert.AreEqual("15417", value.Number);
            Assert.AreEqual(null, value.Fraction);
            Assert.AreEqual(null, value.PreDirectional);
            Assert.AreEqual("OLD HIGHWAY 80", value.Street);
            Assert.AreEqual(null, value.PostDirectional);
            Assert.AreEqual(null, value.Suffix);
        }

        [TestMethod]
        public void Address_HighwayPerDirectionalAndNumber()
        {
            var value = Address.Parse<PostalAddress>("1010 S.COAST HWY 101");
            Assert.AreEqual("1010", value.Number);
            Assert.AreEqual(null, value.Fraction);
            Assert.AreEqual("S", value.PreDirectional);
            Assert.AreEqual("COAST HIGHWAY 101", value.Street);
            Assert.AreEqual(null, value.PostDirectional);
            Assert.AreEqual(null, value.Suffix);
        }

        [TestMethod]
        public void Address_HighwayWithPerDirectionalWithoutSuffixEndsWithNumber()
        {
            var value = Address.Parse<PostalAddress>("1604 N.COAST 101");
            Assert.AreEqual("1604", value.Number);
            Assert.AreEqual(null, value.Fraction);
            Assert.AreEqual("N", value.PreDirectional);
            Assert.AreEqual("COAST HIGHWAY 101", value.Street);
            Assert.AreEqual(null, value.PostDirectional);
            Assert.AreEqual(null, value.Suffix);
        }

        [TestMethod]
        public void Address_MalformedFraction()
        {
            var value = Address.Parse<PostalAddress>("3456 3/ E 7TH ST");
            Assert.AreEqual("3456", value.Number);
            Assert.AreEqual(null, value.Fraction);
            Assert.AreEqual("E", value.PreDirectional);
            Assert.AreEqual("7TH", value.Street);
            Assert.AreEqual(null, value.PostDirectional);
            Assert.AreEqual("ST", value.Suffix);
        }

        [TestMethod]
        public void Address_NumberAndFractionAndStreetAndSuffixAndPostDirectional()
        {
            var value = Address.Parse<PostalAddress>("5613 1/2 HUNTINGTON DR N");
            Assert.AreEqual("5613", value.Number);
            Assert.AreEqual("1/2", value.Fraction);
            Assert.AreEqual(null, value.PreDirectional);
            Assert.AreEqual("HUNTINGTON", value.Street);
            Assert.AreEqual("DR", value.Suffix);
            Assert.AreEqual("N", value.PostDirectional);
        }

        [TestMethod]
        public void Address_NumberAndPreDirectionalAndStreetAndSuffixAndPostDirectional()
        {
            var value = Address.Parse<PostalAddress>("1031 W GARVEY AVE N");
            Assert.AreEqual("1031", value.Number);
            Assert.AreEqual(null, value.Fraction);
            Assert.AreEqual("W", value.PreDirectional);
            Assert.AreEqual("GARVEY", value.Street);
            Assert.AreEqual("AVE", value.Suffix);
            Assert.AreEqual("N", value.PostDirectional);
        }


        [TestMethod]
        public void Address_NumberAndStreetAndSuffix()
        {
            var value = Address.Parse<PostalAddress>("49 Alvarado RD");
            Assert.AreEqual("49", value.Number);
            Assert.AreEqual(null, value.Fraction);
            Assert.AreEqual(null, value.PreDirectional);
            Assert.AreEqual("ALVARADO", value.Street);
            Assert.AreEqual(null, value.PostDirectional);
            Assert.AreEqual("RD", value.Suffix);
        }


        [TestMethod]
        public void Address_NumberAndStreetAndSuffixPeriod()
        {
            var value = Address.Parse<PostalAddress>("5148 63rd St.");
            Assert.AreEqual("5148", value.Number);
            Assert.AreEqual(null, value.Fraction);
            Assert.AreEqual(null, value.PreDirectional);
            Assert.AreEqual("63RD", value.Street);
            Assert.AreEqual(null, value.PostDirectional);
            Assert.AreEqual("ST", value.Suffix);
        }

        [TestMethod]
        public void Address_NumberAndTwoStreetsAndSuffix()
        {
            var value = Address.Parse<PostalAddress>("2002 JIMMY DURANTE BOULEVARD");
            Assert.AreEqual("2002", value.Number);
            Assert.AreEqual(null, value.Fraction);
            Assert.AreEqual(null, value.PreDirectional);
            Assert.AreEqual("JIMMY DURANTE", value.Street);
            Assert.AreEqual(null, value.PostDirectional);
            Assert.AreEqual("BLVD", value.Suffix);
        }

        [TestMethod]
        public void Address_SpanishPrefix()
        {
            var value = Address.Parse<PostalAddress>("3727 CM CIELO DEL MAR");
            Assert.AreEqual("3727", value.Number);
            Assert.AreEqual(null, value.Fraction);
            Assert.AreEqual(null, value.PreDirectional);
            Assert.AreEqual("CAMINITO CIELO DEL MAR", value.Street);
            Assert.AreEqual(null, value.PostDirectional);
            Assert.AreEqual(null, value.Suffix);
        }
        [TestMethod]
        public void Address_NumberNumberStreet()
        {
            var value = Address.Parse<PostalAddress>("3711 41 street");
            Assert.AreEqual("3711", value.Number);
            Assert.AreEqual(null, value.Fraction);
            Assert.AreEqual(null, value.PreDirectional);
            Assert.AreEqual("41", value.Street);
            Assert.AreEqual(null, value.PostDirectional);
            Assert.AreEqual("ST", value.Suffix);
        }

        [TestMethod]
        public void Address_NumberRangeTakeFist()
        {
            var value = Address.Parse<PostalAddress>("1173-1175 FLORIDA STREET");
            Assert.AreEqual("1173", value.Number);
            Assert.AreEqual(null, value.Fraction);
            Assert.AreEqual(null, value.PreDirectional);
            Assert.AreEqual("FLORIDA", value.Street);
            Assert.AreEqual(null, value.PostDirectional);
            Assert.AreEqual("ST", value.Suffix);
        }

        [TestMethod]
        public void Address_StreetSingleWord()
        {
            var value = Address.Parse<PostalAddress>("2776 B ST");
            Assert.AreEqual("2776", value.Number);
            Assert.AreEqual(null, value.Fraction);
            Assert.AreEqual(null, value.PreDirectional);
            Assert.AreEqual("B", value.Street);
            Assert.AreEqual(null, value.PostDirectional);
            Assert.AreEqual("ST", value.Suffix);
        }

        [TestMethod]
        public void Address_SuffixAsPartOfStreet()
        {
            var value = Address.Parse<PostalAddress>("213 ALLEY S AVE");
            Assert.AreEqual("213", value.Number);
            Assert.AreEqual(null, value.Fraction);
            Assert.AreEqual(null, value.PreDirectional);
            Assert.AreEqual("ALLEY S", value.Street);
            Assert.AreEqual(null, value.PostDirectional);
            Assert.AreEqual("AVE", value.Suffix);
        }

        [TestMethod]
        public void Address_TwoStreets()
        {
            var value = Address.Parse<PostalAddress>("1695 Live Oak Rd . N/O Melrose Dr.");
            Assert.AreEqual("1695", value.Number);
            Assert.AreEqual(null, value.Fraction);
            Assert.AreEqual(null, value.PreDirectional);
            Assert.AreEqual("MELROSE", value.Street);
            Assert.AreEqual(null, value.PostDirectional);
            Assert.AreEqual("DR", value.Suffix);
            Assert.AreEqual(null, value.Unit);
        }

        [TestMethod]
        public void Address_TwoSuffixesWithNumber()
        {
            var value = Address.Parse<PostalAddress>("1370 OAK DR FOOTHILL DR");
            Assert.AreEqual("1370", value.Number);
            Assert.AreEqual(null, value.Fraction);
            Assert.AreEqual(null, value.PreDirectional);
            Assert.AreEqual("OAK DR FOOTHILL", value.Street);
            Assert.AreEqual(null, value.PostDirectional);
            Assert.AreEqual("DR", value.Suffix);
        }

        [TestMethod]
        public void Address_TwoSuffixesWithoutNumber()
        {
            var value = Address.Parse<PostalAddress>("ROSE FLOWER DR. S/O SUNFLPWER ST.");
            Assert.AreEqual(null, value.Number);
            Assert.AreEqual(null, value.Fraction);
            Assert.AreEqual(null, value.PreDirectional);
            Assert.AreEqual("SUNFLPWER", value.Street);
            Assert.AreEqual(null, value.PostDirectional);
            Assert.AreEqual("ST", value.Suffix);
        }

        [TestMethod]
        public void Address_UnitApartmentNumber()
        {
            var value = Address.Parse<PostalAddress>("276 N EL CAMINO REAL APT 51");
            Assert.AreEqual("276", value.Number);
            Assert.AreEqual(null, value.Fraction);
            Assert.AreEqual("N", value.PreDirectional);
            Assert.AreEqual("EL CAMINO REAL", value.Street);
            Assert.AreEqual(null, value.PostDirectional);
            Assert.AreEqual(null, value.Suffix);
            Assert.AreEqual("APT 51", value.Unit);
        }

        [TestMethod]
        public void Address_UnitMisspellingBy1()
        {
            var value = Address.Parse<PostalAddress>("8550 Westmore Road appartment 257");
            Assert.AreEqual("8550", value.Number);
            Assert.AreEqual(null, value.Fraction);
            Assert.AreEqual(null, value.PreDirectional);
            Assert.AreEqual("WESTMORE", value.Street);
            Assert.AreEqual(null, value.PostDirectional);
            Assert.AreEqual("RD", value.Suffix);
            Assert.AreEqual("APT 257", value.Unit);
        }


        [TestMethod]
        public void Address_UnitOneLetter()
        {
            var value = Address.Parse<PostalAddress>("4949 CORONADO AVE. UNIT D");
            Assert.AreEqual("4949", value.Number);
            Assert.AreEqual(null, value.Fraction);
            Assert.AreEqual(null, value.PreDirectional);
            Assert.AreEqual("CORONADO", value.Street);
            Assert.AreEqual(null, value.PostDirectional);
            Assert.AreEqual("AVE", value.Suffix);
            Assert.AreEqual("UNIT D", value.Unit);
        }


        [TestMethod]
        public void Address_UnitPoundSignNoSpaceNumber()
        {
            var value = Address.Parse<PostalAddress>("276 N. EL CAMINO REAL #51");
            Assert.AreEqual("276", value.Number);
            Assert.AreEqual(null, value.Fraction);
            Assert.AreEqual("N", value.PreDirectional);
            Assert.AreEqual("EL CAMINO REAL", value.Street);
            Assert.AreEqual(null, value.PostDirectional);
            Assert.AreEqual(null, value.Suffix);
            Assert.AreEqual("# 51", value.Unit);
        }

        [TestMethod]
        public void Address_UnitPoundSignNumber()
        {
            var value = Address.Parse<PostalAddress>("276 N. EL CAMINO REAL # 51");
            Assert.AreEqual("276", value.Number);
            Assert.AreEqual(null, value.Fraction);
            Assert.AreEqual("N", value.PreDirectional);
            Assert.AreEqual("EL CAMINO REAL", value.Street);
            Assert.AreEqual(null, value.PostDirectional);
            Assert.AreEqual(null, value.Suffix);
            Assert.AreEqual("# 51", value.Unit);
        }

        #endregion
    }
}