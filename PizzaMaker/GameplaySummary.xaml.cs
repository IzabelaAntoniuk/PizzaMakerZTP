using PizzaMaker.Decorator;
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
    /// Interaction logic for GameplaySummary.xaml
    /// </summary>
    public partial class GameplaySummary : Window
    {
        private Visibility[] tablicaa = new Visibility[6];
        private int levelNumber = 0;
        ContentControl newContent = new ContentControl();
        UserControl newUC = new UserControl();

        public GameplaySummary(bool[] tab, int levelNumber, ContentControl newContent, int decision)
        {
            InitializeComponent();
            for (int i = 0; i < tablicaa.Count(); i++)
                tablicaa[i] = Visibility.Hidden;
            //this.tablicaa = tab;
            //yourHam.Visibility = tab[0];
            //yourCheese.Visibility = tab[1];
            this.levelNumber = levelNumber;
            this.newContent = newContent;

            IPizza yourPizza = new Pizza(tablicaa);

            if (tab[0] == true)
            {
                yourPizza = new Ham(yourPizza);
                yourPizza.addIngredient();
            }

            if (tab[1] == true)
            {
                yourPizza = new Cheese(yourPizza);
                yourPizza.addIngredient();
            }

            tablicaa = yourPizza.getIngredients();

            //yourPizza = new Ham(yourPizza);
           // yourHam.Visibility = yourPizza.addIngredient();
            //tablicaa = yourPizza.getIngredients();

            yourHam.Visibility = tablicaa[0];
            yourCheese.Visibility = tablicaa[1];

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            levelNumber++;
            newContent.Content = new Gameplay(1, levelNumber, newContent);
            this.Close();
        }

    }
}
