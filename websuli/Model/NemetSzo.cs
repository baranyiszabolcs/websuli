using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace websuli.Model
{
    [Table("nemetszavak")]
    public class NemetSzo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        [Display(Name = "Névelő", Prompt = "Névelő")]
        [StringLength(5)]
        [Column("nevelo")]
        public string Nevelo { get; set; }
        [Required]
        [Display(Name = "Németül", Prompt = "Németül")]
        [StringLength(200)]
        [Column("nemet")]
        public string Nemet { get; set; }
        [Required]
        [Display(Name = "Magyarul", Prompt = "Magyarul")]
        [StringLength(200)]
        [Column("magyar")]
        public string Magyar { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Column("feladva")]
        public DateTime Feladva { get; set; } = DateTime.Now;

    }
   

}
