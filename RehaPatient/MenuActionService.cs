using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehaPatient
{
    public class MenuActionService
    {
        private List<MenuAction> menuActions;
        public MenuActionService() 
        { 
            menuActions = new List<MenuAction>(); //robienie metody po to zeby ta lista nie była zerem, poprostu okresla sie ze ta lista to ta lista
        }



        public void AddNewAction(int id, string name, string menuName)
        {
            MenuAction menuAction = new MenuAction() {Id = id, Name = name, MenuName = menuName}; // definicja zmiennych w obiekcie akcji
            menuActions.Add(menuAction); // dodanie akcji to listy wszystkich akcji
        }

        public List<MenuAction> GetMenuActionsByMenuName(string menuName) //zwracany element metody to gotowa lista wyboru menu który nas interesuje 
        {
            List<MenuAction> result = new List<MenuAction>(); 
            foreach (var menuAction in menuActions)    //pętla przechodzi przez listę
            {
                if (menuAction.MenuName == menuName)    //jeśli menuName jest zgodne z tym co chcemy mieć w menu, to dodajemy to do listy 'result'
                {
                    result.Add(menuAction);
                }
            }
            return result;  //finalnie zwracana jest lista result z gotowymi wynikami
        }

    }
}
