using SehrimiTani.Entities;
using SehrimiTani.Entities.ValueObjects;
using SehrimiTani.DataAccessLayer.EntitiyFreamwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SehrimiTani.Entities.Messages;
using SehrimiTani.Common.Herpers;
using SehrimiTani.BusinessLayer.Result;
using SehrimiTani.BusinessLayer.Abstract;

namespace SehrimiTani.BusinessLayer
{
    public class SehrimiTaniUserManager:ManagerBase<Kullanicilar>
    {


       
        public BusinessLayerResult<Kullanicilar> RegisterUser(RegisterViewModelcs data)
        {
            BusinessLayerResult<Kullanicilar> layerResult = new BusinessLayerResult<Kullanicilar>();
            Kullanicilar user = Find(x => x.Kuladi == data.Username || x.Email == data.EMail);
            if (user != null)
            {
                if (user.Kuladi == data.Username)
                {

                    layerResult.AddError(ErrorMessageCode.UsernameAlreadyExissts, "Böyle bir Kullanıcı adı zaten var");
                }
                if (user.Email == data.EMail)
                {

                    layerResult.AddError(ErrorMessageCode.EmailAlreadyExissts, "Böyle bir e-posta zaten var");
                }
                if (data.Telefon.Length < 10)
                {
                    layerResult.AddError(ErrorMessageCode.PhoneAllReadyExissts, "Telefon alanı hatalıdır.");
                }
            }
            else
            {
                int dbResult = base.Insert(new Kullanicilar
                {
                    Kuladi = data.Username,
                    Email = data.EMail,
                    Sifre = data.Password,
                    Adi = data.Adi,
                    ProileImagerFilename="user_boy.png",
                    Soyadi = data.Soyadi,
                    Telefon = data.Telefon,
                    ActivateGuid = Guid.NewGuid(),

                    isActive = false,
                    isAdmin = false,

                });
                if (dbResult > 0)
                {
                    layerResult.Result = Find(x => x.Email == data.EMail && x.Kuladi == data.Username);
                    string siteUri = ConfigHelper.Get<string>("SiteRootUri");
                    string activateUri = $"{siteUri}/Home/userActivate/{  layerResult.Result.ActivateGuid}";
                    string body = $"Merhaba { layerResult.Result.Adi} { layerResult.Result.Soyadi}  Hesabınızı aktifleştirmek için <a href='{activateUri}' target='_blank'>tıklayınız</a>";
                    MailHelper.SendMail(body, layerResult.Result.Email, "Şehrimi Tanı Aktifleştirme");

                    //Yapılacak: Email atılmalı
                    //layerResult.Result.ActivateGuid
                }
            }
            return layerResult;



        }

        public BusinessLayerResult<Kullanicilar> LoginUser(LoginViewModel data)
        {
            BusinessLayerResult<Kullanicilar> res = new BusinessLayerResult<Kullanicilar>();
            res.Result = Find(x => x.Kuladi == data.KullaniciAdi && x.Sifre == data.Sifre);

            if (res.Result != null)
            {

                if (!res.Result.isActive)
                {
                   
                    res.AddError(ErrorMessageCode.UserIsNotActive, "Kullanıcı aktifleştirilmemiştir. ");
                    res.AddError(ErrorMessageCode.ChecYourEmail, "E-posta adresinizi kontrol ediniz");
                }
            }
            else
            {
                res.AddError(ErrorMessageCode.UsernameORPassWrong, "Kullanıcı adı yada şifre hatalı");
            }
            return res;
        }
        public BusinessLayerResult<Kullanicilar> ActivateUser(Guid id)
        {
            BusinessLayerResult<Kullanicilar> layerResult = new BusinessLayerResult<Kullanicilar>();
            layerResult.Result = Find(x => x.ActivateGuid == id);

            if (layerResult.Result != null)
            {
                if (layerResult.Result.isActive)
                {
                    layerResult.AddError(ErrorMessageCode.UserAllreadyActive, "Kullanıcı zaten aktiif");
                    return layerResult;
                }
                layerResult.Result.isActive = true;
                Update(layerResult.Result);
            }
            else
            {
                layerResult.AddError(ErrorMessageCode.ActivateIdDoesNotExists, "Aktifleştirilecek Bir kullanıcı bulunamadı");
            }
            return layerResult;
        }

        public BusinessLayerResult<Kullanicilar> GetUserById(int id)
        {
            BusinessLayerResult<Kullanicilar> res = new BusinessLayerResult<Kullanicilar>();
            res.Result = Find(x => x.Id == id);
            if (res.Result == null)
            {
                res.AddError(ErrorMessageCode.UserNotFound, "Kullanıcı bulunamadı");
            }
            return res;
        }

        public  BusinessLayerResult<Kullanicilar> UpdateProfile(Kullanicilar data)
        {
            
            Kullanicilar db_user = Find(x => x.Id != data.Id && (x.Kuladi == data.Kuladi || x.Email == data.Email));
            BusinessLayerResult<Kullanicilar> res = new BusinessLayerResult<Kullanicilar>();

            if (db_user != null && db_user.Id != data.Id)
            {
                if (db_user.Kuladi == data.Kuladi)
                {
                    res.AddError(ErrorMessageCode.UsernameAlreadyExissts, "Kullanıcı adı kayıtlı.");
                }

                if (db_user.Email == data.Email)
                {
                    res.AddError(ErrorMessageCode.EmailAlreadyExissts, "E-posta adresi kayıtlı.");
                }

                return res;
            }


            res.Result = Find(x => x.Id == data.Id);
            res.Result.Id = data.Id;
            res.Result.Email = data.Email;
            res.Result.Adi = data.Adi;
            res.Result.Soyadi = data.Soyadi;
            res.Result.Sifre = data.Sifre;
            res.Result.Kuladi = data.Kuladi;
            res.Result.Telefon = data.Telefon;




            if (string.IsNullOrEmpty(data.ProileImagerFilename) == false)
            {
                res.Result.ProileImagerFilename = data.ProileImagerFilename;
            }

            if (base.Update(res.Result) == 0)
            {
                res.AddError(ErrorMessageCode.ProfileCouldNotUpdated, "Profil güncellenemedi.");
            }

            return res;
        }

        public BusinessLayerResult<Kullanicilar> RemoveUserById(int id)
        {
            BusinessLayerResult<Kullanicilar> res = new BusinessLayerResult<Kullanicilar>();
            Kullanicilar user = Find(x => x.Id == id);
            if (user!=null)
            {
                if (Delete(user)==0)
                {
                    res.AddError(ErrorMessageCode.UserCouldNotRemove, "Kullanıcı Silinemedi");
                    return res;
                }
            }
            else
            {
                res.AddError(ErrorMessageCode.UserCouldNotFind, "Kullanıcı Bulunmadı");
            }
            return res;
        }

        public new BusinessLayerResult<Kullanicilar> Insert(Kullanicilar data)
        {
            BusinessLayerResult<Kullanicilar> layerResult = new BusinessLayerResult<Kullanicilar>();
            Kullanicilar user = Find(x => x.Kuladi == data.Kuladi || x.Email == data.Email);
            if (user != null)
            { 
                if (user.Kuladi == data.Kuladi)
                {

                    layerResult.AddError(ErrorMessageCode.UsernameAlreadyExissts, "Böyle bir Kullanıcı adı zaten var");
                }
                if (user.Email == data.Email)
                {

                    layerResult.AddError(ErrorMessageCode.EmailAlreadyExissts, "Böyle bir e-posta zaten var");
                }
                if (data.Telefon.Length < 10)
                {
                    layerResult.AddError(ErrorMessageCode.PhoneAllReadyExissts, "Telefon alanı hatalıdır.");
                }
            }
            else
            {
                data.ActivateGuid = Guid.NewGuid();
                data.ProileImagerFilename = "user_boy.png";
                if (base.Insert(data) == 0)
                {
                    layerResult.AddError(ErrorMessageCode.UserCouldNotInserted,"Kullanıcı Eklenemdi.");
                }
            
            }
            return layerResult;

        }

        public new BusinessLayerResult<Kullanicilar>  Update(Kullanicilar data)
        {
            Kullanicilar db_user = Find(x => x.Id != data.Id && (x.Kuladi == data.Kuladi || x.Email == data.Email));
            BusinessLayerResult<Kullanicilar> res = new BusinessLayerResult<Kullanicilar>();
            res.Result = data;
            if (db_user != null && db_user.Id != data.Id)
            {
                if (db_user.Kuladi == data.Kuladi)
                {
                    res.AddError(ErrorMessageCode.UsernameAlreadyExissts, "Kullanıcı adı kayıtlı.");
                }

                if (db_user.Email == data.Email)
                {
                    res.AddError(ErrorMessageCode.EmailAlreadyExissts, "E-posta adresi kayıtlı.");
                }

                return res;
            }


            res.Result = Find(x => x.Id == data.Id);
            res.Result.Email = data.Email;
            res.Result.Adi = data.Adi;
            res.Result.Soyadi = data.Soyadi;
            res.Result.Sifre = data.Sifre;
            res.Result.Kuladi = data.Kuladi;
            res.Result.Telefon = data.Telefon;
            res.Result.isActive = data.isActive;
            res.Result.isAdmin = data.isAdmin;


            if (base.Update(res.Result) == 0)
            {
                res.AddError(ErrorMessageCode.UserCouldNotUpdate, "Kullanıcı güncellenemedi.");
            }

            return res;
        }
    }
}
