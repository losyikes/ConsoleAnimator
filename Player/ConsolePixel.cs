using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Player
{
    public class ConsolePixel
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Color { get; set; }
        public ConsolePixel(int x, int y, string color)
        {
            this.X = x;
            this.Y = y;
            this.Color = color;
            
        }
        public ConsolePixel()
        {

        }
    }
}
