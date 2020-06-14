using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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

        List<string> Upgrades = new List<string>();


        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void ClickButton_Click(object sender, RoutedEventArgs e)
        {
            TotalClicks++;
            
            if(TotalClicks % 100 == 0)
            {
                TotalCoins++;
                
            }
            update();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(TotalCoins < 1)
            {
                MessageBox.Show("You do not have enough currency to purchase this item!");
                return;
            }

            TotalCoins--;
            AddUpgrade("Pointer");
            update();

        }






        public void AddUpgrade(String upgrade)
        {
            Upgrades.Add("Pointer");
        }
        private void update()
        {
            ClickCounter.Content = "Total Clicks: " + TotalClicks;
            CoinCounter.Content = "Total Coins: " + TotalCoins;

            for(int i = 0; i < Upgrades.Count; i++)
            {
                if(Upgrades[i]=="Pointer")
                {
                    int _Pointers = int.Parse(PointersLabel.Content.ToString().Substring(0, 1));
                    _Pointers++;
                    PointersLabel.Content = _Pointers + PointersLabel.Content.ToString().Substring(1);
                }
            }
        }
    }
}
