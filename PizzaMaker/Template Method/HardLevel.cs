using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaker.Template_Method
{
    class HardLevel : AbstractLevel
    {
        public HardLevel()
        {

        }

        protected override void setGameTime()
        {
            gameTime = 10;
        }

        protected override void setTipTime()
        {
            tipTime = 5;
        }
    }
}
