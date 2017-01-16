using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaker.Command
{
    public class AddIngredient : AbstractCommands
    {
        private Ingredient ingredient;

        public AddIngredient(IngredientList mainIngredientList, Ingredient ingredient) : base(mainIngredientList)
        {
            this.ingredient = ingredient;
        }

        public override void undoMove()
        {
            ((ObservableCollection<Ingredient>)mainIngredientList).Remove(ingredient);
        }

        public override void redoMove()
        {
            ((ObservableCollection<Ingredient>)mainIngredientList).Add(ingredient);
        }
    }
}
