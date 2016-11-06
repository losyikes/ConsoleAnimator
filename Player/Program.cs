using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Player
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Program program = new Program();
            string response = args[0];
            program.Run(response);
        }
        void Run(string arg)
        {
            Console.WriteLine(arg);
            
            FileHandler fileHandler = new FileHandler();
            ConsoleAnimation animation = new ConsoleAnimation(fileHandler.ReadFromJsonFile<List<ConsoleFrame>>(arg));
            animation.RunAnimation();
            //List<ConsoleFrame> frameList = fileHandler.ReadFromJsonFile<List<ConsoleFrame>>(arg);
            //foreach(ConsoleFrame cf in frameList)
            //{
            //    foreach(ConsolePixel cp in cf.PixelList)
            //    {
            //        Console.WriteLine("X:{0} Y:{1} Color: {2}", cp.X, cp.Y, cp.Color);
            //    }
                
            //}
            Console.ReadKey();
        }
    }
}
