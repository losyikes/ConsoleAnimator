using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace ConsoleAnimator
{
    class AnimationGrid : Grid
    {
        private static Action EmptyDelegate = delegate () { };
        AnimationControls animationControls;
        public AnimationGrid(int charWidth, int charHeight, AnimationControls aControls)
        {
            animationControls = aControls;
            Grid grid = new Grid();
            this.Width = (charWidth * 25);
            this.Height = (charHeight * 23);
            this.HorizontalAlignment = HorizontalAlignment.Left;
            this.VerticalAlignment = VerticalAlignment.Top;
            int lblNameCounter = 0;
            int marginLeft = 0;
            int marginTop = 0;
            for (int i = 0; i < charWidth; i++)
            {
                marginLeft = 0;
                for (int j = 0; j < charHeight; j++)
                {
                    lblNameCounter++;
                    Label lbl = new Label();
                    lbl.Width = 20;
                    lbl.Height = 20;
                    lbl.Padding = new Thickness(0);
                    lbl.HorizontalContentAlignment = HorizontalAlignment.Center;
                    lbl.VerticalContentAlignment = VerticalAlignment.Center;
                    lbl.Margin = new Thickness(marginLeft, marginTop, 0, 0);
                    lbl.HorizontalAlignment = HorizontalAlignment.Left;
                    lbl.VerticalAlignment = VerticalAlignment.Top;
                    lbl.BorderThickness = new Thickness(1);
                    lbl.BorderBrush = Brushes.Black;
                    lbl.MouseDown += new MouseButtonEventHandler(OnAnimationLblMouseDown);
                    this.Children.Add(lbl);
                    marginLeft += 22;
                }
                marginTop += 22;
            }

        }
        void OnAnimationLblMouseDown(object sender, MouseButtonEventArgs e)
        {
            Label senderLbl = (Label)sender;
            senderLbl.Background = animationControls.currentColor;
            senderLbl.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
        }
    }
}
