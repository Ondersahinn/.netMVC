using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.Entity;
using SehrimiTani.Entities;
using System.Data.Entity.Validation;
using CaracalSoft.Data;

namespace SehrimiTani.DataAccessLayer.EntitiyFreamwork
{
    //CreateDatabaseIfNotExists
    public class MyInitializer : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            List<string> sehirIsimleri = new List<string>();

            sehirIsimleri.Add("Adana");
            sehirIsimleri.Add("Adıyaman");
            sehirIsimleri.Add("Afyon");
            sehirIsimleri.Add("Ağrı");
            sehirIsimleri.Add("Amasya");
            sehirIsimleri.Add("Ankara");
            sehirIsimleri.Add("Antalya");
            sehirIsimleri.Add("Artvin");
            sehirIsimleri.Add("Aydın");
            sehirIsimleri.Add("Balıkesir");
            sehirIsimleri.Add("Bilecik");
            sehirIsimleri.Add("Bingöl");
            sehirIsimleri.Add("Bitlis");
            sehirIsimleri.Add("Bolu");
            sehirIsimleri.Add("Burdur");
            sehirIsimleri.Add("Bursa");
            sehirIsimleri.Add("Çanakkale");
            sehirIsimleri.Add("Çankırı");
            sehirIsimleri.Add("Çorum");
            sehirIsimleri.Add("Denizli");
            sehirIsimleri.Add("Diyarbakır");
            sehirIsimleri.Add("Edirne");
            sehirIsimleri.Add("Elazığ");
            sehirIsimleri.Add("Erzincan");
            sehirIsimleri.Add("Erzurum");         
            sehirIsimleri.Add("Eskişehir");
            sehirIsimleri.Add("Gaziantep");
            sehirIsimleri.Add("Giresun");
            sehirIsimleri.Add("Gümüşhane");
            sehirIsimleri.Add("Hakkari");
            sehirIsimleri.Add("Hatay");
            sehirIsimleri.Add("Isparta");
            sehirIsimleri.Add("Mersin");
            sehirIsimleri.Add("İstanbul");
            sehirIsimleri.Add("İzmir");
            sehirIsimleri.Add("Kars");
            sehirIsimleri.Add("Kastamonu");
            sehirIsimleri.Add("Kayseri");
            sehirIsimleri.Add("Kırklareli");
            sehirIsimleri.Add("Kırşehir");   
            sehirIsimleri.Add("Kocaeli");
            sehirIsimleri.Add("Konya");
            sehirIsimleri.Add("Kütahya");
            sehirIsimleri.Add("Malatya");
            sehirIsimleri.Add("Manisa");
            sehirIsimleri.Add("K.maraş");
            sehirIsimleri.Add("Mardin");
            sehirIsimleri.Add("Muğla");
            sehirIsimleri.Add("Muş");
            sehirIsimleri.Add("Nevşehir");
            sehirIsimleri.Add("Niğde");
            sehirIsimleri.Add("Ordu");
            sehirIsimleri.Add("Rize");
            sehirIsimleri.Add("Sakarya");
            sehirIsimleri.Add("Samsun");
            sehirIsimleri.Add("Siirt");
            sehirIsimleri.Add("Sinop");
            sehirIsimleri.Add("Sivas");
            sehirIsimleri.Add("Tekirdağ");
            sehirIsimleri.Add("Tokat");
            sehirIsimleri.Add("Trabzon");
            sehirIsimleri.Add("Tunceli");
            sehirIsimleri.Add("Şanlıurfa");
            sehirIsimleri.Add("Uşak");
            sehirIsimleri.Add("Van");
            sehirIsimleri.Add("Yozgat");
            sehirIsimleri.Add("Zonguldak");
            sehirIsimleri.Add("Aksaray");
            sehirIsimleri.Add("Bayburt");
            sehirIsimleri.Add("Karaman");
            sehirIsimleri.Add("Kırıkkale");
            sehirIsimleri.Add("Batman");
            sehirIsimleri.Add("Şırnak");
            sehirIsimleri.Add("Bartın");
            sehirIsimleri.Add("Ardahan");
            sehirIsimleri.Add("Iğdır");
            sehirIsimleri.Add("Yalova");
            sehirIsimleri.Add("Karabük");
            sehirIsimleri.Add("Kilis");
            sehirIsimleri.Add("Osmaniye");
            sehirIsimleri.Add("Düzce");

            /*Şehirleri Ekle*/
            int a = 1;
            List<Sehirler> sehirList = new List<Sehirler>();
            for (int i = 0; i < sehirIsimleri.Count; i++)
            {
                
                //Şehir Ekleme
                Sehirler sehir = new Sehirler()
                {
                    
                    Sehiradi = sehirIsimleri[i],
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    ModifiedUsername = "ondersahin",
                    
                    SehirYorum=null
                    

                };
              sehirList.Add(sehir);
                // context.Sehir.Add(sehir);
                a++;
            }
            //context.SaveChanges();
            /*Şehirleri Database fırlat*/
            
                Repository<Sehirler>.CreateList(sehirList);
            
          
           


            Sehirler gSehir = Repository<Sehirler>.Read(x => x.Id == 1);



            Yorumlar yorum = new Yorumlar();
            //Admin Ekleme
            List<Kullanicilar> kullaniciListesi = new List<Kullanicilar>();
            Kullanicilar admin = new Kullanicilar()
            {
                Adi = "önder",
                Soyadi = "Şahin",
                Email = "ondershin@gmail.com",
                ActivateGuid = Guid.NewGuid(),
                isActive = true,
                isAdmin = true,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddMinutes(5),
                ModifiedUsername = "ondersahin",
                Kuladi = "Onder358",
                Sifre = "123456",
                Telefon = "5548384350",
                SehirID=gSehir,
                ProileImagerFilename="user_boy.png"
                

            };
           // context.Kullanici.Add(admin);
             kullaniciListesi.Add(admin);
           // context.SaveChanges();
            //Kullanıcı oluşturma
            
            Kullanicilar standartUser = new Kullanicilar()
            {
                Adi = "Ahmet",
                Soyadi = "Şahin",
                Email = "ahmet@gmail.com",
                ActivateGuid = Guid.NewGuid(),
                isActive = true,
                isAdmin = false,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddMinutes(5),
                ModifiedUsername = "ondersahin",
                Kuladi = "Onder358",
                Sifre = "123456",
                Telefon = "05548384350",
                ProileImagerFilename = "user_boy.png",
                SehirID = gSehir
            };

            kullaniciListesi.Add(standartUser);
            //context.Kullanici.Add(standartUser);
            //context.SaveChanges();
            //Kullanıcılar oluşturma 
            for (int i = 0; i < 8; i++)
            {
                Kullanicilar user = new Kullanicilar()
                {
                    Adi = FakeData.NameData.GetFirstName(),
                    Soyadi = FakeData.NameData.GetSurname(),
                    Email = FakeData.NetworkData.GetEmail(),
                    ActivateGuid = Guid.NewGuid(),
                    isActive = true,
                    isAdmin = false,
                    CreatedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                    ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                    ModifiedUsername = $"user{i}",
                    Kuladi = $"user{i}",
                    Sifre = "123",
                    Telefon = "5548384350",
                    SehirID = gSehir,
                     ProileImagerFilename = "user_boy.png"
                };
                kullaniciListesi.Add(user);
                //context.Kullanici.Add(user);


            }
             Repository<Kullanicilar>.CreateList(kullaniciListesi);






            List<Universite> universiteListesi = new List<Universite>();

            
            //Fake dabase universite ekleme
            for (int i = 0; i < 10; i++)
            {
                //Üniversite Ekleme
                Universite uni = new Universite()
                {
                    adi = FakeData.PlaceData.GetCity(),
                    Icerik = FakeData.PlaceData.GetAddress(),
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    ModifiedUsername = "ondersahin",
                    SehirID=gSehir,
                    
                };

                universiteListesi.Add(uni);
               // context.Universiteler.Add(uni);
            }
           Repository<Universite>.CreateList(universiteListesi);
           // context.Universiteler.Add(uni);

         

            Barinma barinma = new Barinma()
            {
                Adres = FakeData.PlaceData.GetAddress(),
                CreatedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                Icerik = FakeData.TextData.GetSentence(),
                ModifiedUsername = "ondersahin",
                Tipi = "Yurt",
                SehirID = gSehir,
                ProileImagerFilename= "sah-cihan-kız-yurdu.png"

            };
            //context.Barinmlar.Add(barinma);
            Repository<Barinma>.Create(barinma);

            //Yorumlar 
            List<Yorumlar> yorumListesi = new List<Yorumlar>();
            for (int k = 0; k < FakeData.NumberData.GetNumber(5, 9); k++)
            {
                yorum = new Yorumlar()
                {
                    Icerik = FakeData.TextData.GetSentence(),
                    LikeCount = FakeData.NumberData.GetNumber(1, 9),
                    Owner = (k % 2 == 0) ? admin : standartUser,
                    CreatedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                    ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                    ModifiedUsername = (k % 2 == 0) ? admin.Kuladi : standartUser.Kuladi,
                    SehirlerID=gSehir,
                    
                    
                    

                };
                //context.Yorum.Add(yorum);
                yorumListesi.Add(yorum);
            }
            Repository<Yorumlar>.CreateList(yorumListesi);

            List<Kullanicilar> userlist = Repository<Kullanicilar>.ReadList();
            //Liked adding..
            List<Liked> likesList = Repository<Liked>.ReadList();
            for (int j = 0; j < yorum.LikeCount; j++)
            {
                Liked liked = new Liked()
                {
                    LikedUser = userlist[j],
                    
                };

                likesList.Add(liked);
                //context.Likes.Add(liked);
            }

            Repository<Liked>.CreateList(likesList);


            //Gezilecek yer ekleme
            List<Gezilecekyer> geziList = Repository<Gezilecekyer>.ReadList();
            for (int m = 0; m < FakeData.NumberData.GetNumber(5, 9); m++)
            {
                Gezilecekyer gezilecekyer = new Gezilecekyer()
                {
                    Baslik = "Vizelerden Sonra Güzel Bir Sessizlik",
                    CreatedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                    ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                    Icerik = FakeData.TextData.GetSentence(),
                    ModifiedUsername = "ondersahin",
                   
                   SehirlerID=gSehir,
                   
                };
               // context.Gezilecekyerler.Add(gezilecekyer);
                geziList.Add(gezilecekyer);

            }
            Repository<Gezilecekyer>.CreateList(geziList);

            //Puan ekleme
            List<Puan> puanList = Repository<Puan>.ReadList();

            for (int m = 0; m < FakeData.NumberData.GetNumber(5, 9); m++)
            {
                Puan puan = new Puan()
                {
                    degerler = FakeData.NumberData.GetNumber(1, 10),
                    CreatedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                    ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                    ModifiedUsername = "ondersahin",
                    UniversiteID = Repository<Universite>.Read(x => x.Id == 1),
                    
                    
                };
                 //context.puanlar.Add(puan);
               puanList.Add(puan);
            }
            Repository<Puan>.CreateList(puanList);

            //Yemekler EKleme
            List<Yemekler> yemeklerList = Repository<Yemekler>.ReadList();
            for (int m = 0; m < FakeData.NumberData.GetNumber(5, 9); m++)
            {
                Yemekler yemekler = new Yemekler()
                {
                    Icerik = FakeData.TextData.GetSentence(),
                    SehirID = gSehir,
                    
                    
                };

                //context.Yemek.Add(yemekler);
                yemeklerList.Add(yemekler);
            }
             Repository<Yemekler>.CreateList(yemeklerList);
            //context.SaveChanges();
        }
    }
}
