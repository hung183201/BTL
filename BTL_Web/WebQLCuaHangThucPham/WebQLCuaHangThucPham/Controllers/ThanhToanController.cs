using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQLCuaHangThucPham.Models;


namespace WebQLCuaHangThucPham.Controllers
{
    public class ThanhToanController : Controller
    {
        private QLCuaHangThucPhamEntities1 db = new QLCuaHangThucPhamEntities1();

        // GET: ThanhToan
        public ActionResult Index()
        {
            if (Session["GioHang"] == null)
            {
                RedirectToAction("Index", "TrangChu");
            }
            List<GioHang> lstGioHang = LayGioHang();
            ViewBag.TongTien = TongTien();
            return View(lstGioHang);
        }
        //lấy giot hàng
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
        public ActionResult DatHang(int value = 1)
        {
            if (Session["GioHang"] == null)
            {
                RedirectToAction("Index", "TrangChu");
            }
            if (CurrentUser.MaKH == 0)
            {
                return RedirectToAction("Index", "ThanhToan");
            }
            List<GioHang> lstGioHang = LayGioHang();
            ViewBag.TongTien = TongTien();
            if (value == 2)
            {
                ViewBag.PhuongThuc = "Chuyển khoản ngân hàng";
            }
            else
            {
                ViewBag.PhuongThuc = "Trả tiền mặt khi nhận hàng";
            }
            DonHang hoadon = new DonHang();

            try
            {
                //Luu thong tin vao hoa don
                hoadon.Time_Create = DateTime.Now;
                hoadon.MaKH = CurrentUser.MaKH;
                hoadon.Money = (decimal?)TongTien();
                db.DonHangs.Add(hoadon);
                db.SaveChanges();
            }
            catch
            {

            }
            //luu thong tin vao chi tiet hopa don
            foreach (var item in lstGioHang)
            {
                CTDH cthd = new CTDH();
                cthd.MaDH = hoadon.MaDH;
                cthd.MaSP = item.MaSP;
                cthd.SoLuong = item.SL;
                db.CTDHs.Add(cthd);
            }
            db.SaveChanges();
            //luu thong tin vao thong tin don hang
            foreach (var item in lstGioHang)
            {
                TTDH tt = new TTDH();
                tt.MaDH = hoadon.MaDH;
                tt.Tong = (decimal?)TongTien();
                tt.PTTT = ViewBag.PhuongThuc;
                db.TTDHs.Add(tt);
            }
            db.SaveChanges();
            ViewBag.MaDH = hoadon.MaDH;
            return RedirectToAction("ThongTinDatHang", "ThanhToan", new { PhuongThuc = ViewBag.PhuongThuc, MaDH = ViewBag.MaDH });
        }

        public ActionResult ThongTinDatHang(string PhuongThuc, int MaDH)
        {
            List<GioHang> lstGioHang = LayGioHang();
            ViewBag.PhuongThuc = PhuongThuc;
            ViewBag.TongTien = TongTien();
            ViewBag.MaDH = MaDH;
            ViewBag.lstGH = lstGioHang;
            return View(lstGioHang);
        }
        public ActionResult RestartGioHang()
        {
            Session["GioHang"] = "";
            return RedirectToAction("SanPham","Products");
        }

    }
}