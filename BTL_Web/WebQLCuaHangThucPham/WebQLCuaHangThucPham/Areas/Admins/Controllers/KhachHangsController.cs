using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebQLCuaHangThucPham.Models;

namespace WebQLCuaHangThucPham.Areas.Admins.Controllers
{
    public class KhachHangsController : Controller
    {
        private QLCuaHangThucPhamEntities1 db = new QLCuaHangThucPhamEntities1();

        // GET: Admins/KhachHangs
        public ActionResult Index(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();
                return View(db.KhachHangs.Where(x => x.HoTen.ToLower().Contains(searchString)).Where(x => x.isDelete == 0).ToList());
            }
            return View(db.KhachHangs.Where(x => x.isDelete == 0).ToList());
        }

        // GET: Admins/KhachHangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // GET: Admins/KhachHangs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admins/KhachHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKH,HoTen,GioiTinh,Tuoi,Email,SDT,Time_Create,Time_Update,NguoiTao,isActive,isDelete,TaiKhoan,Mật khẩu ,Admin,DiaChi")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                if (khachHang.Time_Create == null) khachHang.Time_Create = DateTime.Now;
                if (khachHang.Time_Update == null) khachHang.Time_Update = DateTime.Now;
                khachHang.isDelete = 0;
                db.KhachHangs.Add(khachHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(khachHang);
        }

        // GET: Admins/KhachHangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // POST: Admins/KhachHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKH,HoTen,GioiTinh,Tuoi,Email,SDT,Time_Create,Time_Update,NguoiTao,isActive,isDelete")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                khachHang.Time_Update = DateTime.Now;
                db.Entry(khachHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(khachHang);
        }

        // GET: Admins/KhachHangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // POST: Admins/KhachHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete([Bind(Include = "MaKH,HoTen,GioiTinh,Tuoi,Email,SDT,Time_Create,Time_Update,NguoiTao,isActive,isDelete")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                khachHang.Time_Update = DateTime.Now;
                khachHang.isDelete = 1;
                db.Entry(khachHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(khachHang);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
