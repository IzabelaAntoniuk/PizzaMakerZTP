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
        public int levelNumber { get; set; }
        public string levelImage { get; set; }
        public string[] ingredientsList = new string[3];

        protected abstract void setGameTime();
        protected abstract void setTipTime();
        protected abstract void setLevelNumber(int number);
        protected abstract void setIngredientsList();
       // protected abstract void setLevelImage();

        public void setGame(int number)
        {
            setGameTime();
            setTipTime();
            setLevelNumber(number);
            //setLevelImage();
            setIngredientsList();
        }
    }
}
