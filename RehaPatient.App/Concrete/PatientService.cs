using Microsoft.VisualBasic;
using RehaPatient.App.Common;
using RehaPatient.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatient.App.Concrete
{
    public class PatientService : BaseService<Patient>
    {

        public string GetAgeByPesel(string pesel)
        {


            int year = Convert.ToInt32(pesel.Substring(0, 2));
            int month = Convert.ToInt32(pesel.Substring(2, 2));
            int day = Convert.ToInt32(pesel.Substring(4, 2));

            if (month >= 40)
            {
                year = year + 2100;
                month = month - 40;
            }
            else if (month >= 20)
            {
                year = year + 2000;
                month = month - 20;
            }
            else if (month >= 60)
            {
                year = year + 2200;
                month = month - 60;
            }

            else
            {
                year = year + 1900;
                month = month;
            }


            DateTime dateTime = new DateTime(year, month, day);
            string dateTime1 = dateTime.ToString();
            return dateTime1;

        }

    }
}
