using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Elearn.Models;
using Elearn.Users;
using Elearn.useringroup;

namespace Elearn.Controllers
{
    public class PutUserInGroupController : Controller
    {
        ElearnEntities1 db = new ElearnEntities1();
        valdation valdation =new valdation();
        public ActionResult listUser(int? id)
        {
            string token = Convert.ToString(Session["Token"]);
            int iduser = Convert.ToInt32(Session["id"]);
            if (valdation.valdaemp(Convert.ToString(Session["Role"]), Convert.ToString(Session["UserName"]),iduser,token) == false)
            {
                return RedirectToAction("Index", "Home");
            }
            int i = Convert.ToInt16(id);
            us_in_gr us_In_Gr = new us_in_gr();
            return View(us_In_Gr.us_out_group(i));
        }
        public ActionResult useringroup(int? id)
        {
            string token = Convert.ToString(Session["Token"]);
            int iduser = Convert.ToInt32(Session["id"]);
            if (valdation.valdaemp(Convert.ToString(Session["Role"]), Convert.ToString(Session["UserName"]),iduser,token) == false)
            {
                return RedirectToAction("Index", "Home");
            }
            int i = Convert.ToInt16(id);
            List<Ueaser> ueaser = new List<Ueaser>();
            List<UserInGroup> UserInGroups = db.UserInGroups.Where(m => m.idgroup == i).ToList();
            return View(UserInGroups);
        }
    }

   
}