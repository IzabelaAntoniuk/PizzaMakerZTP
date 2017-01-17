using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PizzaMaker.Decorator
{
    class Mushroom : PizzaDecorator
    {
        public Mushroom(IPizza pizza)
        {
            base.pizza = pizza;
        }

        public override void addAdditions(int lol)
        {
            base.pizza.addAdditions(lol);
        }

        public override void addIngredient()
        {
            base.pizza.addAdditions(3);
        }

        public override Visibility[] getIngredients()
        {
            return base.pizza.getIngredients();
        }
    }
}
