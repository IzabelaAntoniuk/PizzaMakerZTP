using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PizzaMaker
{
    public interface IPizza
    {
        void addIngredient();
        Visibility[] getIngredients();
        void addAdditions(int lol);
    }
}
