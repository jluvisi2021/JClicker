using JClicker.Upgrades;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
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
        private List<Upgrade> Upgrades = new List<Upgrade>();
        private int TotalCoins = 10;
        readonly int Interval = 10; // 1MS Run Event
        private double CountIntervalUpdates = 0;
        readonly Timer _timer;

        public int MW_TotalClicks { get; set; } = 0;


        public MainWindow()
        {
            InitializeComponent();
          
            // Start a repeating timer.
            _timer = new Timer(Tick, null, Interval, Timeout.Infinite);
        }

        public List<Upgrade> GetUpgradeList()
        {
            return Upgrades;
        }

 

        private void ClickButton_Click(object sender, RoutedEventArgs e)
        {
            MW_TotalClicks++;
            Console.WriteLine("User clicked the button!");
            if(MW_TotalClicks % 10 == 0)
            {
                TotalCoins++;
                
            }
            UpdateVisual();

        }
        // Pointer "BUY" Button Click
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Upgrade upgrade = new PointerUpgrade("Pointer", 1.0, this);

            if(TotalCoins < upgrade.Price)
            {
                MessageBox.Show("You do not have enough currency to purchase this item!");
                return;
            }

            TotalCoins -= (int)upgrade.Price;
            Upgrades.Add(upgrade);
            UpdateVisual();
           
        }

        public void UpdateVisual()
        {
            ClickCounter.Content = "Total Clicks: " + MW_TotalClicks;
            CoinCounter.Content = "Total Coins: " + TotalCoins;
            for (int i = 0; i < Upgrades.Count; i++)
            {
                //TODO: Change to Switch Case LATER
                if (Upgrades[i].Name == "Pointer")
                {

                    PointersLabel.Content = (i+1) + PointersLabel.Content.ToString().Substring(1);
                }
            }
        }

       

        private void Tick(object state)
        {
            CountIntervalUpdates++;
            try
            {
                foreach(Upgrade u in Upgrades)
                {
                    u.ClickAction(CountIntervalUpdates);
                }
               
            }
            finally
            {
                _timer?.Change(Interval, Timeout.Infinite);
            }
        }
    }
}
