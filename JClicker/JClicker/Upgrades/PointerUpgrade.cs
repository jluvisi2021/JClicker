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
    public class PointerUpgrade : Upgrade
    {
        readonly int ClickValue = 1;
        public static int BasePrice = 1;
        public PointerUpgrade(string Name = null, double Price = 0.0, MainWindow MainWindow = null)
        {
            base.Name = Name;
            int amt = MainWindow.GetUpgradeList().Count(u => u.GetType() == typeof(PointerUpgrade));

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
            
            if(Upgrade.ParseSeconds(timerseconds) % 2 == 0)
            {
                // Perform action every 2 seconds.
                MainWindow.MW_TotalClicks += ClickValue;
               
            }
           
        }
    }
}
