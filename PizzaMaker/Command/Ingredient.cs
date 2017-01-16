using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaker.Command
{
    public class Ingredient
    {
        public string nazwa { get; set; }

        public Ingredient(string nazwa, string opis)
        {
            this.nazwa = nazwa;
        }

        public override string ToString()
        {
            return "Składnik: " + nazwa;
        }

        public string ImagePath
        {
            get
            {
                if (nazwa == "ser")
                    return "cheese.png";
                else if (nazwa == "ham")
                    return "Images/ham.png";
                else
                    return "blank.png";
            }
        }
    }
}
