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
    public class GiaSPsController : Controller
    {
        private QLCuaHangThucPhamEntities1 db = new QLCuaHangThucPhamEntities1();

        // GET: Admins/GiaSPs
        public ActionResult Index(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {

                searchString = searchString.ToLower();
                return View(db.GiaSPs.Where(x => x.SanPham.TenSP.ToLower().Contains(searchString)).OrderBy(x => x.MaGia).ToList());
            }
            return View(db.GiaSPs.OrderBy(x => x.MaGia).ToList());
        }

        // GET: Admins/GiaSPs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiaSP giaSP = db.GiaSPs.Find(id);
            if (giaSP == null)
            {
                return HttpNotFound();
            }
            return View(giaSP);
        }

        // GET: Admins/GiaSPs/Create
        public ActionResult Create()
        {
            ViewBag.MaSP = new SelectList(db.SanPhams.ToList().Where(x => x.isActive == 0 && x.isDelete == 0).OrderBy(n => n.MaSP), "MaSP", "TenSP");
            return View();
        }

        // POST: Admins/GiaSPs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaGia,MaSP,Gia,Time_Begin,Time_End")] GiaSP giaSP)
        {
            if (ModelState.IsValid)
            {
                if (giaSP.Time_End == null)
                {
                    giaSP.Time_End = DateTime.MaxValue;
                }
                db.GiaSPs.Add(giaSP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //IEnumerable<SelectListItem> MaSP = new SelectList(db.SanPhams.ToList().Where(x => x.isActive == 0 && x.isDelete == 0).OrderBy(n => n.MaSP), "MaSP", "TenSP", giaSP.MaSP);
            ViewBag.MaSP = new SelectList(db.SanPhams.ToList().Where(x => x.isActive == 0 && x.isDelete == 0).OrderBy(n => n.MaSP), "MaSP", "TenSP", giaSP.MaSP);

            return View(giaSP);
        }

        // GET: Admins/GiaSPs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiaSP giaSP = db.GiaSPs.Find(id);
            if (giaSP == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaSP = new SelectList(db.SanPhams.ToList().Where(x => x.isActive == 0 && x.isDelete == 0).OrderBy(n => n.MaSP), "MaSP", "TenSP", giaSP.MaSP);

            return View(giaSP);
        }

        // POST: Admins/GiaSPs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaGia,MaSP,Gia,Time_Begin,Time_End")] GiaSP giaSP)
        {
            if (ModelState.IsValid)
            {
                if (giaSP.Time_End == null)
                {
                    giaSP.Time_End = DateTime.MaxValue;
                }
                db.Entry(giaSP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaSP = new SelectList(db.SanPhams.ToList().Where(x => x.isActive == 0 && x.isDelete == 0).OrderBy(n => n.MaSP), "MaSP", "TenSP", giaSP.MaSP);

            return View(giaSP);
        }

        // GET: Admins/GiaSPs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiaSP giaSP = db.GiaSPs.Find(id);
            if (giaSP == null)
            {
                return HttpNotFound();
            }
            return View(giaSP);
        }

        // POST: Admins/GiaSPs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            GiaSP giaSP = db.GiaSPs.Find(id);
            db.GiaSPs.Remove(giaSP);
            db.SaveChanges();
            return RedirectToAction("Index");
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
