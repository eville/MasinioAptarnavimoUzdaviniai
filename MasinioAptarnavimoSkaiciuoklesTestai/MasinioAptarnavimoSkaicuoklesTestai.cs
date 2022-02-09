using MainioAptarnavimoUzdaviniuSkaiciuokle;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MasinioAptarnavimoSkaiciuoklesTestai
{
    [TestClass]
    public class MasinioAptarnavimoSkaicuoklesTestai
    {
        [TestMethod]
        public void VienaKanaleSuEileTikimybeApskaiciuojamaTeisingai()
        {
            // Viena kasininske, 1 pirkejas - 1 min, eileje laukia 4 zmones
            // Arrange
            var skaiciuokle = new MasinioAptarnavimoSkaiciuokle();

            // maksimali eile laukianciuju
            int maxlaukianciujuEile = 4;

            // lambda
            int paraiskuSrautoIntensyvumas = 1;

            int laikoTarpasMinutemis = 1;

            int paraiskuSrautasLaikoVieneteMinutemis = 3;

            // miu
            double paraiskuAptarnavimoIntensyvumas = (double)laikoTarpasMinutemis / (double)paraiskuSrautasLaikoVieneteMinutemis;

            // alfa
            double santykisParaiskuSrautoSuParaiskuAptarnavimoIntensyvumu = 3;

            //Paraisku atmetimo tikimybe, kai SantykisParaiskuSrautoSuParaiskuAptarnavimoIntensyvumu nelygus 1, alfa = lambda/miu
            double paraiskuAtmetimoTikimybe = 0.66758;

            // Santykine aptarnavimo geba
            double santykineAptarnavimoGeba = 0.33242;

            // Act

            // miu
            double gautasParaiskuAptarnavimoIntensyvumas = skaiciuokle.SkaiciuotiParaiskuAptarnavimoIntensyvuma(laikoTarpasMinutemis, paraiskuSrautasLaikoVieneteMinutemis);

            //alfa
            double gautasSantykisParaiskuSrautoSuParaiskuAptarnavimoIntensyvumu = skaiciuokle.SkaiciuotiSantykisParaiskuSrautoSuParaiskuAptarnavimoIntensyvumu(paraiskuSrautoIntensyvumas, gautasParaiskuAptarnavimoIntensyvumas);

            // P ats
            double gautaParaiskuAtmetimoTikimybe = skaiciuokle.skaiciuotiVienakanaleSuEileParaiksuAtmetimoTikimybe(santykisParaiskuSrautoSuParaiskuAptarnavimoIntensyvumu, maxlaukianciujuEile);

            // Santykine aptarnavimo geba, q = 1 - P ats
            double gautaSantykineAptarnavimoGeba = skaiciuokle.SkaiciuotiSantykineAptarnavimoGeba(gautaParaiskuAtmetimoTikimybe);

            // Assert
            Assert.AreEqual(gautasParaiskuAptarnavimoIntensyvumas, paraiskuAptarnavimoIntensyvumas);
            Assert.AreEqual(gautasSantykisParaiskuSrautoSuParaiskuAptarnavimoIntensyvumu, santykisParaiskuSrautoSuParaiskuAptarnavimoIntensyvumu);
            Assert.AreEqual(Math.Round(gautaParaiskuAtmetimoTikimybe, 5), paraiskuAtmetimoTikimybe);
            Assert.AreEqual(Math.Round(gautaSantykineAptarnavimoGeba, 5), santykineAptarnavimoGeba);

        }

        //
        [TestMethod]
        public void DaugiakanaleSuEileTikimybeApskaiciuojamaTeisingai()
        {
            // Viena kasininske, 1 pirkejas - 1 min, eileje laukia 4 zmones
            // Arrange
            var skaiciuokle = new MasinioAptarnavimoSkaiciuokle();

            // maksimali eile laukianciuju
            int maxlaukianciujuEile = 4;

            // lambda
            int paraiskuSrautoIntensyvumas = 1;

            int laikoTarpasMinutemis = 1;

            int paraiskuSrautasLaikoVieneteMinutemis = 3;

            // miu
            double paraiskuAptarnavimoIntensyvumas = (double)laikoTarpasMinutemis / (double)paraiskuSrautasLaikoVieneteMinutemis;

            // alfa
            double santykisParaiskuSrautoSuParaiskuAptarnavimoIntensyvumu = 3;


            // Act

            // miu
            double gautasParaiskuAptarnavimoIntensyvumas = skaiciuokle.SkaiciuotiParaiskuAptarnavimoIntensyvuma(laikoTarpasMinutemis, paraiskuSrautasLaikoVieneteMinutemis);

            //alfa
            double gautasSantykisParaiskuSrautoSuParaiskuAptarnavimoIntensyvumu = skaiciuokle.SkaiciuotiSantykisParaiskuSrautoSuParaiskuAptarnavimoIntensyvumu(paraiskuSrautoIntensyvumas, gautasParaiskuAptarnavimoIntensyvumas);

             
        }

        [DataTestMethod]
        [DataRow(0, 1)]
        [DataRow(1, 1)]
        [DataRow(10, 3628800)]
        public void SkaiciuotiFaktorialia_SkaiciuojaTesingai(int skaicius, int laukiamasFaktorialas)
        {
            // Arange

            // Act
            var paskaiciuotasFaktorialas = Faktorialas.skaiciuotiFaktorialia(skaicius);

            // Assert
            Assert.AreEqual(paskaiciuotasFaktorialas, laukiamasFaktorialas);
        }

        [TestMethod]
        public void SkaiciuotiAtmetimoTikimybe_SkaiciuojaTesingai()
        {
            // Arange
            var skaiciuokle = new MasinioAptarnavimoSkaiciuokle();
            double laukiamaPirmasDemuo = 8.5;
            double laukiamasAntrasDemuo = 54.844;
            double laukiamaAtmetimoTikimybeSu2kan = 0.3596;
            double laukiamaAtmetimoTikimybeSu3kan = 0.1452;
            double laukiamaAtmetimoTikimybeSu4kan = 0.0458;

            int maksimaliEile = 4;
            int kanaluSkaicius = 2;
            double alfa = 3;

            // Act
            var paskaiciuotasPirmasDemuo = skaiciuokle.SkaiciuotiPirmaDemeni(kanaluSkaicius, alfa);
            var paskaiciuotasAntrasDemuo = skaiciuokle.SkaiciuotiAntraDemeni(kanaluSkaicius, maksimaliEile, alfa);

            // skaiciuoti su vienakaliu
            var atmetimoTikimybeKan2 = skaiciuokle.SkaiciuotiDaugiakanaleSuEileAtmetimoTikimybe(2, maksimaliEile, alfa);
            var atmetimoTikimybeKan3 = skaiciuokle.SkaiciuotiDaugiakanaleSuEileAtmetimoTikimybe(3, maksimaliEile, alfa);
            var atmetimoTikimybeKan4 = skaiciuokle.SkaiciuotiDaugiakanaleSuEileAtmetimoTikimybe(4, maksimaliEile, alfa);
            // Assert
            Assert.AreEqual(laukiamaPirmasDemuo, paskaiciuotasPirmasDemuo);
            Assert.AreEqual(laukiamasAntrasDemuo, Math.Round(paskaiciuotasAntrasDemuo, 3));
            Assert.AreEqual(laukiamaAtmetimoTikimybeSu2kan, Math.Round(atmetimoTikimybeKan2, 4));
            Assert.AreEqual(laukiamaAtmetimoTikimybeSu3kan, Math.Round(atmetimoTikimybeKan3, 4));
            Assert.AreEqual(laukiamaAtmetimoTikimybeSu4kan, Math.Round(atmetimoTikimybeKan4, 4));
        }

        [TestMethod]
        public void SkaiciuojantAntraDemeni_SkaiciuojamaTesingai()
        {
            // Arange
            var skaiciuokle = new MasinioAptarnavimoSkaiciuokle();
            double laukiamaSuma = 54.844;
            int maksimaliEile = 4;
            int kanaluSkaicius = 2;
            double alfa = 3;

            // Act
            var paskaiciuotasSuma = skaiciuokle.SkaiciuotiAntraDemeni(kanaluSkaicius, maksimaliEile, alfa);

            // Assert
            Assert.AreEqual(laukiamaSuma, Math.Round(paskaiciuotasSuma, 3));
        }

        [TestMethod]
        public void SkaiciuotiUzdavini()
        {
            // Arrange
            var skaiciuokle = new MasinioAptarnavimoSkaiciuokle();

            // maksimali eile laukianciuju
            int maxlaukianciujuEile = 4;

            // lambda
            int paraiskuSrautoIntensyvumas = 1;

            int laikoTarpasMinutemis = 1;

            int paraiskuSrautasLaikoVieneteMinutemis = 3;

            // miu
            double paraiskuAptarnavimoIntensyvumas = (double)laikoTarpasMinutemis / (double)paraiskuSrautasLaikoVieneteMinutemis;

            // alfa
            double santykisParaiskuSrautoSuParaiskuAptarnavimoIntensyvumu = 3;


            // Act
            double gautasParaiskuAptarnavimoIntensyvumas = skaiciuokle.SkaiciuotiParaiskuAptarnavimoIntensyvuma(laikoTarpasMinutemis, paraiskuSrautasLaikoVieneteMinutemis);

            // miu
            double miu = skaiciuokle.SkaiciuotiParaiskuAptarnavimoIntensyvuma(laikoTarpasMinutemis, paraiskuSrautasLaikoVieneteMinutemis);

            //alfa
            double alfa = skaiciuokle.SkaiciuotiSantykisParaiskuSrautoSuParaiskuAptarnavimoIntensyvumu(paraiskuSrautoIntensyvumas, miu);

         

        }

    }
}