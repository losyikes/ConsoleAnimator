using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAnimator
{
    public class ConsoleFrame
    {
        public List<ConsolePixel> PixelList { get; set; }
        public ConsoleFrame()
        {

        }
        public ConsoleFrame(List<ConsolePixel> pixelList)
        {
            PixelList = pixelList;
        }
        ConsoleColor ConvertToConsoleColor(string hex)
        {
            switch (hex)
            {
                default:
                    return ConsoleColor.Black;
            }
        
        }
    }
}
