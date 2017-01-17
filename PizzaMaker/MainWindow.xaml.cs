using PizzaMaker.Command;
using PizzaMaker.Observer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PizzaMaker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int[] pointsCount = new int[3];
        private List<IObserver> observers = new List<IObserver>();

        public MainWindow()
        {
            SignIn signIn;
            do
            {
                signIn = new SignIn();
                signIn.ShowDialog();
            } while (signIn.DialogResult == false);

            for (int i = 0; i < pointsCount.Count(); i++)
                pointsCount[i] = 0;
            AddObservator(new Graph(this));
            Powiadom();

            InitializeComponent();
        }
        
        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void startGameButton_Click(object sender, RoutedEventArgs e)
        {
            this.contentControl.Content = new StartGame(this.contentControl, pointsCount);
        }
       

        private void Statistic_Button_Click(object sender, RoutedEventArgs e)
        {
            setPointsList();
            Powiadom();
            Statistics statistic = Statistics.Instance;
            statistic.Show();
        }

        public void setPointsList()
        {
            StreamReader str = new StreamReader("plik.txt");
            for (int i = 0; i < 3; i++)
            {
                this.pointsCount[i] = int.Parse(str.ReadLine());
            }
            str.Close();
        }
        
        public void Powiadom()
        {
            foreach (IObserver observer in observers)
                observer.updateGraph();
        }

        public void AddObservator(IObserver observer)
        {
            observers.Add(observer);
        }
    }
}
