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
                if (nazwa == "cheese")
                    return "Images/cheese.png";
                else if (nazwa == "ham")
                    return "Images/ham.png";
                else if (nazwa == "tomato")
                    return "Images/tomato.png";
                else if (nazwa == "mushroom")
                    return "Images/mushroom.png";
                else if (nazwa == "lettuce")
                    return "Images/lettuce.png";
                else if (nazwa == "olive")
                    return "Images/olive.png";
                else
                    return "Images/blank.png";
            }
        }
    }
}
