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

namespace JClicker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int TotalClicks = 0;
        private int TotalCoins = 0;
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void ClickButton_Click(object sender, RoutedEventArgs e)
        {
            TotalClicks++;
            ClickCounter.Content = "Total Clicks: "+TotalClicks;
            if(TotalClicks % 100 == 0)
            {
                TotalCoins++;
                CoinCounter.Content = "Total Coins: " + TotalCoins;
            }
        }
    }
}
