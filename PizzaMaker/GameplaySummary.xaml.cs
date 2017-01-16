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

        public GameplaySummary(Visibility[] tab, int levelNumber, ContentControl newContent, int decision)
        {
            InitializeComponent();
            this.tablicaa = tab;
            yourHam.Visibility = tab[0];
            yourCheese.Visibility = tab[1];
            this.levelNumber = levelNumber;
            this.newContent = newContent;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            levelNumber++;
            newContent.Content = new Gameplay(1, levelNumber, newContent);
            this.Close();
        }
    }
}
