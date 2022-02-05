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

            int paraiskuSrautasLaikoTarpeMinutemis = 3;

            // miu
            double paraiskuAptarnavimoIntensyvumas = (double)laikoTarpasMinutemis / (double)paraiskuSrautasLaikoTarpeMinutemis;

            // alfa
            double santykisParaiskuSrautoSuParaiskuAptarnavimoIntensyvumu = 3;

            //Paraisku atmetimo tikimybe, kai SantykisParaiskuSrautoSuParaiskuAptarnavimoIntensyvumu nelygus 1, alfa = lambda/miu
            double paraiskuAtmetimoTikimybe = 0.66758;

            // Santykine aptarnavimo geba
            double santykineAptarnavimoGeba = 0.33242;

            // Act

            // miu
            double gautasParaiskuAptarnavimoIntensyvumas = skaiciuokle.SkaiciuotiParaiskuAptarnavimoIntensyvuma(laikoTarpasMinutemis, paraiskuSrautasLaikoTarpeMinutemis);

            //alfa
            double gautasSantykisParaiskuSrautoSuParaiskuAptarnavimoIntensyvumu = skaiciuokle.SkaiciuotiSantykisParaiskuSrautoSuParaiskuAptarnavimoIntensyvumu(paraiskuSrautoIntensyvumas, gautasParaiskuAptarnavimoIntensyvumas);

            // P ats
            double gautaParaiskuAtmetimoTikimybe = skaiciuokle.SkaiciuotiVienakanaleSuEileParaiksuAtmetimoTikimybe(santykisParaiskuSrautoSuParaiskuAptarnavimoIntensyvumu, maxlaukianciujuEile);

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

        }
    }
}