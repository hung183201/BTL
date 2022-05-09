using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebQLCuaHangThucPham.Models;

namespace WebQLCuaHangThucPham.Controllers
{
    public class GioHangController : Controller
    {
        private QLCuaHangThucPhamEntities1 db = new QLCuaHangThucPhamEntities1();

        // GET: GioHang
        public List<GioHang> LayGioHang()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang == null)
            {
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }

        public ActionResult ThemGioHang(int MaSP, string strUrl, int Sl)
        {
            SanPham sanpham = db.SanPhams.SingleOrDefault(n => n.MaSP == MaSP);
            if (sanpham == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<GioHang> lstGioHang = LayGioHang();
            GioHang spgh = lstGioHang.Find(n => n.MaSP == MaSP);
            if (spgh == null)
            {
                spgh = new GioHang(MaSP, Sl);
                lstGioHang.Add(spgh);
                return Json("200");
            }
            else
            {
                spgh.SL += Sl;
                return Json("200");
            }

        }

        public ActionResult GioHang()
        {
            if (Session["GioHang"] == null)
            {
                RedirectToAction("Index", "TrangChu");
            }
            List<GioHang> lstGioHang = LayGioHang();
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return View(lstGioHang);
        }

        public PartialViewResult CartGioHang()
        {
            if (Session["GioHang"] == null)
            {
                RedirectToAction("Index", "TrangChu");
            }
            List<GioHang> lstGioHang = LayGioHang();
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return PartialView(lstGioHang);
        }

        private int TongSoLuong()
        {
            int iTongSL = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                /*iTongSL = lstGioHang.Sum(n => n.SL);*/
                iTongSL = lstGioHang.GroupBy(sp => sp.MaSP).Count();
            }
            return iTongSL;
        }

        private double TongTien()
        {
            double dTongTien = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                dTongTien = lstGioHang.Sum(n => n.ThanhTien);
            }
            ViewBag.TongTien = dTongTien;
            return dTongTien;
        }

        public ActionResult GioHangPartial()
        {
            ViewBag.TongSoLuong = 0;
            if (TongSoLuong() != 0)
            {
                ViewBag.TongSoLuong = TongSoLuong();
            }
            return PartialView();
        }

        public ActionResult XoaGioHang(int MaSP)
        {
            SanPham sanpham = db.SanPhams.SingleOrDefault(n => n.MaSP == MaSP);
            if (sanpham == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<GioHang> lstGioHang = LayGioHang();
            // ktra san pham co trong gio hang khong
            GioHang sp = lstGioHang.SingleOrDefault(n => n.MaSP == MaSP);
            if (sp != null)
            {
                lstGioHang.RemoveAll(n => n.MaSP == MaSP);
            }
            if (lstGioHang.Count == 0)
            {
                RedirectToAction("SanPham", "Products");
            }
            return RedirectToAction("GioHang", "GioHang");
        }

        public ActionResult CapNhatGioHang(List<int> listMaSP, List<int> listSL)
        {
            List<GioHang> lstGioHang = LayGioHang();
            for (int i = 0; i < listMaSP.Count; i++)
            {
                GioHang sp = lstGioHang.SingleOrDefault(n => n.MaSP == listMaSP[i]);
                sp.SL = listSL[i];
            }
            //kiểm tra sản phẩm có trong giỏ hàng không
            return Json("200");
        }
    }
}