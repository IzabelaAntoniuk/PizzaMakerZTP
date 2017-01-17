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
        
        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void startGameButton_Click(object sender, RoutedEventArgs e)
        {
            this.contentControl.Content = new StartGame(this.contentControl);
        }

        private void statyButton_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
