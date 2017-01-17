using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaker.Template_Method
{
    public class EasyLevel : AbstractLevel
    {
        public string ImagePath(int levelNumber)
        {
            if (levelNumber == 1)
                return "Images/level1.png";
            else if (levelNumber == 2)
                return "Images/level2.png";
            else if (levelNumber == 3)
                return "Images/level3.png";
            else
                return "Images/blank.png";
        }

        //protected override void setLevelImage()
        //{
        //    if (levelNumber == 1)
        //        levelImage = "Images/level1.png";
        //    else if (levelNumber == 2)
        //        levelImage = "Images/level2.png";
        //    else if (levelNumber == 3)
        //        levelImage = "Images/level3.png";
        //    else
        //        levelImage = "Images/blank.png";
        //}

        public EasyLevel() { }

        protected override void setGameTime()
        {
            gameTime = 8;
        }

        protected override void setTipTime()
        {
            tipTime = 8;
        }

        protected override void setLevelNumber(int number)
        {
            levelNumber = number;
        }
        
        protected override void setIngredientsList()
        {
            if (levelNumber == 1)
            {
                ingredientsList[0] = "tomato";
                ingredientsList[1] = "lettuce";
                ingredientsList[2] = "ham";
            }
            else if (levelNumber == 1)
            {
                ingredientsList[0] = "olive";
                ingredientsList[1] = "cheese";
                ingredientsList[2] = "ham";
            }
            else if (levelNumber == 1)
            {
                ingredientsList[0] = "mushroom";
                ingredientsList[1] = "lettuce";
                ingredientsList[2] = "cheese";
            }
        }
    }
}
