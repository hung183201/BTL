using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQLCuaHangThucPham.Models;

namespace WebQLCuaHangThucPham.Controllers
{
    public class TrangChuController : Controller
    {
        // GET: TrangChu
        private QLCuaHangThucPhamEntities1 db = new QLCuaHangThucPhamEntities1();
        public ActionResult Index()
        {
            return View(db.SanPhams.Where(x => x.isActive == 0 && x.isDelete == 0).OrderByDescending(x => x.Time_Create).Take(8).ToList());
        }
        public PartialViewResult KM()
        {
            return PartialView(db.SanPhams.Where(x => x.isActive == 0 && x.isDelete == 0).ToList());
        }
    }
}