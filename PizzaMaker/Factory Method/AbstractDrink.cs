using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PizzaMaker.Factory_Method
{
    public abstract class AbstractDrink
    {
        protected string drinkName;

        public Visibility[] drinkIngredList = new Visibility[6];

        public abstract AbstractDrink getDrink();
    }
}
