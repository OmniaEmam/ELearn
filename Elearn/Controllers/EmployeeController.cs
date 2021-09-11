using Elearn.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Elearn.Controllers
{
    public class EmployeeController : Controller
    {
        valdation valdation = new valdation();
        // GET: Employee
        public ActionResult Index()
        {
            string token = Convert.ToString(Session["Token"]);
            int id = Convert.ToInt32(Session["id"]);
            if (valdation.valdaemp(Convert.ToString(Session["Role"]), Convert.ToString(Session["UserName"]),id,token) == false)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}