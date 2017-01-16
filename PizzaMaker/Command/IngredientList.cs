using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaker.Command
{
    public class IngredientList : ObservableCollection<Ingredient>
    {
        private AbstractCommands command;
        private LinkedList<AbstractCommands> undoList;
        private LinkedList<AbstractCommands> redoList;

        public IngredientList() : base()
        {
            undoList = new LinkedList<AbstractCommands>();
            redoList = new LinkedList<AbstractCommands>();
        }

        public void addIngredient(Ingredient ingredient)
        {
            redoList.Clear();
            base.Add(ingredient);
            undoList.AddLast(new AddIngredient(this, ingredient));
        }

        public bool unlockUndo()
        {
            if (undoList == null)
                undoList = new LinkedList<AbstractCommands>();
            return undoList.Count != 0;
        }

        public bool unlockRedo()
        {
            if (redoList == null)
                redoList = new LinkedList<AbstractCommands>();
            return redoList.Count != 0;
        }

        public void undoMove()
        {
            command = undoList.Last<AbstractCommands>();
            undoList.RemoveLast();
            redoList.AddLast(command);
            command.undoMove();
        }

        public void redoMove()
        {
            command = redoList.Last<AbstractCommands>();
            redoList.RemoveLast();
            undoList.AddLast(command);
            command.redoMove();
        }


    }
}
