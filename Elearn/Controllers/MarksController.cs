using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Elearn.Marks;
using Elearn.Users;

namespace Elearn.Controllers
{
    public class MarksController : Controller
    {
        valdation valdation = new valdation();
        // GET: Marks
        public ActionResult Index(int? id)
        {
            string token = Convert.ToString(Session["Token"]);
            int iduser = Convert.ToInt32(Session["id"]);
            if (valdation.valdaemp(Convert.ToString(Session["Role"]), Convert.ToString(Session["UserName"]),iduser,token) == false)
            {
                return RedirectToAction("Index", "Home");
            }
            Markinexam markinexam = new Markinexam(Convert.ToInt16(id));
            ViewBag.markinexam = markinexam.marks;
            ViewBag.NotSolve = markinexam.NotSolve(Convert.ToInt16(id));
            return View();
        }
    }
}