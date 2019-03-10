using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SehrimiTani.Entities.ValueObjects
{
    public class RegisterViewModelcs
    {
        [DisplayName("Kullanıcı Adı"), Required(ErrorMessage = "{0} alanı boş geçilemez"),
            StringLength(15, ErrorMessage = "{0} alanı maxsimum {1} karekter olmalıdır.")]
        public string Username { get; set; }

        [DisplayName("Adı"), Required(ErrorMessage = "{0} alanı boş geçilemez"),
        StringLength(25, ErrorMessage = "{0} alanı maxsimum {1} karekter olmalıdır.")]
        public string Adi { get; set; }

        [DisplayName("Soyadı"), Required(ErrorMessage = "{0} alanı boş geçilemez"),
            StringLength(25, ErrorMessage = "{0} alanı maxsimum {1} karekter olmalıdır.")]
        public string Soyadi { get; set; }

        [DisplayName("Telefon"), Required(ErrorMessage = "{0} alanı boş geçilemez"),
            StringLength(11, ErrorMessage = "{0} alanı maxsimum {1} karekter olmalıdır.")]
        public string Telefon { get; set; }

        [DisplayName("Email"), Required(ErrorMessage = "{0} alanı boş geçilemez"),
            StringLength(60, ErrorMessage = "{0} alanı maxsimum {1} karekter olmalıdır."),
            EmailAddress(ErrorMessage = "{0} alanı için geçerli bir e posta giriniz")]
        public string EMail { get; set; }

        [DisplayName("Şifre"), Required(ErrorMessage = "{0} alanı boş geçilemez"),DataType(DataType.Password),
            StringLength(20, ErrorMessage = "{0} alanı maxsimum {1} karekter olmalıdır.")]
        public string Password { get; set; }

        [DisplayName("Şifre Tekrar"), Required(ErrorMessage = "{0} alanı boş geçilemez"), DataType(DataType.Password),
            StringLength(20, ErrorMessage = "{0} alanı maxsimum {1} karekter olmalıdır."),
            Compare("Password", ErrorMessage = "{0} ile" +
            "{1} uyuşmuyor.")]
        public string RePossword { get; set; }




    }
}