using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JClicker.Upgrades
{
    public class ClickerUpgrade : Upgrade
    {
        readonly int ClickValue = 3;
        public static int BasePrice = 3;
        public ClickerUpgrade(string Name = null, double Price = 0.0, MainWindow MainWindow = null)
        {
            base.Name = Name;
            int amt = MainWindow.GetUpgradeList().Count(u => u.GetType() == typeof(ClickerUpgrade));

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
            
            if(timerseconds % 65 == 0)
            {

                MainWindow.MW_TotalClicks += ClickValue;
                   // MainWindow.CheckForCoins();
                
                //MainWindow.MW_TotalClicks += ClickValue;
            }
            
        }
    }
}
