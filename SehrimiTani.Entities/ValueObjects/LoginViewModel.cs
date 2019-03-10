using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SehrimiTani.Entities.ValueObjects
{
    public class LoginViewModel
    {
        [DisplayName("Kullanıcı Adı"), Required(ErrorMessage = "{0} alanı boş geçilemez"), StringLength(15, ErrorMessage = "{0} alanı maxsimum {1} karekter olmalıdır.")]
        public string KullaniciAdi { get; set; }
        [DisplayName("Kullanıcı Adı"), Required(ErrorMessage = "{0} alanı boş geçilemez"),DataType(DataType.Password),
            StringLength(15, ErrorMessage = "{0} alanı maxsimum {1} karekter olmalıdır.")]
        public string Sifre { get; set; }
    }
}