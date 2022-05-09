using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQLCuaHangThucPham.Models;

namespace WebQLCuaHangThucPham.Controllers
{
    public class KienThucController : Controller
    {
        private QLCuaHangThucPhamEntities1 db = new QLCuaHangThucPhamEntities1();

        // GET: TinTuc
        public ActionResult Kienthuc()
        {
            return View(db.TinTucs.ToList());
        }
    }
}