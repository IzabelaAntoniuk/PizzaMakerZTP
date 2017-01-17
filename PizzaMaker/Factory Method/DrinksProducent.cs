using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PizzaMaker.Factory_Method
{
    public class DrinksProducent
    {
        public AbstractDrink drinkProduction(int number)
        {
            AbstractDrink drink = null;

            /* teraz decyduje o tym, ktora picie wytworzy */
            if (number.Equals(0))
            {
                drink = new Tea();
            }
            else if (number.Equals(1))
            {
                drink = new Coffe();
            }
            else if (number.Equals(2))
            {
                drink = new Water();
            }
            return drink.getDrink();
        }
    }
}
