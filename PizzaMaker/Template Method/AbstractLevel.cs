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
        public string levelNumber { get; set; }
        public string levelImage { get; set; }
        public string[] ingredientsList = new string[5];
        //public string firstIngredient { get; set; }
        //public string secondIngredient { get; set; }
        //public string thirdIngredient { get; set; }

        protected abstract void setGameTime();
        protected abstract void setTipTime();
        protected abstract void setLevelNumber(int number);
        protected abstract void setIngredientsList();
        //protected abstract void setLevelImage();
        //protected abstract void setFirstIngredient();
        //protected abstract void setSecondIngredient();
        //protected abstract void setThirdIngredient();

        public void setGame(int number)
        {
            setGameTime();
            setTipTime();
            setLevelNumber(number);
            setIngredientsList();
            //setLevelImage();
            //setFirstIngredient();
            //setSecondIngredient();
            //setThirdIngredient();
        }
    }
}
