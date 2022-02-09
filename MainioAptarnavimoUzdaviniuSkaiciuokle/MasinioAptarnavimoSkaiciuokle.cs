namespace MainioAptarnavimoUzdaviniuSkaiciuokle
{
    public class MasinioAptarnavimoSkaiciuokle
    {
        // lambda
        public double SkaiciuotiParaiskuSrautoIntensyvuma(int paraiskuKiekis, int laikas)
        {
            return (double)paraiskuKiekis / (double)laikas;
        }

        // miu
        public double SkaiciuotiParaiskuAptarnavimoIntensyvuma(double laikoTarpasMinutemis, double paraiskuSrautasLaikoTarpeMinutemis)
        {
            return (double) laikoTarpasMinutemis / (double) paraiskuSrautasLaikoTarpeMinutemis;
        }
        
        // alfa = lamba / miu
        public double SkaiciuotiSantykisParaiskuSrautoSuParaiskuAptarnavimoIntensyvumu(double paraiskuSrautoIntensyvumas, double gautasParaiskuAptarnavimoIntensyvumas)
        {
            return (double) paraiskuSrautoIntensyvumas / (double) gautasParaiskuAptarnavimoIntensyvumas;
        }


        // q = miu/(lambda + miu)
        public double SkaiciuotiVienakanaleAtmetimoTikimybeBeEiles(double lambda, double miu)
        {
            double q = (double)miu / (double)(lambda + miu);
            double Pats = 1 - q;
            return Pats;
        }

        // Pats = (alfa^n/n!)*P0
        public double SkaiciuotiDaugiakanaleTikimybeAtmetimoBeEiles(int kanaluSkaicius, double alfa)
        {
            double p0 = Math.Pow(SkaiciuotiPirmaDemeni(kanaluSkaicius, alfa), -1);
            var y = (Math.Pow(alfa, kanaluSkaicius) / (double)Faktorialas.skaiciuotiFaktorialia(kanaluSkaicius));
            var y1 = Math.Pow(alfa, kanaluSkaicius);
            var y2 = Faktorialas.skaiciuotiFaktorialia(kanaluSkaicius);
            double Pats = (Math.Pow(alfa, kanaluSkaicius) / (double)Faktorialas.skaiciuotiFaktorialia(kanaluSkaicius))*p0;
            return Pats;
        }



        public double skaiciuotiVienakanaleSuEileParaiksuAtmetimoTikimybe(double santykisParaiskuSrautoSuParaiskuAptarnavimoIntensyvumu, int maxlaukianciujuEile)
        {
            if(santykisParaiskuSrautoSuParaiskuAptarnavimoIntensyvumu == 1)
            {
                // 1/(m+2)
                return (double)1 / (double)(maxlaukianciujuEile + 2);
            }
            else
            {
                // ((alfa^(m+1))*(1-alfa))/(1-(alfa^m+2))
                return (double) ((double)(Math.Pow(santykisParaiskuSrautoSuParaiskuAptarnavimoIntensyvumu, maxlaukianciujuEile + 1)) * (1 - (double) santykisParaiskuSrautoSuParaiskuAptarnavimoIntensyvumu)) / (double) (1 - Math.Pow(santykisParaiskuSrautoSuParaiskuAptarnavimoIntensyvumu, maxlaukianciujuEile + 2)) ;
            }
            
        }

        public double SkaiciuotiSantykineAptarnavimoGeba(double paraiskuAtmetimoTikimybe)
        {
            return 1 - paraiskuAtmetimoTikimybe;
        }

        public double SkaiciuotiDaugiakanaleSuEileAtmetimoTikimybe(int kanaluSkaicius, int maksimaliEile, double alfa)
        {
            double pirmasDemuo = SkaiciuotiPirmaDemeni(kanaluSkaicius, alfa);

            // Kai gama lygu 1
            if ((alfa / (double)kanaluSkaicius) == 1)
            {
                double p1 = Math.Pow((pirmasDemuo + (((double)(maksimaliEile * Math.Pow(alfa, kanaluSkaicius)) / (double)Faktorialas.skaiciuotiFaktorialia(kanaluSkaicius)))), -1);
                double pAts1 = (Math.Pow(alfa, kanaluSkaicius + maksimaliEile) / (double)(Math.Pow(kanaluSkaicius, maksimaliEile) * Faktorialas.skaiciuotiFaktorialia(kanaluSkaicius))) * p1;
                return pAts1;
            }
            else
            {
                double antrasDemuo = SkaiciuotiAntraDemeni(kanaluSkaicius, maksimaliEile, alfa);
                double p0 = Math.Pow((pirmasDemuo + antrasDemuo), -1);
                double pAts = (Math.Pow(alfa, kanaluSkaicius + maksimaliEile) / (double)(Math.Pow(kanaluSkaicius, maksimaliEile) * Faktorialas.skaiciuotiFaktorialia(kanaluSkaicius))) * p0;
                return pAts;
            }

        }

        // skaiciuoti suma nuo k = 0 iki n(kanalu skaicius),  alfa^k/k!
        public double SkaiciuotiPirmaDemeni(int kanaluSkaicius, double alfa)
        {
            double sum = 0;

            for (int i = 0; i <= kanaluSkaicius; i++)
            {
                sum += Math.Pow(alfa, i) / (double)Faktorialas.skaiciuotiFaktorialia(i);
            }

            return sum;
        }

        public double SkaiciuotiAntraDemeni(int kanaluSkaicius, int maksimaliEile, double alfa)
        {
            double sum = 0;

            for (int k = kanaluSkaicius + 1; k <= kanaluSkaicius + maksimaliEile; k++)
            {

                sum += (Math.Pow(alfa, k) / (double)(Math.Pow(kanaluSkaicius, k - kanaluSkaicius)));
            }

            double sandauga = ((double)1 / (double)Faktorialas.skaiciuotiFaktorialia(kanaluSkaicius)) * sum;

            return sandauga;
        }
    }
}