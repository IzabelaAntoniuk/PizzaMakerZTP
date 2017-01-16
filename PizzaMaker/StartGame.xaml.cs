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
    /// Interaction logic for StartGame.xaml
    /// </summary>
    public partial class StartGame : UserControl
    {
        private ContentControl thisContent = new ContentControl();

        public StartGame(ContentControl newContent)
        {
            this.thisContent = newContent;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int decision = 0;
            if (easyLevel.IsChecked == true)
                decision = 1;
            else if (hardLevel.IsChecked == true)
                decision = 2;
            
            thisContent.Content = new Gameplay(decision);
        }
    }
}
