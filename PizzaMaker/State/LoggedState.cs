using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaker.State
{
    class LoggedState : IState
    {
        private static LoggedState instance;

        private LoggedState()
        {

        }

        public static LoggedState getInstance()
        {
            if (instance == null)
                instance = new LoggedState();
            return instance;
        }

        public bool checkUser(string nick, string pass, Authorization auth)
        {
            return true;
        }
    }
}
