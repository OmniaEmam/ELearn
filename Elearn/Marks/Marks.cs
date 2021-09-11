using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Elearn.Models;

namespace Elearn.Marks
{
    public class Marks
    {
        ElearnEntities1 db =new ElearnEntities1();
        public markexame m = new markexame();
        public Ueaser u = new Ueaser();
        public Marks(int idexam,int idstu)
        {
            m = db.markexames.Where(m => m.idexame == idexam && m.idstu == idstu).FirstOrDefault();
            u = db.Ueasers.Find(idstu);
        }
        
    }
    public class Markinexam
    {
        ElearnEntities1 db = new ElearnEntities1();
        public List<Marks> marks = new List<Marks>();
        public List<Ueaser> ueasers = new List<Ueaser>();
        Marks M;

        public Markinexam(int idexam){
            List<markexame> markexames = db.markexames.Where(m => m.idexame == idexam).ToList();
            foreach (markexame item in markexames)
            {
                M = new Marks(Convert.ToInt16(item.idexame),Convert.ToInt16(item.idstu));
                marks.Add(M);
            }
        }
        public List<Ueaser> NotSolve(int idexam)
        {
            exame exame = db.exames.Find(idexam);
            List<UserInGroup> userInGroup = db.UserInGroups.Where(m => m.idgroup == exame.idgroup).ToList();
            markexame markexame;
            foreach (UserInGroup item in userInGroup){
                markexame = new markexame();
                markexame = db.markexames.Where(m => m.idstu == item.iduser).FirstOrDefault();
                if (markexame==null){
                    ueasers.Add(db.Ueasers.Find(item.iduser));
                }
            }
            return ueasers;
        }
    }
}