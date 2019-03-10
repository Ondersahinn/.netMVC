using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SehrimiTani.Entities
{
    [Table("Universiteler")]
    public class Universite:MyEntitiyBase
    {
        [Required,StringLength(50)]
        public string adi { get; set; }
       
       // [Required]
        public virtual Sehirler SehirID { get; set; }
        [Required, StringLength(500)]
        public string Icerik { get; set; }//Belli değil
        public virtual List<Yorumlar> Yorum { get; set; }
        public Universite()
        {
            Yorum = new List<Yorumlar>();
        }
           
            
    }
}
