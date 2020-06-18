﻿using JClicker.Upgrades;
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
        private int TotalCoins = 1000;
        readonly int Interval = 10; // 1MS Run Event
        private double CountIntervalUpdates = 0;
        readonly Timer _timer;

        public int MW_TotalClicks { get; set; } = 0;


        public MainWindow()
        {
            InitializeComponent();

            SetupTooltips();

            ClickButton.Content = new Image
            {
                
                Source = new BitmapImage(new Uri("cookie.png", UriKind.Relative)),
                VerticalAlignment = VerticalAlignment.Center,
                Stretch = Stretch.Fill,
                Height = 180,
                Width = 180
                
            };
           
            // Start a repeating timer.
            _timer = new Timer(Tick, null, Interval, Timeout.Infinite);
        }


        public void SetupTooltips()
        {
            
            PointersLabel.ToolTip = new ToolTip { Content = "Gain 1 extra cookie every 2 seconds.\nCost: 1 Coin\nCPS: 0.5" };
            BuyPointerButton.ToolTip = new ToolTip { Content = "Click to buy 1x Pointer upgrade." };
                
            ClickerLabel.ToolTip = new ToolTip { Content = "Gain 3 extra cookies every 1 second.\nCost: 4 Coins\nCPS: 3.0" };
            BuyClickerButton.ToolTip = new ToolTip { Content = "Click to buy 1x Clicker upgrade." };

            BakerLabel.ToolTip = new ToolTip { Content = "Gain 10 Cookies every second. \nCost: 8 Coins\nCPS: 10" };
            BuyBakerButton.ToolTip = new ToolTip { Content = "Click to buy 1x Baker upgrade." };
        
        }

        public List<Upgrade> GetUpgradeList()
        {
            return Upgrades;
        }

 

        private void ClickButton_Click(object sender, RoutedEventArgs e)
        {
            MW_TotalClicks++;
            Console.WriteLine("User clicked the button!");
            CheckForCoins();
            // UpdateVisual() called in CheckForCoins();
        }
        public void CheckForCoins()
        {
            if (MW_TotalClicks % 100 == 0)
            {
                TotalCoins++;
            }
            Dispatcher.Invoke(() =>
            {
                UpdateVisual();
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string ButtonPressedName = (sender as Button).Name; // Get the name of button clicked.
            if(ButtonPressedName.Equals("BuyPointerButton"))
            {
                Upgrade upgrade = new PointerUpgrade("Pointer", PointerUpgrade.BasePrice, this);


                //upgrade.Price *= Upgrades.Count(u => u.GetType() == typeof(PointerUpgrade));
                
                if (TotalCoins < upgrade.Price)
                {
                    MessageBox.Show("You do not have enough currency to purchase this item!");
                    return;
                }


                TotalCoins -= (int)upgrade.Price;
                Upgrades.Add(upgrade);
                
            }else if(ButtonPressedName.Equals("BuyClickerButton"))
            {
                Upgrade upgrade = new ClickerUpgrade("Clicker", ClickerUpgrade.BasePrice, this);

                if (TotalCoins < upgrade.Price)
                {
                    MessageBox.Show("You do not have enough currency to purchase this item!");
                    return;
                }

                TotalCoins -= (int)upgrade.Price;
                Upgrades.Add(upgrade);
            }else if(ButtonPressedName.Equals("BuyBakerButton"))
            {
                // Setup Baker Upgrade.
                Upgrade upgrade = new BakerUpgrade("Baker", BakerUpgrade.BasePrice, this);
                if(TotalCoins < upgrade.Price)
                {
                    MessageBox.Show("You do not have enough currency to purchase this item!");
                    return;
                }
                TotalCoins -= (int)upgrade.Price;
                Upgrades.Add(upgrade);
            }
                UpdateVisual();
        }

        /// <summary>
        /// Updates the text on the screen to account for changes.
        /// </summary>
        public  void UpdateVisual()
        {
            ClickCounter.Content = "Total Cookies: " + MW_TotalClicks;
            CoinCounter.Content = "Total Coins: " + TotalCoins;

            // List all upgrade labels here.

            PointersLabel.Content = Upgrades.Count(u => u.GetType() == typeof(PointerUpgrade)) + "x " + "Pointer (0.5CPS) - " + new PointerUpgrade(null,PointerUpgrade.BasePrice,this).Price + "C";
            ClickerLabel.Content = Upgrades.Count(u => u.GetType() == typeof(ClickerUpgrade)) + " x Clicker (3CPS) - " + new ClickerUpgrade(null, ClickerUpgrade.BasePrice, this).Price + "C"; ;
            BakerLabel.Content = Upgrades.Count(u => u.GetType() == typeof(BakerUpgrade)) + " x Baker (8CPS) - " + new BakerUpgrade(null, BakerUpgrade.BasePrice, this).Price + "C";

        }

       

        private void Tick(object state)
        {
            CountIntervalUpdates++;
            try
            {
                Upgrades.ForEach(u => u.ClickAction(CountIntervalUpdates));
                
                // Update UI
                Dispatcher.Invoke(() =>
                {
                    UpdateVisual();
                });
            }catch(Exception)
            {

            }
            finally
            {
                _timer?.Change(Interval, Timeout.Infinite);
            }
        }
    }
}
