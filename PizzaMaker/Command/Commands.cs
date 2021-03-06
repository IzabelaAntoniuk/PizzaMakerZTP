﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PizzaMaker.Command
{
    public class Commands
    {
        private static RoutedUICommand redoMove;
        private static RoutedUICommand undoMove;
        private static RoutedUICommand addIngredient;

        public static RoutedUICommand RedoMove
        {
            get { return Commands.redoMove; }
        }

        public static RoutedUICommand UndoMove
        {
            get { return Commands.undoMove; }
        }

        public static RoutedUICommand AddIngredient
        {
            get { return Commands.addIngredient; }
        }

        static Commands()
        {
            redoMove = new RoutedUICommand("redo", "RedoMove", typeof(Commands));
            undoMove = new RoutedUICommand("undo", "UndoMove", typeof(Commands));
            addIngredient = new RoutedUICommand("add", "AddIngredient", typeof(Commands));
        }
    }
}
