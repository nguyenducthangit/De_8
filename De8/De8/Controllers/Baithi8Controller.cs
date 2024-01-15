using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using De8.Models.Entities;
namespace De8.Controllers
{
    public class Baithi8Controller : Controller
    {
		Model1 db = new Model1();

		// GET: Baithi8
		public ActionResult Index()
        {
            return View();
        }
        public ActionResult Renderphanloaiphu()
        {

			List<PhanLoaiPhu> danhsach = db.PhanLoaiPhu.ToList();
            return PartialView("PhanLoaiPhu",danhsach);
        } 
        public ActionResult RenderSanpham()
        {
            List<SanPham> sanPhams = db.SanPham.ToList();
            return PartialView("SanPham",sanPhams);
        }
        public ActionResult RenderSanPhamBangPhanLoaiPhu(string maPhanLoaiPhu)
        {
            List<SanPham> sanPhams = db.SanPham.Where(x => x.MaPhanLoaiPhu.Equals(maPhanLoaiPhu)).ToList();
            return PartialView("SanPham", sanPhams);

		}
	}
}