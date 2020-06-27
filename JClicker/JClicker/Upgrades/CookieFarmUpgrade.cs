using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JClicker.Upgrades
{
    class CookieFarmUpgrade : Upgrade
    {

        readonly int ClickValue = 35;
        public static int BasePrice = 14;

        public CookieFarmUpgrade(string Name = null, double Price = 0.0, MainWindow MainWindow = null)
        {
            
            base.Name = Name;

            int amt = MainWindow.GetUpgradeList().Count(u => u.GetType() == typeof(CookieFarmUpgrade));

            if (amt == 0)
            {
                base.Price = Price;
            }
            else
            {
                base.Price = Price * amt;
            }
            base.MainWindow = MainWindow;
        }

        

        public override void ClickAction(double timerseconds)
        {
            if (timerseconds % 65 == 0)
            {

                // for(int i = 0; i < ClickValue; i++)
                //  {
                MainWindow.MW_TotalClicks += ClickValue;

                //}
                //MainWindow.MW_TotalClicks += ClickValue;
            }
           
        }
    }
}
