using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JClicker.Upgrades
{
    public abstract class Upgrade
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public MainWindow MainWindow { get; set; }
        public abstract void ClickAction(double timerseconds);

        public void UpdateVisual()
        {
            MainWindow.Dispatcher.Invoke(() =>
            {
                MainWindow.UpdateVisual();
            });
        }

        protected static double ParseSeconds(double ms)
        {
            return ms / 65;
        }
    }
}
