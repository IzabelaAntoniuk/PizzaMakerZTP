using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaker.Template_Method
{
    public abstract class AbstractLevel
    {
        public int gameTime { get; set; }

        public int tipTime { get; set; }

        protected abstract void setGameTime();

        protected abstract void setTipTime();

        public void setGame()
        {
            setGameTime();
            setTipTime();
        }
    }
}
