using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SehrimiTani.Entities
{
    [Table("Yorumlar")]
    public class Yorumlar : MyEntitiyBase
    {

        //public string Adi { get; set; }

        public virtual Sehirler SehirlerID { get; set; }
        [Required]
        public int LikeCount { get; set; }
        [Required,StringLength(300)]
        public string Icerik { get; set; }
        [Required]
        public virtual  Kullanicilar Owner { get; set; }

        public virtual List<Liked> Likes { get; set; }
        public Yorumlar()
        {
            Likes = new List<Liked>();
        }
    }
}
