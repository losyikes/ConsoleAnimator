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
            int buttonWidth = 100;

            Button renderBtn = new Button();
            renderBtn.Content = "Render Thumbnail";
            renderBtn.Width = buttonWidth;
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

            Button clearGridBtn = new Button();
            clearGridBtn.Content = "Clear Grid";
            clearGridBtn.Width = buttonWidth;
            clearGridBtn.Height = 25;
            clearGridBtn.VerticalAlignment = VerticalAlignment.Top;
            clearGridBtn.HorizontalAlignment = HorizontalAlignment.Left;
            clearGridBtn.BorderBrush = Brushes.Black;
            clearGridBtn.BorderThickness = new Thickness(1);
            clearGridBtn.Background = null;
            clearGridBtn.Padding = new Thickness(10, 0, 10, 0);
            clearGridBtn.Click += ClearGridBtn_Click;
            clearGridBtn.Margin = new Thickness(10, renderBtn.Height + 10 , 0, 0);
            this.Children.Add(clearGridBtn);
            this.Width = renderBtn.Width + 10;
        }

        private void ClearGridBtn_Click(object sender, RoutedEventArgs e)
        {
            //clear animationGrid
            animationControls.AnimationGrid.ClearGrid();
        }

        private void RenderBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            animationControls.ThumbGrid.AddThumbnailToGrid();
        }
        
    }
    
}
