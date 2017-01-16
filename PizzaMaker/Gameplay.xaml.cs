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

        private IngredientList ingredList = new IngredientList();
        ListCollectionView view;

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

        public Gameplay(int decision)
        {
            AbstractLevel levelType = new EasyLevel();
            if (decision == 1)
                levelType = new EasyLevel();
            else if (decision == 2)
                levelType = new HardLevel();

            levelType.setGame();

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void hamButton_Click(object sender, RoutedEventArgs e)
        {
            //AddIngredient dodaj = new AddIngredient(zadania);
            //dodaj.Owner = this;
            //dodaj.ShowDialog();
            //MessageBox.Show("dodalam szynke wow wow");
            Ingredient ingredient = new Ingredient("ham", "dobra szynka");
            ing.DataContext = ingredient;
            ingredientList.addIngredient(ingredient);
            yourHam.Visibility = System.Windows.Visibility.Visible;
        }

        private void AddIngredient(object sender, ExecutedRoutedEventArgs e)
        {
            //AddIngredient dodaj = new AddIngredient(zadania);
            //dodaj.Owner = this;
            //dodaj.ShowDialog();
            //MessageBox.Show("dodalam szynke wow wow");
            Ingredient ingredient = new Ingredient("ham", "dobra szynka");
            ingredientList.addIngredient(ingredient);
            yourHam.Visibility = System.Windows.Visibility.Visible;
        }

        private void AddIngredientCE(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void RedoMove(object sender, ExecutedRoutedEventArgs e)
        {
            ingredientList.redoMove();
            if (ingredientList.First().nazwa == "ham")
                yourHam.Visibility = System.Windows.Visibility.Visible;
        }

        private void RedoMoveCE(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ingredientList.unlockRedo();
        }

        private void UndoMove(object sender, ExecutedRoutedEventArgs e)
        {
            if (ingredientList.Last().nazwa == "ham")
                yourHam.Visibility = System.Windows.Visibility.Hidden;
            ingredientList.undoMove();
        }

        private void UndoMoveCE(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ingredientList.unlockUndo();
        }
    }
}
