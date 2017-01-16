using PizzaMaker.Command;
using PizzaMaker.Template_Method;
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
        DispatcherTimer _timer;
        DispatcherTimer _timer2;
        TimeSpan _time;
        TimeSpan _time2;
        int levelNumber = 1;
        ContentControl newContent = new ContentControl();
        int decision = 0;

        private IngredientList ingredList = new IngredientList();

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

        public Gameplay(int decision, int levelNumber, ContentControl newContent)
        {
            this.newContent = newContent;
            this.decision = decision;
            this.levelNumber = levelNumber;
            AbstractLevel levelType = new EasyLevel();
            if (decision == 1)
                levelType = new EasyLevel();
            else if (decision == 2)
                levelType = new HardLevel();

            levelType.setGame(levelNumber);
            MessageBox.Show(levelType.levelNumber);
            //this.label.Content = "hhe";
            //text.Text = levelType.levelNumber;
            //levelNumberText.Content = levelType.levelNumber;

            InitializeComponent();

            _time2 = TimeSpan.FromSeconds(levelType.tipTime);

            _timer2 = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                if (_time2 == TimeSpan.Zero)
                {
                    pizzaImgTip.Visibility = System.Windows.Visibility.Hidden;
                }
                _time2 = _time2.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);

            _timer2.Start();

            _time = TimeSpan.FromSeconds(levelType.gameTime);

            _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                tbTime.Text = _time.ToString("c");
                if (_time == TimeSpan.Zero)
                {
                    _timer.Stop();
                    // MessageBox.Show("Stop");
                }
                _time = _time.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);

            _timer.Start();
        }

        

        Ingredient ingredient = new Ingredient("", "");

        private void hamButton_Click(object sender, RoutedEventArgs e)
        {
            //Ingredient ingredient = new Ingredient("ham", "dobra szynka");
            ingredient = new Ingredient("ham", "szynka");
            yourHam.DataContext = ingredient;
            //ingredientList.addIngredient(ingredient);
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

        private void AddIngredient(object sender, ExecutedRoutedEventArgs e)
        {
            //Ingredient ingredient = new Ingredient("ham", "dobra szynka");
            ingredientList.addIngredient(ingredient);
            if (ingredient.nazwa == "ham")
                yourHam.Visibility = Visibility.Visible;
            else if (ingredient.nazwa == "cheese")
                yourCheese.Visibility = Visibility.Visible;
        }

        private void AddIngredientCE(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void RedoMove(object sender, ExecutedRoutedEventArgs e)
        {
            ingredientList.redoMove();
            if (ingredientList.First().nazwa == "ham")
            {
                yourHam.Visibility = Visibility.Visible;
                hamButton.IsEnabled = false;
            }
            else if (ingredientList.First().nazwa == "cheese")
            {
                yourCheese.Visibility = Visibility.Visible;
                cheeseButton.IsEnabled = false;
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
            ingredientList.undoMove();
        }

        private void UndoMoveCE(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ingredientList.unlockUndo();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Visibility[] tablica = new Visibility[6];
            tablica[0] = yourHam.Visibility;
            tablica[1] = yourCheese.Visibility;
            GameplaySummary gameplaySummary = new GameplaySummary(tablica, levelNumber, newContent, decision);
            gameplaySummary.Show();
        }


    }
}
