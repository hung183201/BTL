using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQLCuaHangThucPham.Models;
using PagedList;
namespace WebQLCuaHangThucPham.Controllers
{
    public class TimKiemController : Controller
    {
        private QLCuaHangThucPhamEntities1 db = new QLCuaHangThucPhamEntities1();

        [HttpPost]
        public ActionResult TimKiem(string key, int? page)
        {
            ViewBag.keyword = key;
            List<SanPham> lstKQ = db.SanPhams.Where(n => n.TenSP.Contains(key)).ToList();
            int pagenumber = (page ?? 1);
            int pagesize = 12;
            if (lstKQ.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm nào, bạn có thể tham khảo các sản phẩm dưới đây";
                return View(db.SanPhams.OrderBy(n => n.TenSP).ToPagedList(pagenumber, pagesize));
            }
            ViewBag.ThongBao = "Đã tìm thấy " + lstKQ.Count + " kết quả";
            return View(lstKQ.OrderBy(n => n.TenSP).ToPagedList(pagenumber, pagesize));
        }
        [HttpGet]
        public ActionResult TimKiem(int? page, string key)
        {
            ViewBag.keyword = key;
            key = key.ToLower();
            List<SanPham> lstKQ = db.SanPhams.Where(n => n.TenSP.ToLower().Contains(key)).ToList();
            int pagenumber = (page ?? 1);
            int pagesize = 12;
            if (lstKQ.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm nào";
                return View(db.SanPhams.OrderBy(n => n.TenSP).ToPagedList(pagenumber, pagesize));
            }
            ViewBag.ThongBao = "Đã tìm thấy " + lstKQ.Count + " kết quả";
            return View(lstKQ.OrderBy(n => n.TenSP).ToPagedList(pagenumber, pagesize));
        }
    }
}