using CaracalSoft.Data;
using SehrimiTani.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SehrimiTani.DataAccessLayer.EntitiyFreamwork
{
    /* Bu methodu Database sürekli yenilendiği için 
    Forign Key olan tabloları karşılaştırma yapılamaz 
    Buradaki hatanın çözümü sadece Signle Ton ile 
    Çözülür burada database eğer yoksa oluşturulur varsa lock kitleme yapılır*/
    public class RepositoryBase
    {
        protected static DatabaseContext context;
        private static object _lockSyns = new object();
        protected RepositoryBase()
        {
           CreareContext();
        }
        private static void CreareContext()
        {
            if (context == null)
            {
                lock (_lockSyns)
                {
                    if (context == null)
                    {
                        context = new DatabaseContext();
                        
                    }
                   
                }
                
            }
            Data.DB = context;
        }

    }
        
 
}
