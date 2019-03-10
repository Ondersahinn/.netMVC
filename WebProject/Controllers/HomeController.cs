using SehrimiTani.BusinessLayer;
using SehrimiTani.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SehrimiTani.Entities.ValueObjects;
using SehrimiTani.Entities.Messages;
using WebProject.ViewModels;
using SehrimiTani.BusinessLayer.Result;

namespace WebProject.Controllers
{
    public class HomeController : Controller
    {
        private SehirlerManager sehirlerManager = new SehirlerManager();
        private SehrimiTaniUserManager sehrimiTaniUserManager = new SehrimiTaniUserManager();

        public ActionResult Index()
        {
            
            return View(sehirlerManager.List());
            
            // SehrimiTani.BusinessLayer.Test test = new SehrimiTani.BusinessLayer.Test();
            //test.InsertTest();
            //test.UptadeTest();
            //test.DeleteTest();
            //test.YorumTest();
            //return View();

        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
               
                BusinessLayerResult<Kullanicilar> res = sehrimiTaniUserManager.LoginUser(model);
                if (res.Errors.Count > 0)
                {
                   
                    res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                    
                    return View(model);
                }

                Session["login"] = res.Result;      //Session Kullanıcı Bilgileri buradadır.
                return RedirectToAction("Index");   //Giriş Oldu artık anasafaya git
            }
            return View(model);
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
           
        }
        public ActionResult Register()
        {
            
            //Kullanıcı username kontrolü
            //Kullanıcı eposta kontrolü
            //Kayıt işlemi
            //aktivasyon eposta gönderimi
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModelcs model)
        {
            if (ModelState.IsValid)
            {
                BusinessLayerResult<Kullanicilar> res = sehrimiTaniUserManager.RegisterUser(model);
                if (res.Errors.Count>0)
                {
                    res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                    return View(model);
                }

                //try
                //{
                //   user= sum.RegisterUser(model);
                //}
                //catch (Exception ex)
                //{

                //    ModelState.AddModelError("", ex.Message);
                //}


                //Eğer Sayfada Direk Yönlendirirsek Bizim Web Projemizin Data ya Ulaşmasını 
                //Sağlamalıyız Burada işi Yapan Business Layer olmalı
                //UI--BL-Dal hiyerarşi bu şekildedir
                //if (model.Username == "aaa")
                //{
                //    ModelState.AddModelError("", "Kullanıcı Adı kullanılıyor.");

                //}
                //if (model.EMail == "aa@gmail.com")
                //{
                //    ModelState.AddModelError("", "E posta adresi kullanılıyor.");

                //}

                //foreach (var item in ModelState)
                //{
                //    if (item.Value.Errors.Count > 0)
                //    {
                //        return View(model);
                //    }
                //}
                //if (user==null)
                //{
                //    return View(model);
                //}
                OkViewModel notifobj = new OkViewModel()
                {
                    Title="Kayıt Başarılı",
                    RedirectingUrl="/Home/Login",
                };
                notifobj.Items.Add(" Lütfen e-posta adresinize gönderdiğimiz aktivasyon linkine tıklayarak " +
                    "hesabınızı aktive ediniz.  Hesabınızı aktive etmeden yorum yapmaz ve şehrinizi tanıyamazsınız.");
                return View("Ok", notifobj);
            }


            return View(model);
        }
        public ActionResult userActivate(Guid id)
        {
            BusinessLayerResult<Kullanicilar> res = sehrimiTaniUserManager.ActivateUser(id);
            
            if (res.Errors.Count>0)
            {
                ErrorViewModel notifObj = new ErrorViewModel()
                {
                    Title="Geçersiz İşlem",
                    Items=res.Errors
                    
                };
              
                return View("ErrorViewModel",notifObj);
            }
            //Kullanıcı E posta Aktivasyonu
            
             OkViewModel okNotifObj = new OkViewModel()
                {
                    Title="Hesap Aktifleştirildi" ,
                    RedirectingUrl="/Home/Index"
                };
                okNotifObj.Items.Add("Hesabınız aktifleştirildi giriş yaparak sizde aramıza katılabilirsiniz");
            Session["login"] = res.Result;
            return View("Ok",okNotifObj);
            
           
        }
        public ActionResult EditProfile()
        {
            Kullanicilar currentUser = Session["login"] as Kullanicilar;
           
         
                BusinessLayerResult<Kullanicilar> res = sehrimiTaniUserManager.GetUserById(currentUser.Id);
            
            

            if (res.Errors.Count > 0)
            {
                ErrorViewModel notifObj = new ErrorViewModel()
                { 
                    Title = "Hata Oluştu",
                    Items = res.Errors

                };

                return View("ErrorViewModel", notifObj);
            }
            //Kullanıcı E posta Aktivasyonu


            return View(res.Result);
            
        }
        [HttpPost]
        public ActionResult EditProfile(Kullanicilar model,HttpPostedFileBase ProfileImage)
        {

            if (ProfileImage != null &&
                    (ProfileImage.ContentType == "image/jpeg" ||
                    ProfileImage.ContentType == "image/jpg" ||
                    ProfileImage.ContentType == "image/png"))
            {
                string filename = $"user_{model.Id}.{ProfileImage.ContentType.Split('/')[1]}";

                ProfileImage.SaveAs(Server.MapPath($"~/images/{filename}"));
                model.ProileImagerFilename = filename;
            }
        
            BusinessLayerResult<Kullanicilar> res = sehrimiTaniUserManager.UpdateProfile(model);

            if (res.Errors.Count > 0)
            {
                ErrorViewModel errorNotifyObj = new ErrorViewModel()
                {
                    Items = res.Errors,
                    Title = "Profil Güncellenemedi.",
                    RedirectingUrl = "/Home/EditProfile"
                };

                return View("Error", errorNotifyObj);
            }

            // Profil güncellendiği için session güncellendi.
            //  CurrentSession.Set<EvernoteUser>("login", res.Result);


            Session["login"] = res.Result;
            return RedirectToAction("ShowProfile");
        }
       
        
        public ActionResult ShowProfile()
        {
            Kullanicilar currentUser = Session["login"] as Kullanicilar;
          
            BusinessLayerResult<Kullanicilar> res = sehrimiTaniUserManager.GetUserById(currentUser.Id);

            if (res.Errors.Count > 0)
            {
                ErrorViewModel notifObj = new ErrorViewModel()
                {
                    Title = "Hata Oluştu",
                    Items = res.Errors

                };

                return View("ErrorViewModel", notifObj);
            }
            //Kullanıcı E posta Aktivasyonu

         
            return View(res.Result);
        }
        public ActionResult DeleteProfile()
        {
            Kullanicilar currentUser = Session["login"] as Kullanicilar;
            
            BusinessLayerResult<Kullanicilar> res = sehrimiTaniUserManager.RemoveUserById(currentUser.Id);

            if (res.Errors.Count > 0)
            {
                ErrorViewModel notifObj = new ErrorViewModel()
                {
                    Title = "Profil Silinmedi",
                    Items = res.Errors,
                    RedirectingUrl="/Home/ShowProfile"

                };

                return View("ErrorViewModel", notifObj);
            }
            //Kullanıcı E posta Aktivasyonu

            Session.Clear();
            return RedirectToAction("Index");
          
        }


        public ActionResult GezilecekYerler()
        {
            //GezilecekyerController View Talebi
            //if (TempData["mm"]!=null)
            //{
            //    return View(TempData["mm"] as List<Gezilecekyer>);
            //}
            GezilecekYerlerManager gm = new GezilecekYerlerManager();
            return View(gm.List());

        }
        public ActionResult Gezi(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            GezilecekYerlerManager gm = new GezilecekYerlerManager();
            Gezilecekyer gezilecekyer = gm.Find(x=>x.Id==id.Value);
            if (gezilecekyer == null)
            {
                return HttpNotFound();
                // return RedirectToAction("GezilecekYerler", "Home");
            }
            //TempData["mm"] = gezilecekyer.Baslik;
            return RedirectToAction("GezilecekYerler", "Home");
        }
        
        public ActionResult Barinma()
        {
            BarinmaManager bm = new BarinmaManager();
            return View(bm.List());

        }
        public ActionResult Yemekler()
        {
            YemeklerManager yemeklerManager = new YemeklerManager();
            return View(yemeklerManager.List());

        }
        public ActionResult Yemkler()
        {
            return View();
        }
        public ActionResult Universiteler()
        {
            return View();
        }
        public ActionResult YonetimIndex()
        {
            return View();
        }
        public ActionResult GenelBakis()
        {
            return View();
        }
        public ActionResult GeziZamani()
        {
            return View();
        }
        public ActionResult SehreBakis()
        {
            return View();
        }
        public ActionResult KendiniGelistir()
        {
            return View();
        }
        public ActionResult YemeklerList()
        {
            YemeklerManager yemeklerManager = new YemeklerManager();

            return View(yemeklerManager.List());
        }
        public ActionResult GezilecekyerList()
        {
            GezilecekYerlerManager gezilecek = new GezilecekYerlerManager();

            return View(gezilecek.List());
        }
        public ActionResult BarinmaList()
        {
            BarinmaManager barinma = new BarinmaManager();
            
            return View(barinma.List());
        }
        public ActionResult _PartialYorumEkle(YorumViewModel data)
        {
           
            return View(data);
        }

    }


}