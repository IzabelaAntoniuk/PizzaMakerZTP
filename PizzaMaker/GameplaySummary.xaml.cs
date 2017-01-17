using PizzaMaker.Decorator;
using PizzaMaker.Factory_Method;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        private Visibility[] choosenIngredients = new Visibility[6];
        private int levelNumber = 0;
        ContentControl newContent = new ContentControl();

        public GameplaySummary(bool[] yourIngredients, int levelNumber, ContentControl newContent, int decision)
        {
            InitializeComponent();

            for (int i = 0; i < choosenIngredients.Count(); i++)
                choosenIngredients[i] = Visibility.Hidden;

            this.levelNumber = levelNumber;
            this.newContent = newContent;

            IPizza yourPizza = new Pizza(choosenIngredients);

            if (yourIngredients[0] == true)
            {
                yourPizza = new Ham(yourPizza);
                yourPizza.addIngredient();
            }

            if (yourIngredients[1] == true)
            {
                yourPizza = new Cheese(yourPizza);
                yourPizza.addIngredient();
            }
            if (yourIngredients[2] == true)
            {
                yourPizza = new Tomato(yourPizza);
                yourPizza.addIngredient();
            }

            if (yourIngredients[3] == true)
            {
                yourPizza = new Mushroom(yourPizza);
                yourPizza.addIngredient();
            }
            if (yourIngredients[4] == true)
            {
                yourPizza = new Lettuce(yourPizza);
                yourPizza.addIngredient();
            }

            if (yourIngredients[5] == true)
            {
                yourPizza = new Olive(yourPizza);
                yourPizza.addIngredient();
            }

            choosenIngredients = yourPizza.getIngredients();

            yourHam.Visibility = choosenIngredients[0];
            yourCheese.Visibility = choosenIngredients[1];
            yourTomato.Visibility = choosenIngredients[2];
            yourMushroom.Visibility = choosenIngredients[3];
            yourLettuce.Visibility = choosenIngredients[4];
            yourOlive.Visibility = choosenIngredients[5];

            Visibility[] drinkIngredList = new Visibility[6];
            Random rand = new Random();
            int drinkChoose = rand.Next(0, 3);

            DrinksProducent producent = new DrinksProducent();
            drinkIngredList = producent.drinkProduction(drinkChoose).drinkIngredList;
            
            coffe.Visibility = drinkIngredList[3];
            water.Visibility = drinkIngredList[4];
            tea.Visibility = drinkIngredList[2];
            lemon.Visibility = drinkIngredList[0];
            milk.Visibility = drinkIngredList[5];
            sugar.Visibility = drinkIngredList[1];
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            levelNumber++;
            this.Close();

            if (levelNumber > 3)
                newContent.Content = new EndGame(newContent);
            else newContent.Content = new Gameplay(1, levelNumber, newContent);
        }

    }
}
