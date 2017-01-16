using PizzaMaker.Command;
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

namespace PizzaMaker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //ListCollectionView view;
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
        //ListCollectionView view;
        //private ListaZadan listaZadan = new ListaZadan();
        //private List<IObserwator> obs = new List<IObserwator>();

        //public ListaZadan ListaZad
        //{
        //    get
        //    {
        //        return listaZadan;
        //    }
        //    set
        //    {
        //        listaZadan = value;
        //    }
        //}

        public MainWindow()
        {
            SignIn signIn;
            do
            {
                signIn = new SignIn();
                signIn.ShowDialog();
            } while (signIn.DialogResult == false);

            InitializeComponent();
        }


        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void zamknijButton_Click(object sender, RoutedEventArgs e)
        {
        }


        private void AddIngredient(object sender, ExecutedRoutedEventArgs e)
        {
            //AddIngredient dodaj = new AddIngredient(zadania);
            //dodaj.Owner = this;
            //dodaj.ShowDialog();
            //MessageBox.Show("dodalam szynke wow wow");
        }

        private void AddIngredientCE(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void UsunZadanie(object sender, ExecutedRoutedEventArgs e)
        {
        }

        private void UsunZadanieCE(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }


        private void FiltrujZadania(object sender, ExecutedRoutedEventArgs e)
        {
        }

        private void FiltrujZadaniaCE(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void UsunFiltrujZadania(object sender, ExecutedRoutedEventArgs e)
        {
        }

        private void UsunFiltrujZadaniaCE(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }


        private void GrupujZadania(object sender, ExecutedRoutedEventArgs e)
        {
        }

        private void GrupujZadaniaCE(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void UsunGrupujZadania(object sender, ExecutedRoutedEventArgs e)
        {
        }

        private void UsunGrupujZadaniaCE(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        

        private void OtworzPlik()
        {
        }

        private void ZapiszPlik(String nazwaPliku)
        {
        }

        private void zapiszButton_Click(object sender, RoutedEventArgs e)
        {
            ZapiszPlik("zapisz.txt");
        }

        private void RozpocznijZadanie(object sender, ExecutedRoutedEventArgs e)
        {
        }
        private void RozpocznijZadanieCE(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ZakonczZadanie(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }
        private void ZakonczZadanieCE(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void logButton_Click(object sender, RoutedEventArgs e)
        {
            this.contentControl.Content = new StartGame(this.contentControl);
            
        }

        private void statyButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void RedoMove(object sender, ExecutedRoutedEventArgs e)
        {
            ingredientList.redoMove();
        }

        private void RedoMoveCE(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ingredientList.unlockRedo();
        }

        private void UndoMove(object sender, ExecutedRoutedEventArgs e)
        {
            ingredientList.undoMove();
        }

        private void UndoMoveCE(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ingredientList.unlockUndo();
        }

        public void Powiadom()
        {
        }
    }
}
