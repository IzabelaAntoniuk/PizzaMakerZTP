using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PizzaMaker.Decorator
{
    public class Pizza : IPizza
    {
        public Visibility[] tab = new Visibility[6];

        public Pizza(Visibility[] tab)
        {
            this.tab = tab;
            //for (int i = 0; i < tab.Count(); i++)
            //    tab[i] = Visibility.Hidden;
        }

        public void addSauce()
        {
        }

        public void addAdditions(int lol)
        {
            tab[lol] = Visibility.Visible;
        }

        public void addIngredient()
        {
            
        }

        public Visibility[] getIngredients()
        {
            return tab;
        }
    }
}
