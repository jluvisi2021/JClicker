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
       
        public PointerUpgrade(string Name = null, double Price = 0.0, MainWindow MainWindow = null)
        {
            base.Name = Name;
            base.Price = Price;
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
