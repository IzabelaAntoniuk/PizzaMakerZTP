using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PizzaMaker.State
{
    class NotLoggedState : IState
    {
        private static NotLoggedState instance;

        private NotLoggedState() { }
        
        public bool checkUser(string nick, string pass, Authorization auth)
        {
            MessageBox.Show("Podane dane są nieprawidłowe. Spróbuj jeszcze raz.");
            auth.changeState(CheckedState.getInstance());
            return false;
        }

        public static NotLoggedState getInstance()
        {
            if (instance == null)
                instance = new NotLoggedState();
            return instance;
        }

       
    }
}
