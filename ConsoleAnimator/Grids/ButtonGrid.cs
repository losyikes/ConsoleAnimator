using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Diagnostics;
using Microsoft.Win32;

namespace ConsoleAnimator
{
    class ButtonGrid : Grid
    {
        FileHandler fileHandler = new FileHandler();
        AnimationControls animationControls;
        List<Thumbnail> thumbnailList = new List<Thumbnail>();
        public ButtonGrid(AnimationControls aControls)
        {
            animationControls = aControls;
            this.HorizontalAlignment = HorizontalAlignment.Left;
            this.VerticalAlignment = VerticalAlignment.Top;
            drawButtons();
        }
        void drawButtons()
        {
            int buttonWidth = 125;
            int buttonHeight = 25;

            Button renderBtn = new Button();
            renderBtn.Content = "Add Frame";
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
            clearGridBtn.Height = buttonHeight;
            clearGridBtn.VerticalAlignment = VerticalAlignment.Top;
            clearGridBtn.HorizontalAlignment = HorizontalAlignment.Left;
            clearGridBtn.BorderBrush = Brushes.Black;
            clearGridBtn.BorderThickness = new Thickness(1);
            clearGridBtn.Background = null;
            clearGridBtn.Padding = new Thickness(10, 0, 10, 0);
            clearGridBtn.Click += ClearGridBtn_Click;
            clearGridBtn.Margin = new Thickness(10, buttonHeight + 10 , 0, 0);
            this.Children.Add(clearGridBtn);

            Button saveThumbBtn = new Button();
            saveThumbBtn.Content = "Save Frames";
            saveThumbBtn.Width = buttonWidth;
            saveThumbBtn.Height = buttonHeight;
            saveThumbBtn.VerticalAlignment = VerticalAlignment.Top;
            saveThumbBtn.HorizontalAlignment = HorizontalAlignment.Left;
            saveThumbBtn.BorderBrush = Brushes.Black;
            saveThumbBtn.BorderThickness = new Thickness(1);
            saveThumbBtn.Background = null;
            saveThumbBtn.Padding = new Thickness(10, 0, 10, 0);
            saveThumbBtn.Click += SaveThumbBtn_Click;
            saveThumbBtn.Margin = new Thickness(10, buttonHeight * 2 + 20, 0, 0);
            this.Children.Add(saveThumbBtn);

            Button runAnimationBtn = new Button();
            runAnimationBtn.Content = "Run Animation";
            runAnimationBtn.Width = buttonWidth;
            runAnimationBtn.Height = buttonHeight;
            runAnimationBtn.VerticalAlignment = VerticalAlignment.Top;
            runAnimationBtn.HorizontalAlignment = HorizontalAlignment.Left;
            runAnimationBtn.BorderBrush = Brushes.Black;
            runAnimationBtn.BorderThickness = new Thickness(1);
            runAnimationBtn.Background = null;
            runAnimationBtn.Padding = new Thickness(10, 0, 10, 0);
            runAnimationBtn.Click += RunAnimationBtn_Click;
            runAnimationBtn.Margin = new Thickness(10, buttonHeight * 3 + 30, 0, 0);
            this.Children.Add(runAnimationBtn);

            this.Width = renderBtn.Width + 10;
        }

        private void RunAnimationBtn_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("Player.Exe", fileHandler.Path);
        }

        private void SaveThumbBtn_Click(object sender, RoutedEventArgs e)
        {
            string filename = "";
            // Configure save file dialog box
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = "Animation-1"; // Default file name
            dlg.DefaultExt = ".json"; // Default file extension
            dlg.Filter = "Json Files (.json)|*.json"; // Filter files by extension

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                filename = dlg.FileName;
            }
            
            fileHandler.Path = filename;
            thumbnailList = animationControls.ThumbGrid.thumbnailList;
            fileHandler.SaveThumbnails(thumbnailList, filename);
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
