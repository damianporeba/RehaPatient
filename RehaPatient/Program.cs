namespace RehaPatient
{
    public class Program
    {

        static void Main(string[] args)
        {
            MenuActionService actionService = new MenuActionService();
            actionService = Initialize(actionService);
            PatientService patientService = new PatientService();

            Console.WriteLine("Welcome to the RehaPatient app!");
            Console.WriteLine("Let me know what you want to do ...");
            var mainMenu = actionService.GetMenuActionsByMenuName("Main");
            for (int i = 0; i < mainMenu.Count; i++)
            {
                Console.WriteLine(mainMenu[i].Id + "." + mainMenu[i].Name +".");
            }

            var operation = Console.ReadKey();

            switch (operation.KeyChar)
            {
                case '1':
                    var keyInfo = patientService.AddNewPatientView(actionService);
                    var patientId = patientService.AddNewPatient (keyInfo.KeyChar);

                    break;

                case '2':
                    break;

                case '3':
                    break;

                default:
                    Console.WriteLine("You picked a wrong action, please choose a correct one");
                    break;
            }
             

        }

        private static MenuActionService Initialize(MenuActionService actionService) //metoda musi zwrócic MenuActionService zebyśmy mogli nadpisac obiekt actionService 
        {
            actionService.AddNewAction(1, "Add new patient", "Main");
            actionService.AddNewAction(2, "Remove patient from list", "Main");
            actionService.AddNewAction(3, "List of currents patients", "Main");

            actionService.AddNewAction(1, "Stationary rehabilitation", "AddNewPatientMenu");
            actionService.AddNewAction(2, "Home rehabilitation", "AddNewPatientMenu");
            

            return actionService; 
        }
    }
}
