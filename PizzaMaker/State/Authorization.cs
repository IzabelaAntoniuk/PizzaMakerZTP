using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaker.State
{
    class Authorization
    {
        private IState state;

        public Authorization()
        {
            state = CheckedState.getInstance();
        }

        public bool checkUser(string nick, string pass)
        {
            return state.checkUser(nick, pass, this);
        }

        public void changeState(IState stat)
        {
            this.state = stat;
        }

    }
}
