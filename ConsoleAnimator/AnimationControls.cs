using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Drawing;
using System.Windows.Media;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using System.Threading;
using System.ComponentModel;
using System.Windows.Data;
using System.Runtime.CompilerServices;

namespace ConsoleAnimator
{

    class AnimationControls 
    {
        delegate void LayoutUpdate();
        public static int w {get;set;}
        public static int h { get; set; }
        SolidColorBrush currentColor;
        AnimationUC uCControl;
        Grid animationGrid;
        private static Action EmptyDelegate = delegate () { };
        public AnimationControls(int charWidth, int charHeight, AnimationUC UCcontrol)
        {
            uCControl = UCcontrol;
            animationGridCharWidth = charWidth;
            animationGridCharHeight = charHeight;
            animationGrid = DrawGrid();
            animationGrid.Background = Brushes.Gray;
            UCcontrol.Dispatcher.Invoke(new Action(() => UCcontrol.AnimationUCContentGrid.Children.Add(animationGrid)), DispatcherPriority.Render);
            
        }
        public int GridWidth { get; }
        public int GridHeight { get; }
        public int ControlWidth { get; set; }
        public int ControlHeight { get; set; }
        int animationGridCharWidth;
        int animationGridCharHeight;
        
        public Grid DrawGrid()
        {
            Grid grid = new Grid();
            animationGrid = GetAnimationGrid();
            Grid colorControlGrid = GetColorControlGrid();
            colorControlGrid.Margin = new Thickness(5, 5, 0, 0);
            animationGrid.Margin = new Thickness(5, (colorControlGrid.Height + 5 + 15), 0, 0);
            ControlHeight = Convert.ToInt32(animationGrid.Height + colorControlGrid.Height + 20);
            ControlWidth = Convert.ToInt32(animationGrid.Width + 20);
            grid.Height = ControlHeight;
            grid.Width = ControlWidth;
            grid.HorizontalAlignment = HorizontalAlignment.Left;
            grid.VerticalAlignment = VerticalAlignment.Top;
            grid.Children.Add(colorControlGrid);
            grid.Children.Add(animationGrid);
            return grid;
        }
        Grid GetAnimationGrid()
        {
            Grid grid = new Grid();
            grid.Width = (animationGridCharWidth * 25);
            grid.Height = (animationGridCharHeight * 23);
            grid.HorizontalAlignment = HorizontalAlignment.Left;
            grid.VerticalAlignment = VerticalAlignment.Top;
            int lblNameCounter = 0;
            int marginLeft = 0;
            int marginTop = 0;
            for (int i = 0; i < animationGridCharWidth; i++)
            {
                marginLeft = 0;
                for (int j = 0; j < animationGridCharHeight; j++)
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
                    grid.Children.Add(lbl);
                    marginLeft += 22;
                }
                marginTop += 22;
            }
            
            return grid;
        }

        void OnAnimationLblMouseDown(object sender, MouseButtonEventArgs e)
        {
            Label senderLbl = (Label)sender;
            senderLbl.Background = currentColor;
            senderLbl.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
            
        }
        
        public Grid GetColorControlGrid()
        {
            Grid grid = new Grid();
            List <SolidColorBrush> colorList = getColorList();
            int lineChange = colorList.Count / 3;
            int i = 0;
            int marginTop = 5;
            foreach (SolidColorBrush color in colorList)
            {
                Label lbl = new Label();
                lbl.Width = 20;
                lbl.Height = 20;
                lbl.Margin = new Thickness(i * 25, marginTop,0,0);
                lbl.Background = color;
                lbl.HorizontalAlignment = HorizontalAlignment.Left;
                lbl.VerticalAlignment = VerticalAlignment.Top;
                lbl.BorderThickness = new Thickness(1);
                lbl.BorderThickness = new Thickness(1);
                lbl.BorderBrush = Brushes.Black;
                lbl.Tag = color;
                lbl.MouseDown += new MouseButtonEventHandler(OnColorLblClick);
                grid.Children.Add(lbl);
                i++;
                if (i % lineChange == 0)
                {
                    marginTop += 25;
                    i = 0;
                }
            }
            grid.Width = lineChange * 25;
            grid.Height = 75;
            grid.HorizontalAlignment = HorizontalAlignment.Left;
            grid.VerticalAlignment = VerticalAlignment.Top;
            return grid;
        }

        void OnColorLblClick(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            // i chose to set the color in the tag instead of just using the background Property so it should be easier to convert to console colors
            currentColor = (SolidColorBrush)lbl.Tag;
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
        
    }
}
