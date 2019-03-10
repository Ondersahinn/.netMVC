using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SehrimiTani.Entities
{
    [Table("Gezilecekyerler")]
    public class Gezilecekyer : MyEntitiyBase
    {
        [Required(ErrorMessage = "{0} alanı gereklidir."), StringLength(100, ErrorMessage ="{0} karekter içermeli")]
        public string Baslik { get; set; }
        [StringLength(100)]
        public string Resim { get; set; }
        [Required, StringLength(500)]
        public string Icerik { get; set; }
        //[Required]
        public Sehirler SehirlerID { get; set; }
    }
}
