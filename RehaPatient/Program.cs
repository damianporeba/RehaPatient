namespace RehaPatient
{
    public class Program
    {

        static void Main(string[] args)
        {
            MenuActionService actionService = new MenuActionService();
            PatientService patientService = new PatientService();
            
            actionService = Initialize(actionService);
           
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
                        var keyInfo = patientService.AddNewPatientView(actionService);
                        var patientId = patientService.AddNewPatient(keyInfo.KeyChar);

                        break;

                    case '2':

                        var patientRemove = patientService.RemovePatientView();
                        patientService.PatientRemove(patientRemove);
                        break;

                    case '3':
                        var keyInfoPatient = patientService.ListOfPatientView(actionService);
                        var patientList = patientService.ListOfPatient(keyInfoPatient.KeyChar);
                        break;

                    default:
                        Console.WriteLine("You picked a wrong action, please choose a correct one");
                        break;
                }
            }
            static MenuActionService Initialize(MenuActionService actionService) //metoda musi zwrócic MenuActionService zebyśmy mogli nadpisac obiekt actionService 
                {
                    actionService.AddNewAction(1, "Add new patient", "Main");
                    actionService.AddNewAction(2, "Remove patient from list", "Main");
                    actionService.AddNewAction(3, "List of currents patients", "Main");

                    actionService.AddNewAction(1, "Stationary rehabilitation", "KindOfReferral"); //menu wyboru podczas dodawania pacjenta ale jak i wywoływania listy oczekujących
                    actionService.AddNewAction(2, "Home rehabilitation", "KindOfReferral");

                    return actionService;
                }

            

           
        }
            
    }
}
