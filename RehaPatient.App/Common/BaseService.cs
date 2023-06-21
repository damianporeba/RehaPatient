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
    public class BaseService<T> : IService<T> where T : BaseEntity

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



        public T GetPatientByPesel(string pesel)
        {
            var entity = Patients.FirstOrDefault(p => p.Pesel == pesel);

            return entity;
        }

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
            string data = dateTime.ToString("d");
            return data;
        }

        public int PatientAge(string age)
        {
            DateTime date = DateTime.Now;
            string years = date.ToString("yyyy");
            int yearsNumber = Convert.ToInt32(years);
            int ageNumber = Convert.ToInt32(age.Substring(6, 4));

            int yearsNow = yearsNumber - ageNumber;
            return yearsNow;
        }


    }
}
