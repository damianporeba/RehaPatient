﻿using System.ComponentModel.Design;
using RehaPatient;
using RehaPatient.App.Concrete;
using RehaPatient.App.Manage;

namespace RehaPatient
{
    public class Program
    {

        static void Main(string[] args)
        {
            
            MenuActionService actionService = new MenuActionService();
            PatientService patientService = new PatientService();
            PatientManager patientManager = new PatientManager(actionService);
           
            Console.WriteLine("Welcome to the RehaPatient app!");
           
            while (true)
            {
                Console.WriteLine("\n\rLet me know what you want to do ...\n");
                var mainMenu = actionService.GetMenuActionsByMenuName("Main");
                for (int i = 0; i < mainMenu.Count; i++)
                {
                    Console.WriteLine(mainMenu[i].Id + "." + mainMenu[i].Name + ".\n");
                }

                var operation = Console.ReadKey(); 

                switch (operation.KeyChar)  
                {
                    case '1':
                        var newId = patientManager.AddNewPatient();

                        break;

                    case '2':
                        patientManager.RemovePatient();
                        break;

                    case '3':
                        patientManager.PatientsList();
                        break;

                    default:
                        Console.WriteLine("You picked a wrong action, please choose a correct one");
                        break;
                }
            }
           

            

           
        }
            
    }
}
