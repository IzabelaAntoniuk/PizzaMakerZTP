using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaker.Template_Method
{
    public class EasyLevel : AbstractLevel
    {
        public EasyLevel() { }

        protected override void setGameTime()
        {
            gameTime = 15;
        }

        protected override void setTipTime()
        {
            tipTime = 15;
        }

        protected override void setLevelNumber(int number)
        {
            levelNumber = "Level " + number;
        }
        
        protected override void setIngredientsList()
        {

        }
    }
}
