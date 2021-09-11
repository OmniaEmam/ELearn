using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Elearn.Models;

namespace Elearn.Controllers
{
    public class StuInGroupController : ApiController
    {
        ElearnEntities1 db = new ElearnEntities1();
        public string Get(){
            return "goood";
            }
        
        // POST: api/StuInGroup
        public string Post(int id)
        {
            UserInGroup userInGroup = new UserInGroup();
            int idstu =Convert.ToInt32(HttpContext.Current.Request.Form["idstu"]);

            var x = db.UserInGroups.Where(m => m.idgroup == id && m.iduser == idstu).FirstOrDefault();
            if (x != null)
            {
                return "he\\she is in";
            }

            userInGroup.idgroup = id;
            userInGroup.iduser =idstu;
            db.UserInGroups.Add(userInGroup);
            db.SaveChanges();
            return "good jop";
        }

        // DELETE: api/StuInGroup/5
        public string Delete(int id)
        {
            int idstu =Convert.ToInt32(HttpContext.Current.Request.Form["idstu"]);
            UserInGroup userInGroup = new UserInGroup();
            userInGroup = db.UserInGroups.Where(m => m.iduser == idstu && m.idgroup == id).FirstOrDefault();
            db.UserInGroups.Remove(userInGroup);
            db.SaveChanges();
            return "good jop";
        }
    }
}
