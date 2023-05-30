using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatient
{
    public class Patient
    {
        public int PatientId {get; set;} //opisuje skierowanie, 1=stacjonarna, 2=domowa
        public string Name { get; set;}
        public string Surname { get; set;}
        public string Pesel { get; set;}
        public string Icd { get; set;}

    }
}
