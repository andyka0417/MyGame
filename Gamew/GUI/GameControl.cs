using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace GUI
{
    /// <summary>
    /// A FrameworkElement segítségével tudunk különböző objektumokat, elemeket kirajzoltatni a képernyőre.
    /// </summary>
    public class GameControl : FrameworkElement
    {
        Window me;
        DispatcherTimer t;
        public GameControl() {
            // Ha az ablak betöltődött, hívja meg a GameControl_Loaded függvényt.
            this.Loaded += GameControl_Loaded;
        }

        private void GameControl_Loaded(object sender, RoutedEventArgs e)
        {
            // Visszaadja azt az ablakot ahova beraktuk a GameController elemet.
            this.me = Window.GetWindow(this);
            // Ha talált érvényes ablakot
            if (this.me != null) {
                // Létrehozunk egy új időzítőt
                this.t = new DispatcherTimer();
                // Képfrissítés gyakorisága
                this.t.Interval = TimeSpan.FromMilliseconds(100);
                this.t.Tick += T_Tick;
                this.t.Start();
            }

            // Letisztítja a képernyőt.
            this.InvalidateVisual();
        }

        private void T_Tick(object sender, EventArgs e)
        {
            this.InvalidateVisual();
        }

        /// <summary>
        /// Az InvalidateVisual után hívódik meg.
        /// </summary>
        /// <param name="drawingContext"></param>
        protected override void OnRender(DrawingContext drawingContext)
        {
            drawingContext.DrawLine(new Pen(Brushes.Black, 2), new Point(0, 0), new Point(50, 50));
        }
    }
}
