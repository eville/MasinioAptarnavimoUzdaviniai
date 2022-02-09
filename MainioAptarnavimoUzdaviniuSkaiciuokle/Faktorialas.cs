using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainioAptarnavimoUzdaviniuSkaiciuokle
{
    public static class Faktorialas
    {
        public static long skaiciuotiFaktorialia(int skaicius)
        {
            long faktorialas = 1;
            for (int i = 1; i <= skaicius; i++)
            {
                faktorialas = faktorialas * i;
            }
            return faktorialas;

            //if(skaicius == 0 || skaicius == 1)
            //{
            //    return 1;
            //}
            //else
            //{
            //    int factorial = 1;
            //    for (int i = 1; i <= skaicius; i++)
            //    {
            //        factorial = factorial * i;
            //    }
            //    return factorial;
            //}
        }
    }
}
