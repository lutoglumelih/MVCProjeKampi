using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T>
    {
        void Ekle(T parametre);

        void Guncelle(T parametre);

        List<T> Listele();

        List<T> Listele(Expression<Func<T, bool>> Filtrele);

        void Sil(T parametre);

        T Getir(Expression<Func<T, bool>> Filtrele);
    }
}
