using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PizzaMaker.Decorator
{
    abstract class PizzaDecorator : IPizza
    {
        protected IPizza pizza;

        public PizzaDecorator() { }

        public PizzaDecorator(IPizza pizza)
        {
            this.pizza = pizza;
        }

        public abstract void addIngredient();

        public abstract Visibility[] getIngredients();

        public abstract void addAdditions(int lol);

    }
}
