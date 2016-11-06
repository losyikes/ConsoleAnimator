using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Player
{
    public class ConsoleAnimation
    {
        public ConsoleAnimation(List<ConsoleFrame> frameList)
        {
            FrameList = frameList;
        }
        public List<ConsoleFrame> FrameList { get; set; }
        public void RunAnimation()
        {
            while (true)
            {
                foreach (ConsoleFrame frame in FrameList)
                {
                    Console.CursorVisible = false;
                    frame.RunFrame();
                    Thread.Sleep(100);
                    Console.Clear();
                }
            }
            
        }
    }
}
