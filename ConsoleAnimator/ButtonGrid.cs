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
    class ButtonGrid : Grid
    {
        AnimationControls animationControls;
        public ButtonGrid(AnimationControls aControls)
        {
            animationControls = aControls;
            this.HorizontalAlignment = HorizontalAlignment.Left;
            this.VerticalAlignment = VerticalAlignment.Top;
            drawButtons();
        }
        void drawButtons()
        {
            Button renderBtn = new Button();
            renderBtn.Content = "Render Thumbnail";
            renderBtn.Width = 100;
            renderBtn.Height = 25;
            renderBtn.VerticalAlignment = VerticalAlignment.Top;
            renderBtn.HorizontalAlignment = HorizontalAlignment.Left;
            renderBtn.BorderBrush = Brushes.Black;
            renderBtn.BorderThickness = new Thickness(1);
            renderBtn.Background = null;
            renderBtn.Padding = new Thickness(10, 0, 10, 0);
            renderBtn.Click += RenderBtn_Click;
            renderBtn.Margin = new Thickness(10, 0,0,0);
            this.Children.Add(renderBtn);
            this.Width = renderBtn.Width + 10;
        }

        private void RenderBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // drawthumbnail and add it to thumbsgrid
            animationControls.ThumbGrid.AddThumbnailToGrid();
        }
        
    }
    
}
