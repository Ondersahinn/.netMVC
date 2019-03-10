using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SehrimiTani.Entities.ValueObjects
{
    public class YorumViewModel
    {
        [DisplayName("İçerik Alanı"), Required(ErrorMessage = "{0} alanı boş geçilemez"),
          StringLength(300, ErrorMessage = "{0} alanı maxsimum {1} karekter olmalıdır.")]
        public string Icerik { get; set; }

    }
}
