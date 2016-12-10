using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ConsoleAnimator
{
    public class ColorGrid : Grid
    {
        
        AnimationControls animationControls;
        public ColorGrid(AnimationControls aControls)
        {
            drawLabels();
            animationControls = aControls;
            animationControls.currentColor = Brushes.Black;
        }
        void drawLabels()
        {
            List<Label> lblList = new List<Label>();
            List<SolidColorBrush> colorList = getColorList();
            int numberOfLines = 3;
            int lineChange = colorList.Count / numberOfLines;
            this.Width = lineChange * 25;
            this.Height = numberOfLines * 25 + 20;
            this.HorizontalAlignment = HorizontalAlignment.Left;
            this.VerticalAlignment = VerticalAlignment.Top;
            int i = 0;
            int marginTop = 5;
            foreach (SolidColorBrush color in colorList)
            {
                Label lbl = new Label();
                lbl.Width = 20;
                lbl.Height = 20;
                lbl.Margin = new Thickness(i * 22, marginTop, 0, 0);
                lbl.Background = color;
                lbl.HorizontalAlignment = HorizontalAlignment.Left;
                lbl.VerticalAlignment = VerticalAlignment.Top;
                lbl.BorderThickness = new Thickness(1);
                lbl.BorderBrush = Brushes.Black;
                lbl.Tag = color;
                lbl.MouseDown += new MouseButtonEventHandler(OnColorLblClick);
                this.Children.Add(lbl);
                i++;
                if (i % lineChange == 0)
                {
                    marginTop += 22;
                    i = 0;
                }
            }
            
        }
        List<SolidColorBrush> getColorList()
        {
            List<SolidColorBrush> colorList = new List<SolidColorBrush>();
            colorList.Add(Brushes.Black);
            colorList.Add(Brushes.Blue);
            colorList.Add(Brushes.DarkBlue);
            colorList.Add(Brushes.Green);
            colorList.Add(Brushes.DarkGreen);
            colorList.Add(Brushes.Cyan);
            colorList.Add(Brushes.DarkCyan);
            colorList.Add(Brushes.Red);
            colorList.Add(Brushes.DarkRed);
            colorList.Add(Brushes.Magenta);
            colorList.Add(Brushes.DarkMagenta);
            colorList.Add(Brushes.Yellow);
            colorList.Add(Brushes.Gray);
            colorList.Add(Brushes.DarkGray);
            colorList.Add(Brushes.White);
            return colorList;
        }
        void OnColorLblClick(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            // i chose to set the color in the tag instead of just using the background Property so it should be easier to convert to console colors
            animationControls.currentColor = (SolidColorBrush)lbl.Tag;
        }
    }

}
