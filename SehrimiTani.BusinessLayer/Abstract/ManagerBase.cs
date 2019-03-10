using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SehrimiTani.Core.DataAccess;
using SehrimiTani.Entities;
using SehrimiTani.DataAccessLayer.EntitiyFreamwork;

namespace SehrimiTani.BusinessLayer.Abstract
{
    public abstract class ManagerBase<T> : IDataAccess<T> where T:class
    {
        private Repositoriy<T> repo = new Repositoriy<T>(); 
        public List<T> List(Expression<Func<T, bool>> where)
        {
            throw new NotImplementedException();
        }
        public virtual List<T> List()
        {
            return repo.List();
        }
        public virtual int Insert(T obj)
        {
           return repo.Insert(obj);
        }
        public virtual int Update(T obj)
        {

           return repo.Update(obj);
        }
        public virtual int Delete(T obj)
        {
            return repo.Delete(obj);

        }
        public virtual int Save()
        {
            return repo.Save();
        }
        public virtual IQueryable<T> ListQueryable()
        {
            return repo.ListQueryable();
        }
        public virtual T Find(Expression<Func<T, bool>> where)
        {
            return repo.Find(where);


        }
    }
}
