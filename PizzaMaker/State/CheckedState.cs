using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaker.State
{
    class CheckedState : IState
    {
        private static CheckedState instance;

        private CheckedState()
        {

        }

        public bool checkUser(string nick, string pass, Authorization auth)
        {
            if (nick == "user" && pass == "pass")
                auth.changeState(LoggedState.getInstance());
            else
                auth.changeState(NotLoggedState.getInstance());

            return auth.checkUser(nick, pass);
        }

        public static CheckedState getInstance()
        {
            if (instance == null)
                instance = new CheckedState();
            return instance;
        }
        
    }
}
