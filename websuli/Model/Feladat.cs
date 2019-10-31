using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace websuli.Model
{
    public abstract class Feladat
    {
        [ForeignKey("Feladatsor")]
        public Guid FealadatsorID { get; set; }
        public string Helyesvalasz { get; set; }
        public string Gyerekvalasz { get; set; }
        public int eredmeny { get; set; }
        public int ValaszidoSec { get; set; } = 0;
        public string feladatJson { get; set; }

        public abstract string Generate();
        public virtual string[] GeneratePosibleAnswers()
        {
            string[] valaszok = new string[1];
            valaszok[0] = "HEHEHE";
            return valaszok;
        }
        public virtual string Evaluate(string valasz)
        {
            Gyerekvalasz = valasz;
            eredmeny = (valasz==Helyesvalasz ? 1 : 0);
            return valasz == Helyesvalasz ? "OK" : "Hibás";
        }
 
        // A feladat főbb elemeit Json objektumba teszi  pl szorzásnál a tényezőket
        public string GenerateFeladatJson()
        {
            feladatJson = JsonConvert.SerializeObject(this);
            return feladatJson;
        }
        

    }
   

}
