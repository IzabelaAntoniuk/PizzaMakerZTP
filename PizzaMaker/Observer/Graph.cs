using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMaker.Observer
{
    public class Graph : IObserver
    {
        private MainWindow mainWindow;

        public Graph(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        public void updateGraph()
        {
            Statistics.Instance.DrawGraph(mainWindow.pointsCount);
        }
    }
}
