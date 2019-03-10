using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SehrimiTani.Entities
    
{
    [Table("Barinma")]
    public class Barinma:MyEntitiyBase
    {

        [Required,StringLength(50)]
        public string Tipi { get; set; }
       // [Required]
        public virtual Sehirler SehirID { get; set; }
        [Required,StringLength(150)]
        public string Adres { get; set; }
        [Required,StringLength(500)]
        public string Icerik { get; set; }
        [StringLength(40)]
        public string ProileImagerFilename { get; set; }
        public virtual List<Yorumlar> Yorum { get; set; }
    }
}
