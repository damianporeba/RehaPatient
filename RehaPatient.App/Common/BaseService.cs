using RehaPatient.App.Abstract;
using RehaPatient.Domain.Common;
using RehaPatient.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatient.App.Common
{
    public class BaseService<T> : IService <T> where T : BaseEntity

    {
       public List<T> Patients { get; set; }   //inicjalizuje listę pacjentów

        public BaseService()  //konstruktor do listy
        {
            Patients = new List<T>(); 
        }

        public List<T> GetAllPatients()
        {
            return Patients;
        }

        public int AddPatient(T patient)
        {
            Patients.Add(patient);
            return patient.Id;
        }

        public int UpdatePatient(T patient)
        {
            var entity = Patients.FirstOrDefault(p => p.Id == patient.Id);
            if (entity != null)
            {
                entity = patient;
            }
            return entity.Id;
        }

        public void RemovePatient(T patient)
        {
            Patients.Remove(patient);
        }

        public T GetPatientByPesel(string peselToRemove)
        {
            var patientToRemove = Patients.FirstOrDefault(pesel => pesel.Pesel== peselToRemove);
            return patientToRemove;
        }
    }
}
