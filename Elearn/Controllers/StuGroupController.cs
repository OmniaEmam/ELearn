using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Elearn.Models;
using Elearn.Users;
namespace Elearn.Controllers
{
    public class StuGroupController : Controller
    {
        ElearnEntities1 db = new ElearnEntities1();
        // GET: StuGrou
        valdation valdation = new valdation();
        public ActionResult Index()
        {
            string token = Convert.ToString(Session["Token"]);
            int iduser = Convert.ToInt32(Session["id"]);
            if (valdation.valda(Convert.ToString(Session["Role"]), Convert.ToString(Session["UserName"]),iduser,token) == false)
            {
                return RedirectToAction("Index", "Home");
            }

            List<UserInGroup> x = db.UserInGroups.Where(m => m.iduser == iduser).ToList();
            List<Group> groups = new List<Group>();
            foreach(var item in x)
            {
                groups.Add(db.Groups.Find(item.idgroup));
            }
            return View(groups);
        }
    }
}