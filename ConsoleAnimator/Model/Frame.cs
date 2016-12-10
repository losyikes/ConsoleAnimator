using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAnimator
{
    public class Frame
    {
        public List<Pixel> PixelList { get; set; }
        public Frame()
        {

        }
        public Frame(List<Pixel> pixelList)
        {
            PixelList = pixelList;
        }
    }
}
