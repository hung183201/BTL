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
    public class LoaiSPsController : Controller
    {
        private QLCuaHangThucPhamEntities1 db = new QLCuaHangThucPhamEntities1();

        // GET: Admins/LoaiSPs
        public ActionResult Index()
        {
            return View(db.LoaiSPs.Where(x => x.isDelete != 1).ToList());
        }

        // GET: Admins/LoaiSPs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiSP loaiSP = db.LoaiSPs.Find(id);
            if (loaiSP == null)
            {
                return HttpNotFound();
            }
            return View(loaiSP);
        }

        // GET: Admins/LoaiSPs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admins/LoaiSPs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Maloai,TenLoai,Time_Create,Time_Update,NguoiTao,isActive,isDelete")] LoaiSP loaiSP)
        {
            if (ModelState.IsValid)
            {
                if (loaiSP.Time_Create == null) loaiSP.Time_Create = DateTime.Now;
                if (loaiSP.Time_Update == null) loaiSP.Time_Update = DateTime.Now;
                loaiSP.isDelete = 0;
                db.LoaiSPs.Add(loaiSP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaiSP);
        }

        // GET: Admins/LoaiSPs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiSP loaiSP = db.LoaiSPs.Find(id);
            if (loaiSP == null)
            {
                return HttpNotFound();
            }
            return View(loaiSP);
        }

        // POST: Admins/LoaiSPs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Maloai,TenLoai,Time_Create,Time_Update,NguoiTao,isActive,isDelete")] LoaiSP loaiSP)
        {
            if (ModelState.IsValid)
            {
                loaiSP.Time_Update = DateTime.Now;
                db.Entry(loaiSP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaiSP);
        }

        // GET: Admins/LoaiSPs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiSP loaiSP = db.LoaiSPs.Find(id);
            if (loaiSP == null)
            {
                return HttpNotFound();
            }
            return View(loaiSP);
        }

        // POST: Admins/LoaiSPs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete([Bind(Include = "Maloai,TenLoai,Time_Create,Time_Update,NguoiTao,isActive,isDelete")] LoaiSP loaiSP)
        {
            if (ModelState.IsValid)
            {
                loaiSP.Time_Update = DateTime.Now;
                loaiSP.isDelete = 1;
                db.Entry(loaiSP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaiSP);
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
