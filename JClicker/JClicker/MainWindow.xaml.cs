using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
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
        int Interval = 1000;
        private double CountIntervalUpdates = 0;


        Timer _timer;

        List<string> Upgrades = new List<string>();


        public MainWindow()
        {
            InitializeComponent();
          
            // Start a repeating timer.
            _timer = new Timer(Tick, null, Interval, Timeout.Infinite);
        }


        private void ClickButton_Click(object sender, RoutedEventArgs e)
        {
            TotalClicks++;
            Console.WriteLine("User clicked the button!");
            if(TotalClicks % 10 == 0)
            {
                TotalCoins++;
                
            }
            UpdateVisual();

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
           
        }



        public void AddUpgrade(String upgrade)
        {
            Upgrades.Add("Pointer");
            UpdateVisual();

        }

        private void UpdateVisual()
        {
            ClickCounter.Content = "Total Clicks: " + TotalClicks;
            CoinCounter.Content = "Total Coins: " + TotalCoins;
            for (int i = 0; i < Upgrades.Count; i++)
            {
                if (Upgrades[i] == "Pointer")
                {

                    PointersLabel.Content = (i+1) + PointersLabel.Content.ToString().Substring(1);
                }
            }
        }

        public int CountUpdate(String name)
        {
            int num = 0;
            for (int i = 0; i < Upgrades.Count; i++)
            {
                if(Upgrades[i] == name)
                {
                    num++;
                }
            }
            return num;
        }

        private void Tick(object state)
        {
            try
            {
               
                ++CountIntervalUpdates;
                if(CountIntervalUpdates % 2 == 0)
                {
                    // Run things after 2 seconds have passed.
                    TotalClicks += CountUpdate("Pointer");
                }
                // Update visuals off main thread.
                Dispatcher.Invoke(() =>
                {
                    UpdateVisual();
                });
            }
            finally
            {
                _timer?.Change(Interval, Timeout.Infinite);
            }
        }
    }
}
