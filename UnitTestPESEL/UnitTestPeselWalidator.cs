using Microsoft.VisualStudio.TestTools.UnitTesting;
using PESEL;
using System;

namespace UnitTestPESEL
{
    [TestClass]
    public class UnitTestPeselWalidator
    {
        PeselWalidator walidator1;
        PeselWalidator walidator2;

        [TestInitialize]
        public void PodaniePeselDlaWalidator()
        {
            walidator1 = new PeselWalidator("91100104422");
            walidator2 = new PeselWalidator("05251200566");
        }
        [TestMethod]
        public void TestWalidator_PoprawnyPesel()
        {
            bool wynik = walidator1.SprawdzPesel("91100104422");
            Assert.IsTrue(wynik);
        }

        [TestMethod]
        public void TestWalidator_KrotkiPesel()
        {
            bool wynik = walidator1.SprawdzPesel("9504422");
            Assert.IsFalse(wynik);
        }

        [TestMethod]
        public void TestWalidator_DlugiPesel()
        {
            bool wynik = walidator1.SprawdzPesel("9110010442291100104422");
            Assert.IsFalse(wynik);
        }

        [TestMethod]
        public void TestWalidator_NiepoprawnyPesel()
        {
            bool wynik = walidator1.SprawdzPesel("911oo1o4422");
            Assert.IsFalse(wynik);
        }

        [TestMethod]
        public void TestWalidator_PoprawnaPlec()
        {
            string wynik = walidator1.Plec();
            Assert.AreEqual("K", wynik);
        }

        [TestMethod]
        public void TestWalidator_PoprawnaData()
        {
            string wynik = walidator1.DataUrodzenia();
            Assert.AreEqual("01/10/1991", wynik);
        }

        [TestMethod]
        public void TestWalidator_PoprawnaSumaKontrolna()
        {
            int wynik = walidator1.SumaKontrolna();
            Assert.AreEqual(2, wynik);
        }

        [TestMethod]
        public void TestWalidator_PoprawnaPlecMilenium()
        {
            string wynik = walidator2.Plec();
            Assert.AreEqual("K", wynik);
        }

        [TestMethod]
        public void TestWalidator_PoprawnaDataMilenium()
        {
            string wynik = walidator2.DataUrodzenia();
            Assert.AreEqual("12/05/2005", wynik);
        }

        [TestMethod]
        public void TestWalidator_PoprawnaSumaKontrolnaMilenium()
        {
            int wynik = walidator2.SumaKontrolna();
            Assert.AreEqual(6, wynik);
        }

        [TestMethod]
        public void TestWalidator_NiepoprawnaPlec()
        {
            string wynik = walidator1.Plec();
            Assert.AreNotEqual("M", wynik);
        }

        [TestMethod]
        public void TestWalidator_NiepoprawnaData()
        {
            string wynik = walidator1.DataUrodzenia();
            Assert.AreNotEqual("01.10.2091", wynik);
        }

        [TestMethod]
        public void TestWalidator_NiepoprawnaSumaKontrolna()
        {
            int wynik = walidator1.SumaKontrolna();
            Assert.AreNotEqual(8, wynik);
        }
    }
}

