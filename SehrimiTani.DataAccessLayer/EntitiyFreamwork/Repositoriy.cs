using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SehrimiTani.Entities;

using System.Data.Entity;
using System.Linq.Expressions;
using SehrimiTani.Core.DataAccess;
using SehrimiTani.Common;

namespace SehrimiTani.DataAccessLayer.EntitiyFreamwork
{
   public class Repositoriy<T>:RepositoryBase, IDataAccess<T> where T:class
    {
        private DbSet<T> _objectSet;
        public Repositoriy()
        {
            
            _objectSet = context.Set<T>();
        }
        public List<T> List (Expression<Func<T, bool>> where)
        {
            return _objectSet.Where(where).ToList();
        }
        public List<T> List()
        {
            return _objectSet.ToList();
        }
        public int Insert(T obj)
        {
            _objectSet.Add(obj);
            if (obj is MyEntitiyBase)
            {
                MyEntitiyBase o = obj as MyEntitiyBase;
                DateTime now = DateTime.Now;
                o.CreatedOn = now;
                o.ModifiedOn = now;
                o.ModifiedUsername = App.Common.GetCurrentUsername(); //İşlem Yapan kulanıcı adi
            } 
            return Save();
        }
        public int Update(T obj)
        {
           
            if (obj is MyEntitiyBase)
            {
                MyEntitiyBase o = obj as MyEntitiyBase;

                o.ModifiedOn = DateTime.Now;
                o.ModifiedUsername = App.Common.GetCurrentUsername();//İşlem Yapan kulanıcı adi
            }
            return Save();
        }
        public int Delete(T obj)
        {
            _objectSet.Remove(obj);
            
            return Save();
        }
        public int Save()
        {
            return context.SaveChanges();
        }
        public T Find(Expression<Func<T, bool>> where)
        {
            return _objectSet.FirstOrDefault(where);


        }
        public IQueryable<T> ListQueryable()
        {
            return _objectSet.AsQueryable<T>();
        }
    }
}
