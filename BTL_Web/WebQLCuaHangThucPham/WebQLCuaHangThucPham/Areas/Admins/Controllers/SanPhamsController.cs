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
    public class SanPhamsController : Controller
    {
        private QLCuaHangThucPhamEntities1 db = new QLCuaHangThucPhamEntities1();

        // GET: Admins/SanPhams
        public ActionResult Index(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();
                return View(db.SanPhams.Where(x => x.TenSP.ToLower().Contains(searchString)).ToList());
            }
            //ViewBag.sanpham = db.SanPhams.Where(x => x.isDelete == 0 && x.isActive == 0).ToList();
            return View(db.SanPhams.Where(x => x.isDelete == 0).OrderByDescending(x => x.Time_Update).ToList());
        }

        // GET: Admins/SanPhams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // GET: Admins/SanPhams/Create
        public ActionResult Create()
        {
            ViewBag.MaLoai = new SelectList(db.LoaiSPs.OrderBy(n => n.MaLoai), "MaLoai", "TenLoai");
            //ViewBag.MaLoai = new SelectList(db.LoaiSPs.OrderBy(n => n.MaLoai), "MaLoai", "TenLoai");
            return View();
        }

        // POST: Admins/SanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "MaSP,TenSP,GTSP,MaLoai,SL,Time_Create,Time_Update,NguoiTao,isActive,isDelete")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                if (sanPham.Time_Create == null) sanPham.Time_Create = DateTime.Now;
                if (sanPham.Time_Update == null) sanPham.Time_Update = DateTime.Now;
                sanPham.isDelete = 0;
                db.SanPhams.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoai = new SelectList(db.LoaiSPs.OrderBy(n => n.MaLoai), "MaLoai", "TenLoai");
            return View(sanPham);
        }

        // GET: Admins/SanPhams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            // tạo nguồn dữ liệu cho danh mục
            ViewBag.MaLoai = new SelectList(db.LoaiSPs, "MaLoai", "TenLoai", sanPham.MaLoai);
            return View(sanPham);
        }

        // POST: Admins/SanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "MaSP,TenSP,GTSP,MaLoai,SL,Time_Create,Time_Update,NguoiTao,isActive,isDelete")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                sanPham.Time_Update = DateTime.Now;
                sanPham.isDelete = 0;
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoai = new SelectList(db.LoaiSPs, "MaLoai", "TenLoai", sanPham.MaLoai);
            return View(sanPham);
        }

        // GET: Admins/SanPhams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // POST: Admins/SanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
         public ActionResult Delete([Bind(Include = "MaSP,TenSP,GTSP,MaLoai,SL,Time_Create,Time_Update,NguoiTao,isActive,isDelete")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                sanPham.Time_Update = DateTime.Now;
                sanPham.isDelete = 1;
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoai = new SelectList(db.LoaiSPs, "MaLoai", "TenLoai", sanPham.MaLoai);
            return View(sanPham);
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
