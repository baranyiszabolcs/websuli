using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace websuli.Model
{
    public class Feladat
    {
        public long ID { get; set; }
        [ForeignKey("Feladatsor")]
        public Guid FealadatsorID { get; set; }
        public string Helyesvalasz { get; set; }
        public string Gyerekvalasz { get; set; }
        public int eredmeny { get; set; }
        public int ValaszidoSec { get; set; } = 0;
        public string feladatJson { get; set; }
        public string feladatText { get; set; }

        public string eredmenyTxt
        {
            get { return eredmeny == 1 ? "Jó" : "Rossz"; }
        }
        public virtual string Generate()
        {
            throw new NotImplementedException();
        }
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
