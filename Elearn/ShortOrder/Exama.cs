using Elearn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Elearn.ShortOrder
{
    public class Examago
    {
        ElearnEntities1 db = new ElearnEntities1();
        public List<qu> GetQus(int id)
        {
            return db.qus.Where(m => m.idexame == id).ToList();
        }

        public int putmark(int mark ,int idstu, int idexam){

            markexame mrk = new markexame();
            mrk.idstu = idstu;
            mrk.idexame = idexam;
            mrk.fullmark = GetQus(idexam).Count;
            mrk.mark =mark;
            try
            {
                db.markexames.Add(mrk);
                db.SaveChanges();
            }
            catch
            {
                return -1;
            }
            return 1;
        }
        
        public int is_mark_in_table(int idstu,int idexame)
        {
            markexame mark =db.markexames.Where(m => m.idstu == idstu && m.idexame == idexame).FirstOrDefault();
            if(mark == null){
                return 0;
            }
            return 1;
        }
    }
}