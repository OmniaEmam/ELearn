using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Elearn.Models;
using Elearn.Users;

namespace Elearn.Controllers
{
    public class commentapiController : ApiController
    {
        ElearnEntities1 db = new ElearnEntities1();
        valdation valdation = new valdation();
        public List<c> Get(int id)
        {
            comms comms = new comms(id);
            return comms.cmmnts;
        }

        // POST: api/commentapi
        public string Post()
        {
            int idstu= Convert.ToInt16(HttpContext.Current.Request.Form["idstu"]);
            if (valdation.valda(idstu) == false)
            {
                return "goback";
            }

            int idpost = Convert.ToInt16(HttpContext.Current.Request.Form["idpost"]);
            string comment = HttpContext.Current.Request.Form["comment"];
            comment c = new comment();
            c.comment1 = comment;
            c.idpost = idpost;
            c.idstu = idstu;
            db.comments.Add(c);
            db.SaveChanges();
            return "good jop";
        }

        // PUT: api/commentapi/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/commentapi/5
        public void Delete(int id)
        {
        }
    }
    public class c
    {
        private ElearnEntities1 db = new ElearnEntities1();
        public string comment;
        public int idstu;
        comment comm;
        public c(int idcoment)
        {
            comm = db.comments.Find(idcoment);
            idstu = Convert.ToInt16(comm.idstu);
            comment = comm.comment1;
        }
    }

    public class comms{
        private ElearnEntities1 db = new ElearnEntities1();
        private List<comment> comments;
        public List<c> cmmnts = new List<c>();
        c c;
        public comms(int idpost)
        {
            comments =db.comments.Where(m => m.idpost == idpost).ToList();
            foreach (comment item in comments){
                c= new c(item.id);
                cmmnts.Add(c);
            }
        }
    }

}
