using Microsoft.VisualBasic.FileIO;
using RehaPatient.App.Abstract;
using RehaPatient.App.Common;
using RehaPatient.App.Concrete;
using RehaPatient.Domain.Entity;
using RehaPatient.Doman.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
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




        public int AddNewPatient()
        {         
            var addNewPatientMenu = _actionService.GetMenuActionsByMenuName("KindOfReferral");
            Console.WriteLine("\nPlease, pick a kind of rehabilitation:");
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
            Console.WriteLine("Please, enter a Patient's ICD10 number");
            var icd = Console.ReadLine();

            Patient patient = new Patient(refferalType, name, surname, pesel, icd);
            _patientService.AddPatient(patient);
            return patient.Id; //zwracamy id dla kontroli
        }

        public int RemovePatient()
        {
            Console.WriteLine("Please, enter a patient's PESEL number who you want to remove from list");
            string pesel = Console.ReadLine();
            
            var patient = _patientService.GetPatientByPesel(pesel);
            
            _patientService.RemovePatient(patient);

            return patient.Id;
           
        }

        public void PatientsList()
        {
            var showList = _patientService.GetAllPatients();
            foreach ( var patient in _patientService.Patients)
            {
                Console.WriteLine(patient.Name + patient.Surname + patient.Pesel + patient.Icd);
            }

           
        }
    }
}
