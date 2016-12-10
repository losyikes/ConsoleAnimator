using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace ConsoleAnimator
{
    class ControlButton : Button
    {
        ////Button runAnimationBtn = new Button();
        ////runAnimationBtn.Content = "Run Animation";
        ////runAnimationBtn.Width = buttonWidth;
        ////runAnimationBtn.Height = buttonHeight;
        ////runAnimationBtn.VerticalAlignment = VerticalAlignment.Top;
        ////runAnimationBtn.HorizontalAlignment = HorizontalAlignment.Left;
        ////runAnimationBtn.BorderBrush = Brushes.Black;
        ////runAnimationBtn.BorderThickness = new Thickness(1);
        ////runAnimationBtn.Background = null;
        ////runAnimationBtn.Padding = new Thickness(10, 0, 10, 0);
        //runAnimationBtn.Click += RunAnimationBtn_Click;
        ////runAnimationBtn.Margin = new Thickness(10, buttonHeight* 3 + 30, 0, 0);
        public ControlButton(string content, int buttonNrFromTop)
        {
            this.Width = 125;
            this.Height = 25;
            this.Content = content;
            this.VerticalAlignment = VerticalAlignment.Top;
            this.HorizontalAlignment = HorizontalAlignment.Left;
            this.BorderBrush = Brushes.Black;
            this.BorderThickness = new Thickness(1);
            this.Background = null;
            this.Padding = new Thickness(10, 0, 10, 0);
            buttonNrFromTop = buttonNrFromTop - 1;
            double marginTop = (Height * buttonNrFromTop) + (buttonNrFromTop * 10);
            this.Margin = new Thickness(10, marginTop, 0, 0);
            
        }
    }
}
