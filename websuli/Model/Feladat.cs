using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace websuli.Model
{
    public abstract class Feladat
    {
        public string Helyesvalasz { get; set; }
        public string Gyerekvalasz { get; set; }
        public int ValaszidoSec { get; set; }
        public string feladatJson { get; set; }

        public abstract string Generate();
        public string[] GeneratePosibleAnswers()
        {
            string[] valaszok = new string[1];
            valaszok[0] = "HEHEHE";
            return valaszok;
        }
        public string Evaluate(string valasz)
        {
            Gyerekvalasz = valasz;
            return valasz == Helyesvalasz ? "OK" : "Hibás";
        }
        public void Configure(Dictionary<string,string> valuePairs )
        {
            string limit = valuePairs["limit"];
        }
        // Afealat főbb elemeit Json objektumba teszi  pl szorzásnál a tényezőket
        public string GenerateFeladatJson()
        {
            feladatJson = "{}";
            return "{}";
        }
        

    }
   

}
