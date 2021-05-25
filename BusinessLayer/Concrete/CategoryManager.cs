using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {

        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public Category GetByID(int id)
        {
            return _categoryDal.Getir(x => x.CategoryID == id);
        }

        public List<Category> GetList()
        {
            return _categoryDal.Listele();
        }

        public void CategoryAdd(Category category)
        {
            _categoryDal.Ekle(category);
        }

        public void CategoryDelete(Category category)
        {
            _categoryDal.Sil(category);
        }

        public void CategoryUpdate(Category category)
        {
            _categoryDal.Guncelle(category);
        }
    }
}
