using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaracalSoft.Data;
using SehrimiTani.DataAccessLayer.EntitiyFreamwork;
using SehrimiTani.Entities;
namespace SehrimiTani.BusinessLayer
{
    public class Test
    {

        private Repositoriy<Kullanicilar> repo = new Repositoriy<Kullanicilar>();
        private Repositoriy<Yorumlar> yorumRepo = new Repositoriy<Yorumlar>();
        private Repositoriy<Sehirler> sehirrepo = new Repositoriy<Sehirler>();
        public Test()
        {
            //Data.DB = new DatabaseContext();
            List<Kullanicilar> KulList = repo.List();
            List<Kullanicilar> Kulfilitrele = repo.List(x => x.Id > 5);
        }
        public void InsertTest()
        {

            int result = repo.Insert(new Kullanicilar()
            {
                Adi = "RepoTEst",
                Soyadi = "RepoTEst",
                Email = "RepoTEstn@gmail.com",
                ActivateGuid = Guid.NewGuid(),
                isActive = true,
                isAdmin = true,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddMinutes(5),
                ModifiedUsername = "RepoTEst",
                Kuladi = "RepoTEst",
                Sifre = "123456",
                Telefon = "5548384350",
            });
        }
        public void UptadeTest()
        {
            Kullanicilar user = repo.Find(x => x.Adi == "RepoTEst");
            user.Adi = "Değişti";
            int result = repo.Update(user);
        }
        public void DeleteTest()
        {
            Kullanicilar user = repo.Find(x => x.Adi == "Değişti");
            if (user != null)
            {
                int resul = repo.Delete(user);
            }
        }
        public void YorumTest()
        {
            Kullanicilar user = repo.Find(x => x.Id == 1);
            Sehirler sehirler = sehirrepo.Find(x => x.Id == 23);
            Yorumlar yorum = new Yorumlar()
            {
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                Icerik = "Deneme Reis Deneme",
                ModifiedUsername = "ondersahin",
                SehirlerID = sehirler,
                Owner = user,


            };
            yorumRepo.Insert(yorum);
        }
    }
}
