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
            string response;
            if (args.Count() == 0)
                response = "default.json";
            else
                response = args[0];
            program.Run(response);
        }
        void Run(string arg)
        {
            Console.WriteLine(arg);
            
            PlayerFileHandler fileHandler = new PlayerFileHandler();
            ConsoleAnimation animation = new ConsoleAnimation(fileHandler.ReadFromJsonFile<List<ConsoleFrame>>(arg));
            animation.RunAnimation();
            
            Console.ReadKey();
        }
    }
}
