using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Elearn.Models;
using Elearn.ShortOrder;
using Elearn.Exama;
using Elearn.Users;

namespace Elearn.Controllers
{
    public class StudentController : Controller
    {
        ElearnEntities1 db = new ElearnEntities1();
        Examago examago = new Examago();
        valdation valdation = new valdation();
        // GET: Student
        
        public ActionResult myExamas(int? id)
        {
            string token = Convert.ToString(Session["Token"]);
            int iduser = Convert.ToInt32(Session["id"]);
            if (valdation.valda(Convert.ToString(Session["Role"]),Convert.ToString(Session["UserName"]),iduser,token) == false)
            {
                return RedirectToAction("Index", "Home");
            }
            int idexam = Convert.ToInt16(id);
            int idstu = Convert.ToInt16(Session["id"]);
            if (valdation.ingroup(idstu, idexam) == false)
            {
                return RedirectToAction("Index", "Home");
            }
            List<exame> exame = db.exames.Where(m =>m.idgroup ==id).ToList();
            ViewBag.exame = exame;
            return View();
        }
        
        public ActionResult Exama(int? id)
        {
            string token = Convert.ToString(Session["Token"]);
            int iduser = Convert.ToInt32(Session["id"]);
            if (valdation.valda(Convert.ToString(Session["Role"]),Convert.ToString(Session["UserName"]),iduser,token) == false)
            {
                return RedirectToAction("Index", "Home");
            }
            int idexam =Convert.ToInt16(id);
            int idstu =Convert.ToInt16(Session["id"]);
            if(valdation.isinexame(idstu,idexam) == false)
            {
                return RedirectToAction("Index","Home");
            }
            ViewBag.qus = db.qus.Where(m => m.idexame == id).ToList();

            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public ActionResult Exama(int?id,FormCollection form)
        {
            corexame corexame = new corexame();
            string token = Convert.ToString(Session["Token"]);
            int iduser = Convert.ToInt32(Session["id"]);
            if (valdation.valda(Convert.ToString(Session["Role"]),Convert.ToString(Session["UserName"]),iduser,token) == false)
            {
                return RedirectToAction("Index", "Home");
            }
            List<qu> qus = examago.GetQus(Convert.ToInt16(id));
            int x = corexame.ExamCorrection(Convert.ToInt16(id),form);
            
            //التأكد من اعدم وجود الدرجه قبل ذالك في الداتا بيز
            if (examago.is_mark_in_table(Convert.ToInt32(Session["id"]),Convert.ToInt16(id))==0){
                examago.putmark(x,Convert.ToInt32(Session["id"]),Convert.ToInt16(id));
            }

            ViewBag.qus = qus;
            ViewBag.x = x;
            ViewBag.y = examago.is_mark_in_table(Convert.ToInt32(Session["id"]),Convert.ToInt16(id));
            return View();
        }
    }
}