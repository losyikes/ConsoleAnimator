using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player
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
        ConsoleColor getConsoleColor(string hex)
        {
            switch (hex)
            {
                case "#FF000000":
                    return ConsoleColor.Black;
                case "#FF0000FF":
                    return ConsoleColor.Blue;
                case "#FF00008B":
                    return ConsoleColor.DarkBlue;
                case "#FF008000":
                    return ConsoleColor.Green;
                case "#FF006400":
                    return ConsoleColor.DarkGreen;
                case "#FF00FFFF":
                    return ConsoleColor.Cyan;
                case "#FF008B8B":
                    return ConsoleColor.DarkCyan;
                case "#FFFF0000":
                    return ConsoleColor.Red;
                case "#FF8B0000":
                    return ConsoleColor.DarkRed;
                case "#FFFF00FF":
                    return ConsoleColor.Magenta;
                case "#FF8B008B":
                    return ConsoleColor.DarkMagenta;
                case "#FFFFFF00":
                    return ConsoleColor.Yellow;
                case "#FF808080":
                    return ConsoleColor.Gray;
                case "#FFA9A9A9":
                    return ConsoleColor.DarkGray;
                case "#FFFFFFFF":
                    return ConsoleColor.White;
                default:
                    return ConsoleColor.Black;
            }
        
        }
        public void RunFrame()
        {
            ConsoleColor currentColor = ConsoleColor.Black;
            int currentLine = 1;
            string sequence = "";
            foreach(ConsolePixel pixel in PixelList)
            {
                if(currentLine != pixel.Y)
                {
                    sequence += "\n";
                    currentLine++;
                }
                ConsoleColor pixelBackgroundColor = getConsoleColor(pixel.Color);
                if (pixelBackgroundColor == currentColor)
                {
                    sequence += " ";
                }
                else
                {
                    Console.Write(sequence);
                    Console.BackgroundColor = pixelBackgroundColor;
                    currentColor = pixelBackgroundColor;
                    sequence = " ";
                }
            }
        }
    }
}
