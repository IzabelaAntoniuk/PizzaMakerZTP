using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PizzaMaker.Factory_Method
{
    class Water : AbstractDrink
    {
        public Water()
        {
            drinkName = "Water";
            for (int i = 0; i < drinkIngredList.Count(); i++)
                drinkIngredList[i] = Visibility.Hidden;
        }

        public void addLemon()
        {
            drinkIngredList[0] = Visibility.Visible;
        }

        public void addWater()
        {
            drinkIngredList[4] = Visibility.Visible;
        }

        public override AbstractDrink getDrink()
        {
            addLemon();
            addWater();
            return this;
        }
    }
}
