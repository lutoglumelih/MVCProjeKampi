using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public Writer GetByID(int id)
        {
            return _writerDal.Getir(x => x.WriterID == id);
        }

        public List<Writer> GetList()
        {
            return _writerDal.Listele();
        }

        public void WriterAdd(Writer writer)
        {
            _writerDal.Ekle(writer);
        }

        public void WriterDelete(Writer writer)
        {
            _writerDal.Sil(writer);
        }

        public void WriterUpdate(Writer writer)
        {
            _writerDal.Guncelle(writer);
        }
    }
}
