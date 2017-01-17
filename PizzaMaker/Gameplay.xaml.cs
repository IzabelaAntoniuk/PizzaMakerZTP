using PizzaMaker.Command;
using PizzaMaker.Template_Method;
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
using System.Windows.Threading;

namespace PizzaMaker
{
    /// <summary>
    /// Interaction logic for Gameplay.xaml
    /// </summary>
    public partial class Gameplay : UserControl
    {
        DispatcherTimer levelTimer;
        DispatcherTimer tipTimer;
        TimeSpan levelSeconds;
        TimeSpan tipLevelSeconds;
        int levelNumber = 1;
        ContentControl newContent = new ContentControl();
        int decision = 0;
        bool[] yourIngredients = new bool[6];
        private IngredientList ingredList = new IngredientList();
        AbstractLevel levelType = new EasyLevel();
        int[] pointsCount = new int[3];

        public IngredientList ingredientList
        {
            get
            {
                return ingredList;
            }
            set
            {
                ingredList = value;
            }
        }

        public Gameplay(int decision, int levelNumber, ContentControl newContent, int[] pointsCount)
        {
            this.newContent = newContent;
            this.decision = decision;
            this.levelNumber = levelNumber;
            this.pointsCount = pointsCount;

            if (decision == 1)
                levelType = new EasyLevel();
            else if (decision == 2)
                levelType = new HardLevel();

            levelType.setGame(levelNumber);

            MessageBox.Show("Level " + levelType.levelNumber);

            tipLevelSeconds = TimeSpan.FromSeconds(levelType.tipTime);
            tipTimer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                if (tipLevelSeconds.Seconds == levelType.tipTime)
                {
                    if (levelType.levelNumber == 1)
                        pizzaImgTipLevel1.Visibility = Visibility.Visible;
                    if (levelType.levelNumber == 2)
                        pizzaImgTipLevel2.Visibility = Visibility.Visible;
                    if (levelType.levelNumber == 3)
                        pizzaImgTipLevel3.Visibility = Visibility.Visible;
                }
                if (tipLevelSeconds == TimeSpan.Zero)
                {
                    if (levelType.levelNumber == 1)
                        pizzaImgTipLevel1.Visibility = Visibility.Hidden;
                    if (levelType.levelNumber == 2)
                        pizzaImgTipLevel2.Visibility = Visibility.Hidden;
                    if (levelType.levelNumber == 3)
                        pizzaImgTipLevel3.Visibility = Visibility.Hidden;
                }
                tipLevelSeconds = tipLevelSeconds.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);

            tipTimer.Start();

            levelSeconds = TimeSpan.FromSeconds(levelType.gameTime);
            levelTimer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                gameTime.Text = levelSeconds.ToString("c");
                if (levelSeconds == TimeSpan.Zero)
                {
                    levelTimer.Stop();
                    if (doneButton.IsEnabled)
                    {
                        doneButton.IsEnabled = false;
                        levelSeconds = TimeSpan.Zero;
                        endLevel();
                    }
                }
                levelSeconds = levelSeconds.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);

            levelTimer.Start();

            InitializeComponent();
        }

        Ingredient ingredient = new Ingredient("", "");

        private void hamButton_Click(object sender, RoutedEventArgs e)
        {
            ingredient = new Ingredient("ham", "szynka");
            yourHam.DataContext = ingredient;
            yourHam.Visibility = Visibility.Visible;
            hamButton.IsEnabled = false;
        }

        private void cheeseButton_Click(object sender, RoutedEventArgs e)
        {
            ingredient = new Ingredient("cheese", "ser");
            yourCheese.DataContext = ingredient;
            yourCheese.Visibility = Visibility.Visible;
            cheeseButton.IsEnabled = false;
        }

        private void tomatoButton_Click(object sender, RoutedEventArgs e)
        {
            ingredient = new Ingredient("tomato", "pomidor");
            yourTomato.DataContext = ingredient;
            yourTomato.Visibility = Visibility.Visible;
            tomatoButton.IsEnabled = false;
        }

        private void mushroomButton_Click(object sender, RoutedEventArgs e)
        {
            ingredient = new Ingredient("mushroom", "pieczarki");
            yourMushroom.DataContext = ingredient;
            yourMushroom.Visibility = Visibility.Visible;
            mushroomButton.IsEnabled = false;
        }

        private void lettuceButton_Click(object sender, RoutedEventArgs e)
        {
            ingredient = new Ingredient("lettuce", "salata");
            yourLettuce.DataContext = ingredient;
            yourLettuce.Visibility = Visibility.Visible;
            lettuceButton.IsEnabled = false;
        }

        private void oliveButton_Click(object sender, RoutedEventArgs e)
        {
            ingredient = new Ingredient("olive", "oliwki");
            yourOlive.DataContext = ingredient;
            yourOlive.Visibility = Visibility.Visible;
            oliveButton.IsEnabled = false;
        }

        private void AddIngredient(object sender, ExecutedRoutedEventArgs e)
        {
            ingredientList.addIngredient(ingredient);
            if (ingredient.nazwa == "ham")
                yourHam.Visibility = Visibility.Visible;
            else if (ingredient.nazwa == "cheese")
                yourCheese.Visibility = Visibility.Visible;
            else if (ingredient.nazwa == "tomato")
                yourTomato.Visibility = Visibility.Visible;
            else if (ingredient.nazwa == "mushroom")
                yourMushroom.Visibility = Visibility.Visible;
            else if (ingredient.nazwa == "lettuce")
                yourLettuce.Visibility = Visibility.Visible;
            else if (ingredient.nazwa == "olive")
                yourOlive.Visibility = Visibility.Visible;
        }

        private void AddIngredientCE(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void RedoMove(object sender, ExecutedRoutedEventArgs e)
        {
            ingredientList.redoMove();
            if (ingredientList.Last().nazwa == "ham")
            {
                yourHam.Visibility = Visibility.Visible;
                hamButton.IsEnabled = false;
            }
            else if (ingredientList.Last().nazwa == "cheese")
            {
                yourCheese.Visibility = Visibility.Visible;
                cheeseButton.IsEnabled = false;
            }
            else if (ingredientList.Last().nazwa == "tomato")
            {
                yourTomato.Visibility = Visibility.Visible;
                tomatoButton.IsEnabled = false;
            }
            else if (ingredientList.Last().nazwa == "mushroom")
            {
                yourMushroom.Visibility = Visibility.Visible;
                mushroomButton.IsEnabled = false;
            }
            else if (ingredientList.Last().nazwa == "lettuce")
            {
                yourLettuce.Visibility = Visibility.Visible;
                lettuceButton.IsEnabled = false;
            }
            else if (ingredientList.Last().nazwa == "olive")
            {
                yourOlive.Visibility = Visibility.Visible;
                oliveButton.IsEnabled = false;
            }
        }

        private void RedoMoveCE(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ingredientList.unlockRedo();
        }

        private void UndoMove(object sender, ExecutedRoutedEventArgs e)
        {
            if (ingredientList.Last().nazwa == "ham")
            {
                yourHam.Visibility = Visibility.Hidden;
                hamButton.IsEnabled = true;
            }
            else if (ingredientList.Last().nazwa == "cheese")
            {
                yourCheese.Visibility = Visibility.Hidden;
                cheeseButton.IsEnabled = true;
            }
            else if (ingredientList.Last().nazwa == "tomato")
            {
                yourTomato.Visibility = Visibility.Hidden;
                tomatoButton.IsEnabled = true;
            }
            else if (ingredientList.Last().nazwa == "mushroom")
            {
                yourMushroom.Visibility = Visibility.Hidden;
                mushroomButton.IsEnabled = true;
            }
            else if (ingredientList.Last().nazwa == "lettuce")
            {
                yourLettuce.Visibility = Visibility.Hidden;
                lettuceButton.IsEnabled = true;
            }
            else if (ingredientList.Last().nazwa == "olive")
            {
                yourOlive.Visibility = Visibility.Hidden;
                oliveButton.IsEnabled = true;
            }
            ingredientList.undoMove();
        }

        private void UndoMoveCE(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ingredientList.unlockUndo();
        }

        private void Done_Click(object sender, RoutedEventArgs e)
        {
            doneButton.IsEnabled = false;
            endLevel();
        }

        public void savePointsList()
        {
            string filename = "plik.txt";

            using (StreamWriter writer = new StreamWriter(filename, false))
            {
                for (int i = 0; i < pointsCount.Count(); i++)
                {
                    writer.WriteLine(pointsCount[i]);
                }
                writer.Flush();
                writer.Close();
            }
        }

        public void endLevel()
        {
            if (!hamButton.IsEnabled)
                yourIngredients[0] = true;
            if (!cheeseButton.IsEnabled)
                yourIngredients[1] = true;
            if (!tomatoButton.IsEnabled)
                yourIngredients[2] = true;
            if (!mushroomButton.IsEnabled)
                yourIngredients[3] = true;
            if (!lettuceButton.IsEnabled)
                yourIngredients[4] = true;
            if (!oliveButton.IsEnabled)
                yourIngredients[5] = true;

            pointsCount[levelNumber-1] = levelSeconds.Seconds;
            savePointsList();

            GameplaySummary gameplaySummary = new GameplaySummary(yourIngredients, levelNumber, newContent, decision, pointsCount);
            gameplaySummary.Show();
        }
    }
}
