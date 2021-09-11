using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Elearn.Models;
using Elearn.Users;

namespace Elearn.Controllers
{
    public class UeasersController : Controller
    {
        private ElearnEntities1 db = new ElearnEntities1();
        valdation valdation = new valdation();
        // GET: Ueasers
        public ActionResult Index()
        {
            string token = Convert.ToString(Session["Token"]);
            int iduser = Convert.ToInt32(Session["id"]);
            if (valdation.valdaemp(Convert.ToString(Session["Role"]), Convert.ToString(Session["UserName"]), iduser, token) == false)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(db.Ueasers.ToList());
        }

        // GET: Ueasers/Details/5
        public ActionResult Details(int? id)
        {
            string token = Convert.ToString(Session["Token"]);
            int iduser = Convert.ToInt32(Session["id"]);
            if (valdation.valdaemp(Convert.ToString(Session["Role"]), Convert.ToString(Session["UserName"]), iduser, token) == false)
            {
                return RedirectToAction("Index", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ueaser ueaser = db.Ueasers.Find(id);
            if (ueaser == null)
            {
                return HttpNotFound();
            }
            return View(ueaser);
        }

        // GET: Ueasers/Create
        public ActionResult Create()
        {
            string token = Convert.ToString(Session["Token"]);
            int iduser = Convert.ToInt32(Session["id"]);
            if (valdation.valdaemp(Convert.ToString(Session["Role"]), Convert.ToString(Session["UserName"]), iduser, token) == false)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // POST: Ueasers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Fname,Lname,phone,role,UserName,Pass,actv,sex")] Ueaser ueaser)
        {
            string token = Convert.ToString(Session["Token"]);
            int iduser = Convert.ToInt32(Session["id"]);
            if (valdation.valdaemp(Convert.ToString(Session["Role"]), Convert.ToString(Session["UserName"]), iduser, token) == false)
            {
                return RedirectToAction("Index", "Home");
            }
            if (ModelState.IsValid)
            {
                db.Ueasers.Add(ueaser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ueaser);
        }

        // GET: Ueasers/Edit/5
        public ActionResult Edit(int? id)
        {
            string token = Convert.ToString(Session["Token"]);
            int iduser = Convert.ToInt32(Session["id"]);
            if (valdation.valdaemp(Convert.ToString(Session["Role"]), Convert.ToString(Session["UserName"]), iduser, token) == false)
            {
                return RedirectToAction("Index", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ueaser ueaser = db.Ueasers.Find(id);
            if (ueaser == null)
            {
                return HttpNotFound();
            }
            return View(ueaser);
        }

        // POST: Ueasers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Fname,Lname,phone,role,UserName,Pass,actv,sex")] Ueaser ueaser)
        {
            string token = Convert.ToString(Session["Token"]);
            int iduser = Convert.ToInt32(Session["id"]);
            if (valdation.valdaemp(Convert.ToString(Session["Role"]), Convert.ToString(Session["UserName"]), iduser, token) == false)
            {
                return RedirectToAction("Index", "Home");
            }
            if (ModelState.IsValid)
            {
                db.Entry(ueaser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ueaser);
        }

        // GET: Ueasers/Delete/5
        public ActionResult Delete(int? id)
        {
            string token = Convert.ToString(Session["Token"]);
            int iduser = Convert.ToInt32(Session["id"]);
            if (valdation.valdaemp(Convert.ToString(Session["Role"]), Convert.ToString(Session["UserName"]), iduser, token) == false)
            {
                return RedirectToAction("Index", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ueaser ueaser = db.Ueasers.Find(id);
            if (ueaser == null)
            {
                return HttpNotFound();
            }
            return View(ueaser);
        }

        // POST: Ueasers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            string token = Convert.ToString(Session["Token"]);
            int iduser = Convert.ToInt32(Session["id"]);
            if (valdation.valdaemp(Convert.ToString(Session["Role"]), Convert.ToString(Session["UserName"]), iduser, token) == false)
            {
                return RedirectToAction("Index", "Home");
            }
            Ueaser ueaser = db.Ueasers.Find(id);
            db.Ueasers.Remove(ueaser);
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
