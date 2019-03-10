using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SehrimiTani.Entities
{
    [Table("Yemekler")]
    public class Yemekler
    {
        [Required,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int YemeklerId { get; set; }
        [Required,StringLength(500)]
        public string Icerik { get; set; }
        [StringLength(40)]
        public string ProileImagerFilename { get; set; }
        //[Required]
        public Sehirler SehirID { get; set; }
        public virtual List<Yorumlar> Yorum { get; set; }
       
    }
}
