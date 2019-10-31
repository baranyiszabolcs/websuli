
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
            new SelectListItem { Value = "Szorzas/Osztas", Text = "Szorzás / Osztás"  },
            new SelectListItem { Value = "Zarojeles", Text = "Zárójeles kifejezéek"  },
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
        [Range(0, 5)]
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

        public static Feladat GenerateFeladat(string tipus, int plimit=100)
        {
            switch (tipus)
            { 
               case "Szorzas": 
                    return new Szorzotabla();
               case "Osszeadas":
                    OsszeadKivon f = new OsszeadKivon() { limit=plimit};
                    return f;
               case "Szorzas/Osztas":
                    return new Szorzotabla();
               case "Zarojeles":
                    return new Szorzotabla();

                default:
                    return new Szorzotabla();

            }
        }
        public void AddFeladatToList(Feladat fa)
        {
            feladatlista.Add(++cnt, fa);
        }
        public void UpdateFeladat(Feladat fa)
        {
            feladatlista[cnt] =fa;
            if (fa.eredmeny == 1)
                ++helyescnt;
            else
                ++hibascnt;
            eredmenypct = helyescnt / feladatszam;
            
        }
    }


}
