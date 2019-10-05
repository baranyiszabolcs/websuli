using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace websuli.Model
{
    public class Feladatsor
    {

        public int id { get; set; }
        public string gyerek { get; set; }
        public string feladatTipus { get; set; }
        public float eredmenypct { get; set; }
        public int feladatszam { get; set; }
        public int helyescnt { get; set; }
        [Display(Name = "kiadasDatum")]
        [DataType(DataType.Date)]
        public DateTime kiadasDatum { get; set; }
        public List<Feladat> feladatlista { get; set; }
        public static Feladat GenerateFeladatSor(string tipus,int limit=10)
        {
            switch (tipus)
            { 
               case "Szorzas": 
                    return new Szorzotabla();
               case "Osszeadas":
                    OsszeadKivon f = new OsszeadKivon();
                    f.limit = 100;
                    return f;
               case "Szorzas/Osztas":
                    return new Szorzotabla();

                default:
                    return new Szorzotabla();

            }
        }

    }


}
