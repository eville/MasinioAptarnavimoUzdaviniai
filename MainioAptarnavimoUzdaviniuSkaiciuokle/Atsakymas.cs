using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainioAptarnavimoUzdaviniuSkaiciuokle
{
    public class Atsakymas
    {
        public Atsakymas(int kanaluSkaicius, double santykineAptarnavimoGeba)
        {
            KanaluSkaicius = kanaluSkaicius;
            SantykineAptarnavimoGeba = santykineAptarnavimoGeba;
        }
        public int KanaluSkaicius { get; private set; }

        public double SantykineAptarnavimoGeba { get; private set; }

    }
}
