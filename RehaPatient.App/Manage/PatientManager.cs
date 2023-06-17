using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;
using RehaPatient.App.Abstract;
using RehaPatient.App.Common;
using RehaPatient.App.Concrete;
using RehaPatient.Domain.Common;
using RehaPatient.Domain.Entity;
using RehaPatient.Doman.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Loader;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatient.App.Manage
{
    public class PatientManager
    {
        private readonly MenuActionService _actionService;
        private PatientService _patientService;
        
        public PatientManager(MenuActionService actionService)
        {
            _patientService = new PatientService();
            _actionService = actionService;
        }
        public void AddNewPatient()
        {         
            var addNewPatientMenu = _actionService.GetMenuActionsByMenuName("KindOfReferral");
            Console.WriteLine("\n\rPlease, pick a kind of rehabilitation:");
            for (int i = 0; i < addNewPatientMenu.Count; i++)
            {
                Console.WriteLine("\n" + addNewPatientMenu[i].Id + "." + addNewPatientMenu[i].Name + ".");
            }
            var operation = Console.ReadKey();
           
            int refferalType;
            Int32.TryParse(operation.KeyChar.ToString(), out refferalType);

            Console.WriteLine("Please, enter a Patient's name");
            var name = Console.ReadLine();
            Console.WriteLine("Please, enter a Patient's surname");
            var surname = Console.ReadLine();
            Console.WriteLine("Please, enter a Patient's PESEL");
            var pesel = Console.ReadLine();
            
            while (pesel.Length != 11)
            {
                Console.WriteLine("Invalid PESEL, please enter a correct one:...");
                pesel = Console.ReadLine();
            }

            var age = _patientService.GetAgeByPesel(pesel);
            
            Console.WriteLine("Please, enter a Patient's ICD10 number");
            var icd = Console.ReadLine();
            Console.WriteLine("Please, enter a Patient's home adress:");
            string adress = Console.ReadLine();
            var patientYears = _patientService.PatientAge(age);

            Patient patient = new Patient(refferalType, name, surname, pesel, icd) {Adress = adress, Age = age, YearsNow = patientYears };


            _patientService.AddPatient(patient);
        }
        public void RemovePatient() //wpisujemy pesel pacjenta do skasowania z listy, on jest przekazywany do metody która go wyszukjuje z listy, potem ta zmienna przyjmuje jego wartość i wywoływana jest metoda kasująca go z listy
        {
            Console.WriteLine("\n\rPlease, enter a patient's PESEL number who you want to remove from list");
            string peselToRemove = Console.ReadLine();

            var patient = _patientService.GetPatientByPesel(peselToRemove);
            _patientService.RemovePatient(patient);
        }
        public void PatientsList()
        {
            //var showList = _patientService.GetAllPatients(); funkcja w sumie nie działa, to co na dole robi to co chce
            foreach (var patient in _patientService.Patients)
            {
                if (patient.RefferalId == 1)
                {
                    Console.WriteLine($"\n\rImię: {patient.Name} \n\rNazwisko: {patient.Surname} \n\rPESEL: {patient.Pesel} \n\rData urodzenia: {patient.Age}\n\rWiek {patient.YearsNow}lat\n\rICD10: {patient.Icd}\n\rrehabilitacja stacjonarna");
                }
                if (patient.RefferalId == 2)
                {
                    Console.WriteLine($"\n\rImię: {patient.Name} \n\rNazwisko: {patient.Surname} \n\rPESEL: {patient.Pesel} \n\rData urodzenia: {patient.Age}\n\rWiek {patient.YearsNow}lat\n\rICD10: {patient.Icd} \n\rrehabilitacja domowa \n\rAdres wizyty:" +
                        $" {patient.Adress}");
                }
            }
        }

        public void PatientsListByRehabType()
        {
            var addNewPatientMenu = _actionService.GetMenuActionsByMenuName("KindOfReferral");
            Console.WriteLine("\n\rPlease, pick a kind of rehabilitation:");
            for (int i = 0; i < addNewPatientMenu.Count; i++)
            {
                Console.WriteLine("\n" + addNewPatientMenu[i].Id + "." + addNewPatientMenu[i].Name + ".");
            }
            var operation = Console.ReadKey();

            //int refferalType;
            //Int32.TryParse(operation.KeyChar.ToString(), out refferalType);

            if (operation.KeyChar == '1')
            {
                foreach (var patient in _patientService.Patients)
                {
                    if (patient.RefferalId == 1)
                    {
                        Console.WriteLine($"\n\rImię: {patient.Name} \n\rNazwisko: {patient.Surname} \n\rPESEL: {patient.Pesel} \n\rData urodzenia: {patient.Age}\n\rWiek {patient.YearsNow}lat\n\rICD10: {patient.Icd} \n\rrehabilitacja stacjonarna");
                    }
                }
            }

            else if (operation.KeyChar == '2')
            {
                foreach (var patient in _patientService.Patients)
                {
                    if (patient.RefferalId == 2)
                    {
                        Console.WriteLine($"\n\rImię: {patient.Name} \n\rNazwisko: {patient.Surname} \n\rPESEL: {patient.Pesel} \n\rData urodzenia: {patient.Age}\n\rWiek {patient.YearsNow}lat\n\rICD10: {patient.Icd} \n\rrehabilitacja domowa \n\rAdres wizyty:" +
                                            $" {patient.Adress}");
                    }
                    
                }
            }
        }
    }
}
