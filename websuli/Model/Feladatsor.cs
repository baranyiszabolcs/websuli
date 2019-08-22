using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace WebMatek.Models
{
    public class Feladatsor
    {
        public int id { get; set; }
        public string gyerek { get; set; }
        public string feladatTipus { get; set; }
        public float eredmenypct { get; set; }
        public int feladatszam { get; set; }
        [Display(Name = "kiadasDatum")]
        [DataType(DataType.Date)]
        public DateTime kiadasDatum { get; set; }
    }
}
