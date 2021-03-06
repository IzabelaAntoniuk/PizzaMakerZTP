﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PizzaMaker.Factory_Method
{
    class Tea : AbstractDrink
    {

        public Tea()
        {
            drinkName = "Tea";
            for (int i = 0; i < drinkIngredList.Count(); i++)
                drinkIngredList[i] = Visibility.Hidden;
        }

        public void addSugar()
        {
            drinkIngredList[1] = Visibility.Visible;
        }

        public void addLemon()
        {
            drinkIngredList[0] = Visibility.Visible;
        }

        public void addTea()
        {
            drinkIngredList[2] = Visibility.Visible;
        }

        public override AbstractDrink getDrink()
        {
            addSugar();
            addLemon();
            addTea();
            return this;
        }
    }
}
