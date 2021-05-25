using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi_UI.Controllers
{
    public class IstatistikController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        WriterManager wm = new WriterManager(new EfWriterDal());

        public ActionResult Index()
        {
            Istatistik _istatistik = new Istatistik();
            _istatistik.KategoriSayisi = cm.GetList().Count;
            _istatistik.BaslikSayisi = hm.GetList().Where(x => x.CategoryID == 5).ToList().Count;
            _istatistik.YazarSayisi = wm.GetList().Where(x => x.WriterName.Contains("a")).ToList().Count;
            var _kategoriler = cm.GetList();
            int _baslikSayisi = 0;
            foreach (var item in _kategoriler)
            {
                var _baslik = hm.GetList().Where(x => x.CategoryID == item.CategoryID).ToList();
                if (_baslik.Count > _baslikSayisi)
                {
                    _baslikSayisi = _baslik.Count;
                    _istatistik.PopulerKategori = item.CategoryName;
                }
            }
            int _aktifKategoriSayisi = cm.GetList().Where(x => x.CategoryStatus == true).ToList().Count;
            int _pasifKategoriSayisi = cm.GetList().Where(x => x.CategoryStatus == false).ToList().Count;
            _istatistik.AktifKategori = _aktifKategoriSayisi - _pasifKategoriSayisi;
            return View(_istatistik);
        }
    }
}