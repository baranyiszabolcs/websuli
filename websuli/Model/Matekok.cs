using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace websuli.Model
{

    public abstract class MatekFeladat : Feladat
    {
        protected Random rnd;
        public MatekFeladat()
        {
            rnd = new Random();
        }

    }
    public class Szorzotabla : MatekFeladat
    {
        
        public int Szorzando { get; set; }
        public int Szorzo { get; set; }
        public override string Generate()
        {
            rnd = new Random();
            Szorzando = rnd.Next(10);
            Szorzo = rnd.Next(10);
            Helyesvalasz = (Szorzando * Szorzo).ToString();
            StringBuilder sb = new StringBuilder(" ");
            return sb.AppendFormat("{0} * {1} = ", Szorzando, Szorzo).ToString();
        }

    }

    public class OsszeadKivon : MatekFeladat
    {
        StringBuilder sb = new StringBuilder(" ");
        public int A { get; set; }
        public int B { get; set; }
        [JsonIgnore]
        public int limit = 100;
        public override string Generate()
        {
            int mit = rnd.Next(10);
            if (mit % 2 == 1)
            {/// Összedadás
                A = rnd.Next(limit);
                B = rnd.Next(limit - A);
                Helyesvalasz = (A + B).ToString();
                return sb.AppendFormat("%d + %d = ", A, B).ToString();
            }
            else
            {/// kivonás
                A = rnd.Next(limit);
                B = rnd.Next(A);
                Helyesvalasz = (A - B).ToString();
                return sb.AppendFormat("%d - %d = ", A, B).ToString();
            }

        }

    }
}
