using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        [NotMappedAttribute]
        public int Szorzando { get; set; }
        [NotMappedAttribute]
        public int Szorzo { get; set; }
        public override string Generate()
        {
            rnd = new Random();
            Szorzando = rnd.Next(10);
            Szorzo = rnd.Next(10);
            Helyesvalasz = (Szorzando * Szorzo).ToString();
            StringBuilder sb = new StringBuilder(" ");
            feladatText = sb.AppendFormat("{0} * {1} = ", Szorzando, Szorzo).ToString();
            return feladatText;
        }

    }

    public class Osztas : MatekFeladat
    {
        [NotMappedAttribute]
        public int Osztando { get; set; }
        [NotMappedAttribute]
        public int Oszto { get; set; }
        public override string Generate()
        {
            rnd = new Random();
            Oszto = rnd.Next(1,10)+1;
            eredmeny = rnd.Next(1,10)+1;
            Osztando = eredmeny * Oszto;
            Helyesvalasz = eredmeny.ToString();
            StringBuilder sb = new StringBuilder(" ");
            feladatText = sb.AppendFormat("{0} : {1} = ", Osztando, Oszto).ToString();
            return feladatText;
        }

    }

    public class OsztasPlus : MatekFeladat
    {
        [NotMappedAttribute]
        public int Osztando { get; set; }
        [NotMappedAttribute]
        public int Oszto { get; set; }
        public override string Generate()
        {
            rnd = new Random();
            Oszto = rnd.Next(5, 12) + 1;
            eredmeny = rnd.Next(5, 12) + 1;
            Osztando = eredmeny * Oszto;
            Helyesvalasz = eredmeny.ToString();
            StringBuilder sb = new StringBuilder(" ");
            feladatText = sb.AppendFormat("{0} : {1} = ", Osztando, Oszto).ToString();
            return feladatText;
        }

    }

    public class Kerekites : MatekFeladat
    {
        [JsonIgnore]
        public int limit = 1000;
        [NotMappedAttribute]
        public int Eredeti { get; set; }
    
        public override string Generate()
        {
            rnd =  new Random();
            Eredeti = rnd.Next(1000);
            int kerekitos =  rnd.Next(100);
            StringBuilder sb = new StringBuilder("  ");

            if (kerekitos % 2 ==1)
            {
                feladatText = sb.AppendFormat(" Kerekítsd százasokra: {0}  : ", Eredeti.ToString()).ToString();
                Helyesvalasz = (Math.Round((decimal)Eredeti / 100,0)*100).ToString();
            }  else
            {
                feladatText = sb.AppendFormat(" Kerekítsd tízesekre: {0}  : ", Eredeti.ToString()).ToString();
                Helyesvalasz = (Math.Round((decimal)Eredeti/10,0)*10).ToString();
            }

            return feladatText;
        }

    }

    public class OsszeadKivon : MatekFeladat
    {
        StringBuilder sb = new StringBuilder(" ");
        public int A;
        public int B;
        [JsonIgnore]
        public int limit = 1000;
        public override string Generate()
        {
            int mit = rnd.Next(10);
            if (mit % 2 == 1)
            {/// Összedadás
                A = rnd.Next(limit);
                B = rnd.Next(limit - A);
                Helyesvalasz = (A + B).ToString();
                feladatText = sb.AppendFormat("{0} + {1} = ", A, B).ToString();
                return feladatText;
            }
            else
            {/// kivonás
                A = rnd.Next(limit);
                B = rnd.Next(A);
                Helyesvalasz = (A - B).ToString();
                feladatText =  sb.AppendFormat("{0} - {1} = ", A, B).ToString();
                return feladatText;
            }

        }

    }


    public class Zarojeles : MatekFeladat
    {
        StringBuilder sb = new StringBuilder(" ");
        public int A;
        public int B;
        public int C;
        [JsonIgnore]
        public int limit = 1000;
        public override string Generate()
        {
            int mit = rnd.Next(100);
            switch ((mit % 4))
            { 
            case 0:
            /// (A + B) -C
                A = rnd.Next(limit);
                B = rnd.Next(limit - A);
                C = rnd.Next(limit - A - B);
                Helyesvalasz = ((A+B)-C).ToString();
                feladatText = sb.AppendFormat("( {0}+{1})-{2}= ", A, B,C).ToString();
                    break;
            case 1:            
            /// A + (B - C)
                B = rnd.Next(limit);
                C = rnd.Next(B);
                A = rnd.Next(limit - (B - C));
                Helyesvalasz = (A + (B - C)).ToString();
                feladatText = sb.AppendFormat(" {0}+({1}-{2})= ", A, B, C).ToString();
                    break;
            case 2:          
            /// A - (B - C)
                A = rnd.Next(limit);
                B = rnd.Next(A);
                C = rnd.Next(B);
                Helyesvalasz = (A - (B -C)).ToString();
                feladatText = sb.AppendFormat("{0}-({1}-{2}) = ",A,B,C).ToString();
                break;
            case 3:
             /// (A - B) - C)
                A = rnd.Next(limit);
                B = rnd.Next(A);
                C = rnd.Next((A-B));
                Helyesvalasz = ((A-B)-C).ToString();
                feladatText = sb.AppendFormat("({0}-{1})-{2} = ", A, B,C).ToString();
                    break;
            }
            return feladatText;
        }

    }


    public class RomaiSzamok : MatekFeladat
    {
        [JsonIgnore]
        public int limit = 1000;
        [NotMappedAttribute]
        int Arab;

        public override string Generate()
        {
            rnd = new Random();
            Arab = rnd.Next(1,limit);
            feladatText = " Írd le RÓMAI számokkal  : "+ Arab.ToString();
            Helyesvalasz = ArabicToRoman(Arab);
            

            return feladatText;
        }
        /// <summary>
        /// Roman To arabic
        /// </summary>
        // Maps letters to numbers.
        private Dictionary<char, int> CharValues = null;

        // Convert Roman numerals to an integer.
        private int RomanToArabic(string roman)
        {
            // Initialize the letter map.
            if (CharValues == null)
            {
                CharValues = new Dictionary<char, int>();
                CharValues.Add('I', 1);
                CharValues.Add('V', 5);
                CharValues.Add('X', 10);
                CharValues.Add('L', 50);
                CharValues.Add('C', 100);
                CharValues.Add('D', 500);
                CharValues.Add('M', 1000);
            }

            if (roman.Length == 0) return 0;
            roman = roman.ToUpper();

            // See if the number begins with (.
            if (roman[0] == '(')
            {
                // Find the closing parenthesis.
                int pos = roman.LastIndexOf(')');

                // Get the value inside the parentheses.
                string part1 = roman.Substring(1, pos - 1);
                string part2 = roman.Substring(pos + 1);
                return 1000 * RomanToArabic(part1) + RomanToArabic(part2);
            }

            // The number doesn't begin with (.
            // Convert the letters' values.
            int total = 0;
            int last_value = 0;
            for (int i = roman.Length - 1; i >= 0; i--)
            {
                int new_value = CharValues[roman[i]];

                // See if we should add or subtract.
                if (new_value < last_value)
                    total -= new_value;
                else
                {
                    total += new_value;
                    last_value = new_value;
                }
            }

            // Return the result.
            return total;
        }
        /// <summary>
        ///  Arabic TO Roman
        /// </summary>
        // Map digits to letters.
        private string[] ThouLetters = { "", "M", "MM", "MMM" };
        private string[] HundLetters =
            { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
        private string[] TensLetters =
            { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
        private string[] OnesLetters =
            { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };

        // Convert Roman numerals to an integer.
        private string ArabicToRoman(int arabic)
        {
            // See if it's >= 4000.
            if (arabic >= 4000)
            {
                // Use parentheses.
                int thou = arabic / 1000;
                arabic %= 1000;
                return "(" + ArabicToRoman(thou) + ")" +
                    ArabicToRoman(arabic);
            }

            // Otherwise process the letters.
            string result = "";

            // Pull out thousands.
            int num;
            num = arabic / 1000;
            result += ThouLetters[num];
            arabic %= 1000;

            // Handle hundreds.
            num = arabic / 100;
            result += HundLetters[num];
            arabic %= 100;

            // Handle tens.
            num = arabic / 10;
            result += TensLetters[num];
            arabic %= 10;

            // Handle ones.
            result += OnesLetters[arabic];

            return result;
        }

    }


}
