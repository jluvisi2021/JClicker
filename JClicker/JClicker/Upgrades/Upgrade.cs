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
        /// <summary>
        /// Perform the action that the upgrade does.
        /// </summary>
        /// <param name="timerseconds"></param>
        public abstract void ClickAction(double timerseconds);

        /// <summary>
        /// Runs the same function as the UpdateVisual() in MainWindow
        /// only this one uses the Dispatcher Invoke.
        /// </summary>
        public void UpdateVisual()
        {
            MainWindow.Dispatcher.Invoke(() =>
            {
                MainWindow.UpdateVisual();
            });
        }

        /// <summary>
        /// Parse the MS to Seconds.
        /// Not entirely accurate but close enough.
        /// </summary>
        /// <param name="ms"></param>
        /// <returns></returns>
        protected static double ParseSeconds(double ms)
        {
            return ms / 65;
        }
    }
}
