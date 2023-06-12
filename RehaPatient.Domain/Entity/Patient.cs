using RehaPatient.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatient.Domain.Entity
{
    public class Patient : BaseEntity
    {
        public int RefferalId {get; set;} //opisuje skierowanie, 1=stacjonarna, 2=domowa
        public string Name { get; set;}
        public string Surname { get; set;}
        public string Pesel { get; set;}
        public string Icd { get; set;}

        public Patient(int refferalId, string name, string surname, string pesel, string icd)
        {
            RefferalId = refferalId;
            Name = name;
            Surname = surname;
            Pesel = pesel;
            Icd = icd;
        }
    }
}
