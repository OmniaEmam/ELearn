using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Elearn.Models;
using Elearn.ShortOrder;

namespace Elearn.Exama
{
    public class corexame
    {

        Examago examago = new Examago();
        
        public int ExamCorrection(int id, FormCollection form)
        {
            List<qu> qus = examago.GetQus(Convert.ToInt16(id));
            string str;
            int Correct = 0;
            for (int i=1;i <= qus.Count;i++)
            {
                str = "An_"+Convert.ToString(i);

                    if (Convert.ToInt32(form[str]) == qus[i-1].QreAn)
                    {
                        Correct++;
                    }
            }
            return Correct;
        }

    }
}