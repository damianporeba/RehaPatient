using RehaPatient.Doman.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RehaPatient;
using RehaPatient.App.Common;

namespace RehaPatient.App.Concrete
{
    public class MenuActionService : BaseService<MenuAction> // dziedziczy po klasie base service które przyjmuje jako parametr typ MenuAction.
    {

        public MenuActionService() 
        { 
            Initialize();  //kompilacja metody initialize zawsze na początku
        }

        public List<MenuAction> GetMenuActionsByMenuName(string menuName) //zwracany element metody to gotowa lista wyboru menu który nas interesuje 
        {
            List<MenuAction> result = new List<MenuAction>(); 
            foreach (var menuAction in Patients)    //pętla przechodzi przez listę główną programu "patients"
            {
                if (menuAction.MenuName == menuName)    //jeśli menuName jest zgodne z tym co chcemy mieć w menu, to dodajemy to do listy 'result'
                {
                    result.Add(menuAction);
                }
            }
            return result;  //finalnie zwracana jest lista result z gotowymi wynikami
        }
        
        private void Initialize() //robimy obiekty nowe klasy MenuAction która dziedziczy po klasie BaseService które jako paramatr ma klasę MenuAction
        {
            AddPatient(new MenuAction(1, "Add new patient", "Main"));
            AddPatient(new MenuAction(2, "Remove patient from list", "Main"));
            AddPatient(new MenuAction(3, "List of currents patients", "Main"));

            AddPatient(new MenuAction(1, "Stationary rehabilitation", "KindOfReferral")); 
            AddPatient(new MenuAction(2, "Home rehabilitation", "KindOfReferral"));

        }
    }
}
