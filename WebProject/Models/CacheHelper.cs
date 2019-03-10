using SehrimiTani.BusinessLayer;
using SehrimiTani.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace WebProject.Models
{
    public class CacheHelper
    {
        public static List<Yorumlar> GetCategoriesFromCache()
        {
            var result = WebCache.Get("yorum-cache");

            if (result == null)
            {
                YorumlarManager yorumlarManager = new YorumlarManager();
                result = yorumlarManager.List();

                WebCache.Set("yorum-cache", result, 20, true);
            }

            return result;
        }

        public static void RemoveCategoriesFromCache()
        {
            Remove("yorum-cache");
        }

        public static void Remove(string key)
        {
            WebCache.Remove(key);
        }
    }
}