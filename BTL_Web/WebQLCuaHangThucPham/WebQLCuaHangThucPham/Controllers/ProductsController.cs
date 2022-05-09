using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQLCuaHangThucPham.Models;
using PagedList;

namespace WebQLCuaHangThucPham.Controllers
{
    public class ProductsController : Controller
    {
        private QLCuaHangThucPhamEntities1 db = new QLCuaHangThucPhamEntities1();

        //get : laoij sản phẩm trên thanh menu
        public ActionResult SanPham(int? page)
        {
            int pageSize = 12;
            int pagenumber = (page ?? 1);
            List<SanPham> lstSP = db.SanPhams.Where(x => x.isActive == 0 && x.isDelete == 0).ToList();
            ViewBag.MaLoaiHienTai = 0;
            return View(lstSP.ToPagedList(pagenumber, pageSize));
        }
        public PartialViewResult LoaiSanPham()
        {
            return PartialView(db.LoaiSPs.ToList());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="MaLoai"></param>
        /// <param name="value">Là các mốc giá: Tất cả,..</param>
        /// <returns></returns>
        public ActionResult ChiTietLoaiSP(int? page, int MaLoai = 0, int value = 0, int valueSelect = 1, string key = "")
        {
            int pageSize = 12;
            int pagenumber = (page ?? 1);
            ViewBag.MaLoaiHienTai = MaLoai;
            ViewBag.ValueSelect = valueSelect;
            List<SanPham> lstSP = new List<SanPham>();
            List<int> minPrice = new List<int>() { 0, 0, 100000, 500000 };
            List<int> maxPrice = new List<int>() { int.MaxValue, 100000, 500000, int.MaxValue };

            //Xử lí key
            key = key.ToLower();
            //Trường hợp lấy ra tất cả sp
            if (MaLoai == 0)
            {
                lstSP = db.SanPhams.Where(x => x.isActive == 0 && x.isDelete == 0).Where(x => x.TenSP.ToLower().Contains(key) == true). OrderBy(n => n.TenSP).ToList();
            }
            //Lấy theo mã sp truyền vào
            else
            {
                lstSP = db.SanPhams.Where(n => n.MaLoai == MaLoai).Where(x => x.isActive == 0 && x.isDelete == 0).Where(x => x.TenSP.ToLower().Contains(key) == true).OrderBy(n => n.TenSP).ToList();
            }
            //Add giá cho các sản phẩm
            foreach (var item in lstSP)
            {
                double gias = (double)(from Gia in db.GiaSPs where Gia.MaSP == item.MaSP && Gia.Time_Begin < DateTime.Now select Gia.Gia).Single();
                item.Gia = gias;
            }
            //Lọc lần nữa theo giá
            lstSP = lstSP.Where(sp => sp.Gia >= minPrice[value] && sp.Gia < maxPrice[value]).ToList();
            if (valueSelect == 1)
            {
                lstSP = lstSP.ToList();
            }
            else if (valueSelect == 2)
            {
                lstSP = lstSP.OrderByDescending(n => n.Time_Create).ToList();
            }
            else if (valueSelect == 3)
            {
                lstSP = lstSP.OrderBy(n => n.Gia).ToList();
            }
            else if (valueSelect == 4)
            {
                lstSP = lstSP.OrderByDescending(n => n.Gia).ToList();
            }
            if (lstSP.Count == 0)
            {
                ViewBag.lstSanPham = "Không có sản phẩm nào thuộc loại này";
            }

            ViewBag.MaLoai = MaLoai;
            ViewBag.value = value;
            ViewBag.valueSelect = valueSelect;
            ViewBag.key = key;
            ViewBag.lstSanPham = db.SanPhams.ToList();
            return View(lstSP.ToPagedList(pagenumber, pageSize));
        }
        public ActionResult ChiTietSanPham(int MaSP)
        {

            SanPham sp = db.SanPhams.Single(n => n.MaSP == MaSP);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.Anh = db.AnhSPs.Where(n => n.MaSP == MaSP).Take(4).ToList();
            //ViewBag.Gia = db.GiaSPs.Single(n => n.MaSP == MaSP && n.Time_Begin < DateTime.Now ).Gia;
            ViewBag.Gia = (from gia in db.GiaSPs where gia.MaSP == MaSP && gia.Time_Begin < DateTime.Now select gia.Gia).Single();
            //ViewBag.Anh = (from anh in db.AnhSPs where anh.MaSP == MaSP select anh).ToList();
            return View(sp);
        }
        //sản phẩm tương tự 
        public ActionResult SanPhamTuongTu(int MaLoaiSP)
        {
            List<SanPham> lstSP = db.SanPhams.Where(x => x.isActive == 0 && x.isDelete == 0 && x.MaLoai == MaLoaiSP).OrderBy(n => n.TenSP).ToList();
            return PartialView(lstSP);
        }
        public PartialViewResult ListSanPham(string masp)
        {
            var sp = db.SanPhams.Where(x => x.isActive == 0 && x.isDelete == 0).ToList();
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return PartialView(sp);
        }
    }
}