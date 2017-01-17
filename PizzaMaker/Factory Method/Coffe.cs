using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PizzaMaker.Factory_Method
{
    class Coffe : AbstractDrink
    {
        public Coffe()
        {
            drinkName = "Coffe";
            for (int i = 0; i < drinkIngredList.Count(); i++)
                drinkIngredList[i] = Visibility.Hidden;
        }

        public void addSugar()
        {
            drinkIngredList[5] = Visibility.Visible;
        }

        public void addMilk()
        {
            drinkIngredList[1] = Visibility.Visible;
        }

        public void addCoffe()
        {
            drinkIngredList[3] = Visibility.Visible;
        }

        public override AbstractDrink getDrink()
        {
            addSugar();
            addMilk();
            addCoffe();
            return this;
        }
    }
}
