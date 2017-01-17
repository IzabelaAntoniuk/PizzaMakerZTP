using PizzaMaker.State;
using System.Windows;

namespace PizzaMaker
{
    /// <summary>
    /// Interaction logic for SignIn.xaml
    /// </summary>
    public partial class SignIn : Window
    {
        private Authorization authorizationKey = new Authorization();

        public SignIn()
        {
            InitializeComponent();
        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = authorizationKey.checkUser(nickname.Text, password.Password);
            this.Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}
