using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SehrimiTani.Entities
{
    [Table("Kullanicilar")]
    public class Kullanicilar:MyEntitiyBase
    {
        [Required,StringLength(15)]
        public string Kuladi { get; set; }
        [StringLength(25)]
        public string Adi { get; set; }
        [StringLength(25)]
        public string Soyadi { get; set; }
        [StringLength(11)]
        public string Telefon { get; set; }
        [Required, StringLength(60)]
        public string Email { get; set; }
        public virtual Universite Universiteadi { get; set; }
        [StringLength(40)]
        public string ProileImagerFilename { get; set; }
                                           // [Required]
        public Sehirler SehirID { get; set; }
        [Required, StringLength(20)]
        public string Sifre { get; set; }
        public bool isActive { get; set; }
        [Required]
        public Guid ActivateGuid { get; set; }
        [Required]
        public bool isAdmin { get; set; }
        public virtual List<Yorumlar> Yorum { get; set; }
        public virtual List<Liked> Likes { get; set; }
    }
}
