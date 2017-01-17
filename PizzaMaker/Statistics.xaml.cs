using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace PizzaMaker
{
    /// <summary>
    /// Interaction logic for Statistics.xaml
    /// </summary>
    public partial class Statistics : Window
    {
        private static Statistics ins;

        //liczniki
        private int level1;
        private int level2;
        private int level3;
        //etykietki
        private Label level1Label = new Label();
        private Label level2Label = new Label();
        private Label level3Label = new Label();
        //linie
        private Polyline level1Line = new Polyline();
        private Polyline level2Line = new Polyline();
        private Polyline level3Line = new Polyline();
        //prostokaty
        private Rectangle level1Square = new Rectangle();
        private Rectangle level2Square = new Rectangle();
        private Rectangle level3Square = new Rectangle();
        
        private static readonly object mutex = new object();

        public Statistics()
        {
            InitializeComponent();

            level1Square.Fill = Brushes.Red;
            level1Square.Width = 30.0;
            Canvas.SetBottom(level1Square, 0.0);
            Canvas.SetLeft(level1Square, 40.0);

            level1Label.Content = level1.ToString();
            Canvas.SetLeft(level1Label, 41.0);

            level2Square.Fill = Brushes.Green;
            level2Square.Width = 30.0;
            Canvas.SetBottom(level2Square, 0.0);
            Canvas.SetLeft(level2Square, 80.0);

            level2Label.Content = level2.ToString();
            Canvas.SetLeft(level2Label, 81.0);

            level3Square.Fill = Brushes.Blue;
            level3Square.Width = 30.0;
            Canvas.SetBottom(level3Square, 0.0);
            Canvas.SetLeft(level3Square, 120.0);

            level3Label.Content = level3.ToString();
            Canvas.SetLeft(level3Label, 121.0);
        }

    
        public static Statistics Instance
        {
            get
            {
                if (ins == null)
                    ins = new Statistics();
                return ins;
            }
        }

        public void DrawGraph(int[] pointList)
        {

            level3 = level1 = level2 = 0;

            
                    level1 = pointList[0];
                    level2 = pointList[1];
                    level3 = pointList[2];

            wykres.Children.Clear();

            level1Square.Height = (double)level1 * 10.0;
            wykres.Children.Add(level1Square);

            level1Label.Content = level1.ToString();
            Canvas.SetBottom(level1Label, level1Square.Height + 10.0);
            wykres.Children.Add(level1Label);

            level2Square.Height = (double)level2 * 10.0;
            wykres.Children.Add(level2Square);

            level2Label.Content = level2.ToString();
            Canvas.SetBottom(level2Label, level2Square.Height + 10.0);
            wykres.Children.Add(level2Label);

            level3Square.Height = (double)level3 * 10.0;
            wykres.Children.Add(level3Square);

            level3Label.Content = level3.ToString();
            Canvas.SetBottom(level3Label, level3Square.Height + 10.0);
            wykres.Children.Add(level3Label);
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }
    }
}
