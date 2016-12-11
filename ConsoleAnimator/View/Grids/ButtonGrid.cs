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
            Button renderBtn = new ControlButton("Add Frame", 1);
            renderBtn.Click += RenderBtn_Click;
            this.Children.Add(renderBtn);

            Button clearGridBtn = new ControlButton("Clear Grid", 2);
            clearGridBtn.Click += ClearGridBtn_Click;
            this.Children.Add(clearGridBtn);

            Button saveThumbBtn = new ControlButton("Save Frames", 3);
            saveThumbBtn.Click += SaveThumbBtn_Click;
            this.Children.Add(saveThumbBtn);

            Button loadThumbBtn = new ControlButton("Load Frames", 4);
            loadThumbBtn.Click += LoadThumbBtn_Click;
            this.Children.Add(loadThumbBtn);

            Button runAnimationBtn = new ControlButton("Run Animation", 5);
            runAnimationBtn.Click += RunAnimationBtn_Click;
            this.Children.Add(runAnimationBtn);

            this.Width = renderBtn.Width + 10;
        }

        private void LoadThumbBtn_Click(object sender, RoutedEventArgs e)
        {
            string filename = "";
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = ".json";
            dlg.Filter = "Json Files (.json)|*.json";

            Nullable<bool> result = dlg.ShowDialog();


            if (result == true)
            {
                // Save document
                filename = dlg.FileName;
            }
            fileHandler.Path = filename;
            thumbnailList = fileHandler.ReadFromJsonFile<List<Thumbnail>>(filename);
            animationControls.ThumbGrid.AddThumbnailListToGrid(thumbnailList);
            
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
            //dlg.FileName = "Animation-1"; // Default file name
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
