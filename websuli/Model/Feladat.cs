using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace websuli.Model
{
    public class Feladat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        //[ForeignKey("FeladatsorID")]
        //public Guid FealadatsorID { get; set; }
        [JsonIgnore]
        public Feladatsor Feladatsor { get; set; }
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
            GenerateFeladatJson();
            return valasz == Helyesvalasz ? "OK" : "Hibás";
        }
 
        // A feladat főbb elemeit Json objektumba teszi  pl szorzásnál a tényezőket
        public void GenerateFeladatJson()
        {
            feladatJson = JsonConvert.SerializeObject(this);          
        }
        

    }
   

}
