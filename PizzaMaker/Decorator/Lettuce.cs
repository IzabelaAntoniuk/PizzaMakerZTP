using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PizzaMaker.Decorator
{
    class Lettuce : PizzaDecorator
    {
        public Lettuce(IPizza pizza)
        {
            base.pizza = pizza;
        }

        public override void addAdditions(int lol)
        {
            base.pizza.addAdditions(lol);
        }

        public override void addIngredient()
        {
            base.pizza.addAdditions(4);
        }

        public override Visibility[] getIngredients()
        {
            return base.pizza.getIngredients();
        }
    }
}
