using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {

        Context c = new Context();
        DbSet<T> _object;

        public GenericRepository()
        {
            _object = c.Set<T>();
        }

        public void Ekle(T parametre)
        {
            var addedEntity = c.Entry(parametre);
            addedEntity.State = EntityState.Added;
            c.SaveChanges();
        }

        public T Getir(Expression<Func<T, bool>> Filtrele)
        {
            return _object.SingleOrDefault(Filtrele);
        }

        public void Guncelle(T parametre)
        {
            var updatedEntity = c.Entry(parametre);
            updatedEntity.State = EntityState.Modified;
            c.SaveChanges();
        }

        public List<T> Listele()
        {
            return _object.ToList();
        }

        public List<T> Listele(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Sil(T parametre)
        {
            var deletedEntity = c.Entry(parametre);
            deletedEntity.State = EntityState.Deleted;
            c.SaveChanges();
        }
    }
}
