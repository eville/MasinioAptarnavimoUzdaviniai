namespace MainioAptarnavimoUzdaviniuSkaiciuokle
{
    public class MasinioAptarnavimoSkaiciuokle
    {
        public double SkaiciuotiParaiskuAptarnavimoIntensyvuma(int laikoTarpasMinutemis, int paraiskuSrautasLaikoTarpeMinutemis)
        {
            return (double) laikoTarpasMinutemis / (double) paraiskuSrautasLaikoTarpeMinutemis;
        }

        public double SkaiciuotiSantykisParaiskuSrautoSuParaiskuAptarnavimoIntensyvumu(int paraiskuSrautoIntensyvumas, double gautasParaiskuAptarnavimoIntensyvumas)
        {
            return (double) paraiskuSrautoIntensyvumas / (double) gautasParaiskuAptarnavimoIntensyvumas;
        }

        public double SkaiciuotiVienakanaleSuEileParaiksuAtmetimoTikimybe(double santykisParaiskuSrautoSuParaiskuAptarnavimoIntensyvumu, int maxlaukianciujuEile)
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
    }
}