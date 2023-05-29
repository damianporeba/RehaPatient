using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatient
{
    public class PatientService
    {
        public List<Patient> Patients { get; set; }

        public PatientService()
        {
            Patients = new List<Patient>();
        }


        public ConsoleKeyInfo AddNewPatientView(MenuActionService actionService)
        {
            Console.WriteLine("Please, pick a kind of rehabilitation:");
            var addNewPatientMenu = actionService.GetMenuActionsByMenuName("AddNewPatientMenu");
            for (int i = 0; i < addNewPatientMenu.Count; i++)
            {
                Console.WriteLine(addNewPatientMenu[i].Id + "." + addNewPatientMenu[i].Name + ".");
            }
            var operation = Console.ReadKey();

            return operation;
        }

        public int AddNewPatient(char patientType) // wybraliśmy typId skierowania pacjenta - 1 (stacjo) lub 2 (domowa)
        {
            int patientId;
            Int32.TryParse(patientType.ToString(), out patientId);
            Patient patient = new Patient();
            patient.PatientId = patientId; //patientId to rodzaj skierowania, stacjonarne lub domowe

            Console.WriteLine("Please, write a patient's PESEL:");
            string pesel = Console.ReadLine();
            Console.WriteLine("Please, enter a Patient's name:");
            string name = Console.ReadLine();
            Console.WriteLine("Please, enter a Patient's surname:");
            string surname = Console.ReadLine();
            Console.WriteLine("Please, enter a Patient's diagnosis compatible with ICD-10");
            string icd = Console.ReadLine();

            patient.Name = name;
            patient.Surname = surname;
            patient.Pesel = pesel;
            patient.Icd = icd;

            Patients.Add(patient);
            return patientId;




        }
    }
    
}
