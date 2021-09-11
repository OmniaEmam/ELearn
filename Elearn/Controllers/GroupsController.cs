using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Elearn.Models;
using Elearn.Users;

namespace Elearn.Controllers
{
    public class GroupsController : Controller
    {
        private ElearnEntities1 db = new ElearnEntities1();
        valdation valdation = new valdation();
        // GET: Groups
        public ActionResult Index()
        {
            string token = Convert.ToString(Session["Token"]);
            int iduser = Convert.ToInt32(Session["id"]);
            if (valdation.valdaemp(Convert.ToString(Session["Role"]), Convert.ToString(Session["UserName"]), iduser, token) == false)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(db.Groups.ToList());
        }

        // GET: Groups/Details/5
        public ActionResult Details(int? id)
        {
            string token = Convert.ToString(Session["Token"]);
            int iduser = Convert.ToInt32(Session["id"]);
            if (valdation.valdaemp(Convert.ToString(Session["Role"]), Convert.ToString(Session["UserName"]),iduser,token) == false)
            {
                return RedirectToAction("Index", "Home");
            }
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Group group = db.Groups.Find(id);
            if (group == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(group);
        }

        // GET: Groups/Create
        public ActionResult Create()
        {
            string token = Convert.ToString(Session["Token"]);
            int iduser = Convert.ToInt32(Session["id"]);
            if (valdation.valdaemp(Convert.ToString(Session["Role"]), Convert.ToString(Session["UserName"]),iduser,token) == false)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // POST: Groups/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase file, Group group)
        {
            string token = Convert.ToString(Session["Token"]);
            int iduser = Convert.ToInt32(Session["id"]);
            if (valdation.valdaemp(Convert.ToString(Session["Role"]), Convert.ToString(Session["UserName"]),iduser,token) == false)
            {
                return RedirectToAction("Index", "Home");
            }
            try
            {
                if (file != null){
                    if (file.ContentLength > 0)
                    {
                        string _FileName = Path.GetFileName(file.FileName);
                        string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                        file.SaveAs(_path);

                        if (ModelState.IsValid)
                        {
                            group.photo = "/UploadedFiles/" + _FileName;
                            group.idemp = Convert.ToInt32(Session["id"]);


                            db.Groups.Add(group);
                            db.SaveChanges();
                            return RedirectToAction("Index");
                        }
                    } 
                }

            }catch
            {
                ViewBag.Message = "File upload failed!!";
                return View(group);
            }

            return View(group);
        }

        // GET: Groups/Edit/5
        public ActionResult Edit(int? id)
        {
            string token = Convert.ToString(Session["Token"]);
            int iduser = Convert.ToInt32(Session["id"]);
            if (valdation.valdaemp(Convert.ToString(Session["Role"]), Convert.ToString(Session["UserName"]),iduser,token) == false)
            {
                return RedirectToAction("Index", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.Groups.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HttpPostedFileBase file, [Bind(Include = "id,name,dis,idteacher")] Group group)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                    file.SaveAs(_path);

                    if (ModelState.IsValid)
                    {
                        group.photo = "/UploadedFiles/" + _FileName;
                        group.idemp = Convert.ToInt32(Session["id"]);

                        db.Entry(group).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
            }
            catch
            {

            }
            return View(group);
        }

        // GET: Groups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.Groups.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // POST: Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Group group = db.Groups.Find(id);
            db.Groups.Remove(group);
            db.SaveChanges();
            List<UserInGroup> userInGroups = db.UserInGroups.Where(m => m.idgroup == id).ToList();
            foreach (UserInGroup user in userInGroups)
            {
                db.UserInGroups.Remove(user);
                db.SaveChanges();
            }
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
