using SehrimiTani.BusinessLayer.Abstract;
using SehrimiTani.BusinessLayer.Result;
using SehrimiTani.Entities;
using SehrimiTani.Entities.Messages;
using SehrimiTani.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SehrimiTani.BusinessLayer
{
   public class YorumlarManager : ManagerBase<Yorumlar>
    {

        public BusinessLayerResult<Yorumlar> RegisterYorum(YorumViewModel data)
        {
            BusinessLayerResult<Yorumlar> layerResult = new BusinessLayerResult<Yorumlar>();
            Yorumlar user = Find(x => x.Icerik == data.Icerik);
            if (user != null)
            {
                if (user.Icerik == data.Icerik)
                {

                    layerResult.AddError(ErrorMessageCode.ComentNotExsis, "Böyle bir Yorum var");
                }
               
            }
            else
            {
                int dbResult = Insert(new Yorumlar
                {
                    Icerik = data.Icerik,
                    CreatedOn = DateTime.Now,
                    
                    
                });
                
            }
            return layerResult;



        }
    }
}
