
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace websuli.Model
{
    public static class FealdatsorLOV
    {
        public static List<SelectListItem> FeladatTipusLista { get; } = new List<SelectListItem>()
        {
            new SelectListItem { Value = "Osszeadas", Text = "Összeadás" },
            new SelectListItem { Value = "Szorzas", Text = "Szorzás" },
            new SelectListItem { Value = "Osztas", Text = "Osztás"  },
            new SelectListItem { Value = "Zarojeles", Text = "Zárójeles kifejezések"  },
            new SelectListItem { Value = "Kerekites", Text = "Számkerekítések"  },
            new SelectListItem { Value = "Romai", Text = "Római Számok"  }
        };
    }
    public class Feladatsor
    {
        [Required]
        [Key]
        public Guid FeladatsorID { get; set; } = Guid.NewGuid();  // Calssname  ID  naming convention also makes it key during   generation
        [Display(Name = "Feladatsornev", Prompt = "Feladatsor Neve:")]
        public string sornev { get; set; }
        [Display(Name = "Gyerek Neve",Prompt = "Gyerek")]
        [StringLength(50, ErrorMessage = "Max 50 character")]
        public string gyerek { get; set; }
        [Display(Name = "Fealadat típus", Prompt = "Feladat típus:")]
        public string feladatTipus { get; set; } = "Szorzas";
        [Range(0, 100)]
        public int eredmenypct { get; set; } = 0;
        public int feladatszam { get; set; } = 100;
        public int helyescnt { get; set; } = 0;
        public int hibascnt { get; set; } = 0;
        [Display(Name = "kiadasDatum")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime kiadasDatum { get; set; } = DateTime.Now;
        [NotMapped]
        public Dictionary<int,Feladat> feladatlista { get; set; } = new Dictionary<int,Feladat>();
        public int cnt { get; set; } = 0;

        public static Feladat GenerateFeladat(string tipus)
        {
            switch (tipus)
            { 
               case "Szorzas": 
                    return new Szorzotabla();
               case "Osszeadas":
                    OsszeadKivon f = new OsszeadKivon() { limit=1000};
                    return f;
               case "Osztas":
                    return new Osztas();
               case "Zarojeles":
                    return new Zarojeles();
               case "Kerekites":
                    return new Kerekites() { limit =1000};
               case "Romai":
                    return new RomaiSzamok() { limit = 1000 };

                default:
                    return new Szorzotabla();

            }
        }
        public void AddFeladatToList(Feladat fa)
        {
            fa.Feladatsor = this;
            feladatlista.Add(++cnt, fa);
            
        }
        public void UpdateFeladat(Feladat fa)
        {
            feladatlista[cnt] =fa;
            if (fa.eredmeny == 1)
                ++helyescnt;
            else
                ++hibascnt;
            eredmenypct = (int)Math.Round((((float)helyescnt / (float)feladatszam)) * 100.0);
            
        }
    }


}
