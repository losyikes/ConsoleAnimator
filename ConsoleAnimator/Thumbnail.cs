using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ConsoleAnimator
{
    class Thumbnail : Canvas
    {
        public List<Pixel> PixelList { get; set; }
        public Thumbnail(List<Pixel> pixelList, AnimationControls aControls)
        {
            PixelList = pixelList;
            this.Width = aControls.AnimationGrid.CharacterWidth * 4;
            this.Height = aControls.AnimationGrid.CharacterHeight * 4;
            this.HorizontalAlignment = HorizontalAlignment.Left;
            this.VerticalAlignment = VerticalAlignment.Top;
            this.Background = Brushes.Black;
            drawThumbnail();
            int marginTop = aControls.ThumbGrid.thumbnailList.Count * ((int)this.Height + 10) + 20;
            this.Margin = new Thickness(10, marginTop, 0, 0);
        }
        void drawThumbnail()
        {
            int marginLeft = 0;
            int marginTop = 0;
            
            foreach (Pixel pixel in PixelList)
            {
                Rectangle rectangle = drawPixel(pixel.X, pixel.Y, pixel.Color);
                marginTop = pixel.Y * 4 - 4;
                marginLeft = pixel.X * 4 - 4;
                rectangle.Margin = new Thickness(marginLeft, marginTop, 0, 0);
                this.Children.Add(rectangle);
            }
        }
        Rectangle drawPixel(int x,int y, SolidColorBrush fill)
        {
            Rectangle r = new Rectangle();
            r.Width = 4;
            r.Height = 4;
            r.Fill = fill;
            
            return r;

        }

       
    }
}
