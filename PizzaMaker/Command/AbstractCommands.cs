using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaker.Command
{
    public abstract class AbstractCommands
    {
        protected IngredientList mainIngredientList;

        public AbstractCommands(IngredientList mainIngredientList) { this.mainIngredientList = mainIngredientList; }

        public abstract void undoMove();
        public abstract void redoMove();
    }
}
