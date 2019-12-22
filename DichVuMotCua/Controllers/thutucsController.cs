using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DichVuMotCua.Models;

namespace DichVuMotCua.Controllers
{
    public class thutucsController : Controller
    {
        private DBmodels db = new DBmodels();

        // GET: thutucs
        public ActionResult Index()
        {
            return View(db.thutucs.ToList());
        }

        // GET: thutucs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            thutuc thutuc = db.thutucs.Find(id);
            if (thutuc == null)
            {
                return HttpNotFound();
            }
            return View(thutuc);
        }

        // GET: thutucs/Create
        public ActionResult Create()
        {
            var thongtin = db.loaithutucs.ToList();
            for (int i = 0; i < thongtin.Count; i++)
            {
                if(thongtin[i].loai != 1)
                {
                    thongtin.RemoveAt(i);
                }
            }
            ViewBag.chitietthutuc = thongtin;
            return View();
        }

        // POST: thutucs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,nguoitao,nguoiduyet")] thutuc thutuc)
        {
            if (ModelState.IsValid)
            {
                db.thutucs.Add(thutuc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
            return View(thutuc);
        }

        // GET: thutucs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            thutuc thutuc = db.thutucs.Find(id);
            if (thutuc == null)
            {
                return HttpNotFound();
            }
            return View(thutuc);
        }

        // POST: thutucs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,nguoitao,nguoiduyet")] thutuc thutuc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thutuc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(thutuc);
        }

        // GET: thutucs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            thutuc thutuc = db.thutucs.Find(id);
            if (thutuc == null)
            {
                return HttpNotFound();
            }
            return View(thutuc);
        }

        // POST: thutucs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            thutuc thutuc = db.thutucs.Find(id);
            db.thutucs.Remove(thutuc);
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

        public ActionResult CapGiayChungNhan()
        {
            var thongtin = db.loaithutucs.ToList();
            List<loaithutuc> listID = new List<loaithutuc>();
            for (int i = 0; i < thongtin.Count; i++)
            {
                if (thongtin[i].loai != Constants.CAPGIAYCHUNGNHAN)
                {
                    listID.Add(thongtin[i]);

                }
            }
            foreach (loaithutuc item in listID)
            {
                thongtin.Remove(item);
            }

            ViewBag.chitietthutuc = thongtin;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CapGiayChungNhan([Bind(Include = "id,name")] thutuc thutuc, HttpPostedFileBase file)
        {
            var thongtin = db.loaithutucs.ToList();
            List<loaithutuc> listID = new List<loaithutuc>();
            for (int i = 0; i < thongtin.Count; i++)
            {
                if (thongtin[i].loai != Constants.CAPGIAYCHUNGNHAN)
                {
                    listID.Add(thongtin[i]);

                }
            }
            foreach (loaithutuc item in listID)
            {
                thongtin.Remove(item);
            }

            if (ModelState.IsValid)
            {
                
                //thutuc.ngaytao = DateTime.Today;
                // thutuc.anh = "khongco";
                
                db.thutucs.Add(thutuc);
                
                
                db.SaveChanges();
                thutuc = db.thutucs.OrderByDescending(u => u.id).FirstOrDefault();
                var chitietthutuc = new chitietthutuc();
                for (int i = 0; i < thongtin.Count; i++)
                {
                    chitietthutuc = new chitietthutuc();
                    chitietthutuc.noidung = Request.Form["thutucname" + i];
                    chitietthutuc.value = Request.Form["thutuc" + i];
                    chitietthutuc.thutuc = thutuc.id;
                    db.chitietthutucs.Add(chitietthutuc);
                }
               
                db.SaveChanges();
                return RedirectToAction("Index");
            }

           // ViewBag.id_user = new SelectList(db.users, "id", "username", thutuc.id_user);
            return View(thutuc);
        }

        public ActionResult CapNhatThongTin()
        {
            var thongtin = db.loaithutucs.ToList();
            List<loaithutuc> listID = new List<loaithutuc>();
            for (int i = 0; i < thongtin.Count; i++)
            {
                if (thongtin[i].loai != Constants.CAPNHATTHONGTIN)
                {
                    listID.Add(thongtin[i]);

                }
            }
            foreach (loaithutuc item in listID)
            {
                thongtin.Remove(item);
            }

            ViewBag.chitietthutuc = thongtin;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CapNhatThongTin([Bind(Include = "id, name")] thutuc thutuc, HttpPostedFileBase file)
        {
            var thongtin = db.loaithutucs.ToList();
            List<loaithutuc> listID = new List<loaithutuc>();
            for (int i = 0; i < thongtin.Count; i++)
            {
                if (thongtin[i].loai != Constants.CAPNHATTHONGTIN)
                {
                    listID.Add(thongtin[i]);

                }
            }
            foreach (loaithutuc item in listID)
            {
                thongtin.Remove(item);
            }

            if (ModelState.IsValid)
            {

                //thutuc.ngaytao = DateTime.Today;
                // thutuc.anh = "khongco";

                db.thutucs.Add(thutuc);


                db.SaveChanges();
                thutuc = db.thutucs.OrderByDescending(u => u.id).FirstOrDefault();
                var chitietthutuc = new chitietthutuc();
                for (int i = 0; i < thongtin.Count; i++)
                {
                    chitietthutuc = new chitietthutuc();
                    chitietthutuc.noidung = Request.Form["thutucname" + i];
                    chitietthutuc.value = Request.Form["thutuc" + i];
                    chitietthutuc.thutuc = thutuc.id;
                    db.chitietthutucs.Add(chitietthutuc);
                }

                db.SaveChanges();
               
            }
            return View(thutuc);
        }

        public ActionResult CapInTheSinhVien()
        {
            var thongtin = db.loaithutucs.ToList();
            List<loaithutuc> listID = new List<loaithutuc>();
            for (int i = 0; i < thongtin.Count; i++)
            {
                if (thongtin[i].loai != Constants.CAPINTHESINHVIEN)
                {
                    listID.Add(thongtin[i]);
                    
                }
            }
            foreach(loaithutuc item in listID)
            {
                thongtin.Remove(item);
            }

            ViewBag.chitietthutuc = thongtin;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CapInTheSinhVien([Bind(Include = "id, name")] thutuc thutuc, HttpPostedFileBase file)
        {
            var thongtin = db.loaithutucs.ToList();
            List<loaithutuc> listID = new List<loaithutuc>();
            for (int i = 0; i < thongtin.Count; i++)
            {
                if (thongtin[i].loai != Constants.CAPINTHESINHVIEN)
                {
                    listID.Add(thongtin[i]);

                }
            }
            foreach (loaithutuc item in listID)
            {
                thongtin.Remove(item);
            }
            if (ModelState.IsValid)
            {

                //thutuc.ngaytao = DateTime.Today;
                // thutuc.anh = "khongco";

                db.thutucs.Add(thutuc);


                db.SaveChanges();
                thutuc = db.thutucs.OrderByDescending(u => u.id).FirstOrDefault();
                var chitietthutuc = new chitietthutuc();
                for (int i = 0; i < thongtin.Count; i++)
                {
                    chitietthutuc = new chitietthutuc();
                    chitietthutuc.noidung = Request.Form["thutucname" + i];
                    chitietthutuc.value = Request.Form["thutuc" + i];
                    chitietthutuc.thutuc = thutuc.id;
                    db.chitietthutucs.Add(chitietthutuc);
                }

                db.SaveChanges();
                
            }
            return View(thutuc);
        }

        public ActionResult XinThoiHoc()
        {
            var thongtin = db.loaithutucs.ToList();
            List<loaithutuc> listID = new List<loaithutuc>();
            for (int i = 0; i < thongtin.Count; i++)
            {
                if (thongtin[i].loai != Constants.XINTHOIHOC)
                {
                    listID.Add(thongtin[i]);

                }
            }
            foreach (loaithutuc item in listID)
            {
                thongtin.Remove(item);
            }
            ViewBag.chitietthutuc = thongtin;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult XinThoiHoc([Bind(Include = "id, name")] thutuc thutuc, HttpPostedFileBase file)
        {
            var thongtin = db.loaithutucs.ToList();
            List<loaithutuc> listID = new List<loaithutuc>();
            for (int i = 0; i < thongtin.Count; i++)
            {
                if (thongtin[i].loai != Constants.XINTHOIHOC)
                {
                    listID.Add(thongtin[i]);

                }
            }
            foreach (loaithutuc item in listID)
            {
                thongtin.Remove(item);
            }
            if (ModelState.IsValid)
            {

                //thutuc.ngaytao = DateTime.Today;
                // thutuc.anh = "khongco";

                db.thutucs.Add(thutuc);


                db.SaveChanges();
                thutuc = db.thutucs.OrderByDescending(u => u.id).FirstOrDefault();
                var chitietthutuc = new chitietthutuc();
                for (int i = 0; i < thongtin.Count; i++)
                {
                    chitietthutuc = new chitietthutuc();
                    chitietthutuc.noidung = Request.Form["thutucname" + i];
                    chitietthutuc.value = Request.Form["thutuc" + i];
                    chitietthutuc.thutuc = thutuc.id;
                    db.chitietthutucs.Add(chitietthutuc);
                }

                db.SaveChanges();

            }
            return View(thutuc);
        }

        public ActionResult TiepTucHoc()
        {
            var thongtin = db.loaithutucs.ToList();
            List<loaithutuc> listID = new List<loaithutuc>();
            for (int i = 0; i < thongtin.Count; i++)
            {
                if (thongtin[i].loai != Constants.TIEPTUCHOC)
                {
                    listID.Add(thongtin[i]);

                }
            }
            foreach (loaithutuc item in listID)
            {
                thongtin.Remove(item);
            }
            ViewBag.chitietthutuc = thongtin;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TiepTucHoc([Bind(Include = "id, name")] thutuc thutuc, HttpPostedFileBase file)
        {
            var thongtin = db.loaithutucs.ToList();
            List<loaithutuc> listID = new List<loaithutuc>();
            for (int i = 0; i < thongtin.Count; i++)
            {
                if (thongtin[i].loai != Constants.TIEPTUCHOC)
                {
                    listID.Add(thongtin[i]);

                }
            }
            foreach (loaithutuc item in listID)
            {
                thongtin.Remove(item);
            }
            if (ModelState.IsValid)
            {

                //thutuc.ngaytao = DateTime.Today;
                // thutuc.anh = "khongco";

                db.thutucs.Add(thutuc);


                db.SaveChanges();
                thutuc = db.thutucs.OrderByDescending(u => u.id).FirstOrDefault();
                var chitietthutuc = new chitietthutuc();
                for (int i = 0; i < thongtin.Count; i++)
                {
                    chitietthutuc = new chitietthutuc();
                    chitietthutuc.noidung = Request.Form["thutucname" + i];
                    chitietthutuc.value = Request.Form["thutuc" + i];
                    chitietthutuc.thutuc = thutuc.id;
                    db.chitietthutucs.Add(chitietthutuc);
                }

                db.SaveChanges();

            }
            return View(thutuc);
        }


    }
}
