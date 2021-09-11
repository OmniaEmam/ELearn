using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Elearn.Models;

namespace Elearn.Users
{
    public class Sinup
    {
        ElearnEntities1 db = new ElearnEntities1();
        public Ueaser Ueaser = new Ueaser();
        public bool vrpass(string pass, string repass)
        {
            if (pass == repass)
            {
                return true;
            }
            return false;
        }

        public bool emptyfield(string x)
        {
            if (x == null) { return false; }
            else if (x == "") { return false; }
            else { return true; }
        }

        public bool usernamevaled(string username)
        {
            Ueaser x = new Ueaser();
            x = db.Ueasers.Where(m => m.UserName == username).FirstOrDefault();
            if (x != null)
            {
                return true;
            }
            return false;
        }

        //in futur implement var phone number
    }

    public class valdation
    {
        ElearnEntities1 db = new ElearnEntities1();

        public bool valda(string Role, string UserName,int id,string token)
        {
            if (Role == "Normal" || Role == "" || UserName == "Normal" || UserName == "")
            {
                return false;
            }
            Login login = db.Logins.Where(m => m.id == id).FirstOrDefault();
            List<Login> logins = db.Logins.Where(m => m.iduser == id).ToList();

            if (logins.Count != 1)
            {
                db.Logins.RemoveRange(logins);
                db.SaveChanges();
               return false;
            }
            return true;
        }

        public bool valdastu(string Role,string UserName, int id, string token)
        {
            if (Role == "Normal" || Role == "" || UserName == "Normal" || UserName == "")
            {
                return false;        
            }else if (Role != "Student")
            {
                return false;
            }
            Login login = db.Logins.Where(m => m.id == id && m.token == token).FirstOrDefault();
            if (login == null)
            {
                return false;
            }
            return true;
        }

        public bool valdaemp(string Role, string UserName, int id, string token)
        {
            if (Role == "Normal" || Role == "" || UserName == "Normal" || UserName == "")
            {
                return false;
            }
            else if (Role != "Employee")
            {
                return false;
            }
            Login login = db.Logins.Where(m => m.id == id).FirstOrDefault();
            List<Login> logins = db.Logins.Where(m => m.iduser == id).ToList();

            if (logins.Count != 1)
            {
                db.Logins.RemoveRange(logins);
                db.SaveChanges();
                return false;
            }
            return true; 
        }

        public bool valda(int id)
        {
            List<Login> logins = db.Logins.Where(m => m.iduser == id).ToList();
            if (logins.Count != 1)
            {
                db.Logins.RemoveRange(logins);
                db.SaveChanges();
                return false;
            }
            return true;
        }

        public bool isinexame(int id,int idexam){

            UserInGroup usInGroup = new UserInGroup(); ;
            try
            {
                exame exame = db.exames.Find(idexam);
                Group group = db.Groups.Find(exame.idgroup);
                usInGroup = db.UserInGroups.Where(m => m.idgroup == group.id && m.iduser == id).FirstOrDefault();
            }
            catch
            {
                return false;
            }
            if (usInGroup == null)
            {
                return false;
            }
            return true;
        }

        public bool ingroup(int id, int idgroup)
        {
            UserInGroup userInGroup = new UserInGroup(); ;
            try
            {
                 userInGroup = db.UserInGroups.Where(m => m.iduser == id && m.idgroup == idgroup).FirstOrDefault();  
            }
            catch
            {
                return false;
            }
            if (userInGroup ==null)
            {
                return false;
            }
            return true;
        }

        private static Random random = new Random();
        public static string RandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars,10).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}