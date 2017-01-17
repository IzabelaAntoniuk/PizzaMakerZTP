﻿using System;
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
    /// Interaction logic for EndGame.xaml
    /// </summary>
    public partial class EndGame : UserControl
    {
        ContentControl newContent = new ContentControl();

        public EndGame(ContentControl newContent)
        {
            InitializeComponent();
            this.newContent = newContent;
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            this.newContent.Content = new StartGame(newContent);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}
