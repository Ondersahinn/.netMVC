using SehrimiTani.Common;
using SehrimiTani.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProject.init
{
    public class WebCommon:ICommon
    {
        public string GetCurrentUsername()
        {
            if (HttpContext.Current.Session["login"]!=null)
            {
                Kullanicilar user = HttpContext.Current.Session["login"] as Kullanicilar;
                return user.Kuladi;
            }
            return "System";
        }
    }
}