using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Elearn.Models;

namespace Elearn.useringroup
{
    public class us_in_gr
    {
        public List<Ueaser> ueasers = new List<Ueaser>();
        ElearnEntities1 db = new ElearnEntities1();
        public List<Ueaser> us_in_group(int id)
        {
            List<UserInGroup> UserInGroups = db.UserInGroups.Where(m => m.idgroup == id).ToList();
            foreach (UserInGroup userInGroup in UserInGroups)
            {
                ueasers.Add(db.Ueasers.Find(userInGroup.iduser));
            }
            return ueasers;
        }
        public List<Ueaser> us_out_group(int id)
        {
            List<UserInGroup> UserInGroups = db.UserInGroups.Where(m => m.idgroup == id).ToList();
            ueasers = db.Ueasers.ToList();
            foreach (UserInGroup userInGroup in UserInGroups)
            {
                ueasers.Remove(db.Ueasers.Find(userInGroup.iduser));
            }
            return ueasers;
        }
    }
}