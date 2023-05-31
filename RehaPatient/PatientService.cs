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
            Console.WriteLine("\nPlease, pick a kind of rehabilitation:");
            var addNewPatientMenu = actionService.GetMenuActionsByMenuName("KindOfReferral");
            for (int i = 0; i < addNewPatientMenu.Count; i++)
            {
                Console.WriteLine("\n" + addNewPatientMenu[i].Id + "." + addNewPatientMenu[i].Name + ".");
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

            Console.WriteLine("\nPlease, write a patient's PESEL:");
            string pesel = Console.ReadLine();
            while (pesel.Length != 11)
            {
                Console.WriteLine("incorrect PESEL number, please enter a correct one:");
                pesel = Console.ReadLine();
            }
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

        public string RemovePatientView()
        {
            Console.WriteLine("\n Please, enter a patient's PESEL number to remove him from list");
            var pesel = Console.ReadLine();

            return pesel;
        }

        public void PatientRemove(string patientRemove)
        {
            Patient patientToRemove = new Patient();

            foreach (var patient in Patients)
            {
                if (patient.Pesel == patientRemove)
                {
                    patientToRemove = patient;
                    break;
                }
            }
            Patients.Remove(patientToRemove);       
        }

        public ConsoleKeyInfo ListOfPatientView(MenuActionService actionService)
        {
            Console.WriteLine("\nPlease, pick a type of referral:");
            var referralType = actionService.GetMenuActionsByMenuName("KindOfReferral");
            
            for (int i = 0; i < referralType.Count; i++)
            {
                Console.WriteLine("\n" + referralType[i].Id + "." + referralType[i].Name + ".");
            }
            var operation = Console.ReadKey();

            return operation;
        }

        public int ListOfPatient(char patientList)
        {

            int patientListType;
            Int32.TryParse(patientList.ToString(), out patientListType);

            Patient patientTypeList = new Patient();

            foreach (var patient in Patients)
            {
                if (patient.PatientId == patientListType)
                {
                    patientTypeList = patient;
                    
                    Console.WriteLine($"\nPESEL: {patient.Pesel}\nImię: {patient.Name}\nNazwisko: {patient.Surname}\nICD-10: {patient.Icd}.");  
                }
            }
            return patientList;
        }
    }
    
}
