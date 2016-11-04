using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ConsoleAnimator
{
    class Pixel
    {
        public int X { get; set; }
        public int Y { get; set; }
        public SolidColorBrush Color { get; set; }
        public Pixel(int x, int y, SolidColorBrush color)
        {
            this.X = x;
            this.Y = y;
            this.Color = color;
        }
    }
}
