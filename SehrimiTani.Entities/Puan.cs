using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SehrimiTani.Entities
{
    [Table("puanlar")]
    public class Puan :MyEntitiyBase
    {
        [Required]
        public int degerler { get; set; }
        public Universite UniversiteID { get; set; }
    }
}
