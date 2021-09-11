using Elearn.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Elearn.Models;

namespace Elearn.Controllers
{
    public class NotesController : Controller
    {
        valdation valdation = new valdation();
        ElearnEntities1 db = new ElearnEntities1();

        public ActionResult index(int? id)
        {
            string token = Convert.ToString(Session["Token"]);
            int iduser = Convert.ToInt32(Session["id"]);
            if (valdation.valda(Convert.ToString(Session["Role"]), Convert.ToString(Session["UserName"]),iduser,token) == false)
            {
                return RedirectToAction("Index", "Home");
            }
            no no = new no();
            ViewBag.nos = no.MyNotes(Convert.ToInt32(Session["id"]),Convert.ToInt32(id));
            return View();
        }

        public ActionResult Creatnotes(int? id, int? exame)
        {
            string token = Convert.ToString(Session["Token"]);
            int iduser = Convert.ToInt32(Session["id"]);
            if (valdation.valda(Convert.ToString(Session["Role"]), Convert.ToString(Session["UserName"]),iduser,token) == false)
            {
                return RedirectToAction("Index", "Home");
            }
            if (id == 0)
            {
                return RedirectToAction("Index", "Notes", new { id = exame });
            }

            qu qu = new qu();
            qu = db.qus.Find(Convert.ToInt32(id));
            ViewBag.qu = qu;
           
            return View();
        }

        [HttpPost]
        public ActionResult Creatnotes(int? id, int? exame, string note)
        {
            string token = Convert.ToString(Session["Token"]);
            int iduser = Convert.ToInt32(Session["id"]);
            if (valdation.valda(Convert.ToString(Session["Role"]), Convert.ToString(Session["UserName"]),iduser,token) == false)
            {
                return RedirectToAction("Index", "Home");
            }


            Note no = new Note();
            no.idstu = Convert.ToInt32(Session["id"]);
            no.idexam = Convert.ToInt32(exame);
            no.idqu = Convert.ToInt32(id);
            no.notes = note;
            db.Notes.Add(no);
            db.SaveChanges();

            qu qu = new qu();
            qu = db.qus.Find(Convert.ToInt32(id));
            ViewBag.qu = qu;

            return View();
        }
    }
    public class no
    {
        public qu qu;
        public Note Note;
        ElearnEntities1 db = new ElearnEntities1();
        public void addprametar(int id)
        {
            Note = db.Notes.Find(id);
            qu = db.qus.Find(Note.idqu);
        }
        public List<no> MyNotes(int idstu,int idexam){
            
            List<no> nos = new List<no>();
            List<Note> notes = db.Notes.Where(m => m.idstu == idstu && m.idexam ==idexam).ToList();
            no no;
            foreach (Note note in notes)
            {
                no = new no();
                no.addprametar(note.id);
                nos.Add(no);
            }
            return nos;
        }
    }
}