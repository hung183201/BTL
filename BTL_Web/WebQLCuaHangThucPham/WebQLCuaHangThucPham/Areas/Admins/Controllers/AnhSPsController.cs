using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebQLCuaHangThucPham.Models;
using PagedList;

namespace WebQLCuaHangThucPham.Areas.Admins.Controllers
{
    public class AnhSPsController : Controller
    {
        private QLCuaHangThucPhamEntities1 db = new QLCuaHangThucPhamEntities1();

        // GET: Admins/AnhSPs
        public ActionResult Index(string searchString)
        {

            if (!String.IsNullOrEmpty(searchString))
            {

                searchString = searchString.ToLower();
                return View(db.AnhSPs.Where(x => x.SanPham.TenSP.ToLower().Contains(searchString)).ToList());
            }
            //return View(books.ToList());
            return View(db.AnhSPs.OrderBy(x => x.MaSP).ToList());
        }

       

        // GET: Admins/AnhSPs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnhSP anhSP = db.AnhSPs.Find(id);
            if (anhSP == null)
            {
                return HttpNotFound();
            }
            return View(anhSP);
        }

        // GET: Admins/AnhSPs/Create
        public ActionResult Create()
        {
            ViewBag.MaSP = new SelectList(db.SanPhams.ToList().Where(x => x.isActive == 0 && x.isDelete == 0).OrderBy(n => n.MaSP), "MaSP", "TenSP");
            return View();
        }

        // POST: Admins/AnhSPs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Create([Bind(Include = "MaAnh,MaSP,TenAnh,URL")] AnhSP anhSP, HttpPostedFileBase image)
        {
           
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    image.SaveAs(Server.MapPath("~/Content/Frond/img/" + image.FileName));
                    anhSP.URL = System.IO.Path.GetFileName(image.FileName);
                }
                db.AnhSPs.Add(anhSP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaSP = new SelectList(db.SanPhams.ToList().Where(x => x.isActive == 0 && x.isDelete == 0).OrderBy(n => n.MaSP), "MaSP", "TenSP", anhSP.MaSP);
            return View(anhSP);
        }

        // GET: Admins/AnhSPs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnhSP anhSP = db.AnhSPs.Find(id);
            if (anhSP == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaSP = new SelectList(db.SanPhams.ToList().Where(x => x.isActive == 0 && x.isDelete == 0).OrderBy(n => n.MaSP), "MaSP", "TenSP", anhSP.MaSP);
            return View(anhSP);
        }

        // POST: Admins/AnhSPs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "MaAnh,MaSP,TenAnh,URL")] AnhSP anhSP, HttpPostedFileBase image, FormCollection form)
        {
           
            if (ModelState.IsValid)
            {
                try
                {
                    if (image != null)
                    {
                        string _FileName = Path.GetFileName(image.FileName);
                        string _path = Path.Combine(Server.MapPath("~/Content/Frond/img"), _FileName);
                        image.SaveAs(_path);
                        anhSP.URL = _FileName;
                        // get Path of old image for deleting it
                        _path = Path.Combine(Server.MapPath("~/Content/Frond/img"), form["oldimage"]);
                        if (System.IO.File.Exists(_path))
                            System.IO.File.Delete(_path);
                        db.Entry(anhSP).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else { 
                        anhSP.URL = form["oldimage"];
                        db.Entry(anhSP).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                   
                }
                catch (Exception)
                {
                    ViewBag.Message = "không thành công!!";
                }
                return RedirectToAction("Index");
                //AnhSP a = db.AnhSPs.Find(anhSP.MaAnh);
                //if (image != null)
                //{
                //    image.SaveAs(Server.MapPath("~/Content/Frond/img/" + image.FileName));
                //    anhSP.URL = System.IO.Path.GetFileName(image.FileName);
                //}
                //db.Entry(anhSP).State = EntityState.Modified;
                //db.SaveChanges();
                //return RedirectToAction("Index");
            }
            ViewBag.MaSP = new SelectList(db.SanPhams.ToList().Where(x => x.isActive == 0 && x.isDelete == 0).OrderBy(n => n.MaSP), "MaSP", "TenSP", anhSP.MaSP);
            return View(anhSP);
        }

        // GET: Admins/AnhSPs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnhSP anhSP = db.AnhSPs.Find(id);
            if (anhSP == null)
            {
                return HttpNotFound();
            }
            return View(anhSP);
        }

        // POST: Admins/AnhSPs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            AnhSP anhSP = db.AnhSPs.Find(id);
            db.AnhSPs.Remove(anhSP);
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
