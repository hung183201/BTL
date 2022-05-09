using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebQLCuaHangThucPham.Models;

namespace WebQLCuaHangThucPham.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        QLCuaHangThucPhamEntities1 db = new QLCuaHangThucPhamEntities1();
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangKy(KhachHang kh)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (kh.Time_Create == null) kh.Time_Create = DateTime.Now;
                    if (kh.Time_Update == null) kh.Time_Update = DateTime.Now;
                    kh.isDelete = 0;
                    kh.isActive = 0;
                    db.KhachHangs.Add(kh);
                    db.SaveChanges();
                    return Json("200");
                }
                else
                {
                    return Json("404");
                }
            }
            catch
            {
                return Json("404");
            }
        }

        [HttpGet]
        public ActionResult DangNhap()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult DN(string taikhoan, string matkhau)
        {
            KhachHang kh = db.KhachHangs.SingleOrDefault(n => n.TaiKhoan == taikhoan && n.MatKhau == matkhau);
            if (kh != null)
            {
                Session["TaiKhoan"] = kh;
                //Lưu thông tin đăng nhập
                FormsAuthentication.SetAuthCookie(kh.MaKH.ToString() + "|" + kh.HoTen + "|" + kh.DiaChi + "|" + kh.SDT + "|" + kh.Email, true); //id:1,ten:hieu => format: 1|hieu
                //Xử lí phân quyền
                if(kh.Admin == 1)
                {
                    //admin
                    return Json("201");
                }
                else
                {
                    //khachhang
                    return Json("202");
                }
                
            }
            else
            {
                return Json("404");
            }
        }

        public ActionResult DangXuat()
        {
            //Xoa coockie di
            FormsAuthentication.SignOut();
            return Redirect("/trangchu");
        }

    }
}