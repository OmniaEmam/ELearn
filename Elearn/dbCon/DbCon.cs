using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Elearn.Models;
namespace Elearn.dbCon
{
    public class DbCon
    {
        private static ElearnEntities1 Con=new ElearnEntities1();
        private static DbCon DbCon_in;
        public static DbCon GetInstance()
        {
            if (DbCon_in == null)
            {
                DbCon_in = new DbCon();
            }
            return DbCon_in;
        }

        public ElearnEntities1 GetCon()
        {
            return Con;
        }
    } 
}