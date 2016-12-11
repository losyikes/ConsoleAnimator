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
    public class AnimationGrid : Grid
    {
        private static Action EmptyDelegate = delegate () { };
        AnimationControls animationControls;
        public int CharacterWidth { get; }
        public int CharacterHeight { get; }
        public AnimationGrid(int charWidth, int charHeight, AnimationControls aControls)
        {
            animationControls = aControls;
            
            this.CharacterWidth = charWidth;
            this.CharacterHeight = charHeight;
            this.Width = (charWidth * 22);
            this.Height = (charHeight * 22);
            
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
                    lbl.Background = Brushes.Black;
                    lbl.Width = 20;
                    lbl.Height = 20;
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
        public List<Pixel> GetPixelList()
        {
            List<Pixel> pixelList = new List<Pixel>();
            int i = 0;
            int y = 1;
            foreach(Label lbl in this.Children)
            {
                i++;
                int x = i;
                Pixel pixel = new Pixel(x, y,(SolidColorBrush)lbl.Background);
                pixelList.Add(pixel);
                if(i == this.CharacterWidth)
                {
                    i = 0;
                    y++;
                }
            }
            return pixelList;
        }
        public void LoadThumbToGrid(Thumbnail thumb)
        {
            
            this.Children.Clear();
            int lblCounter = 0;
            int marginLeft = 0;
            int marginTop = 0;
            int gridWidth = Convert.ToInt32(thumb.Width / 4);
            foreach(Pixel pixel in thumb.PixelList)
            {
                lblCounter++;

                Label lbl = new Label();
                lbl.Background = pixel.Color;
                lbl.Width = 20;
                lbl.Height = 20;
                lbl.HorizontalAlignment = HorizontalAlignment.Left;
                lbl.VerticalAlignment = VerticalAlignment.Top;
                lbl.HorizontalContentAlignment = HorizontalAlignment.Center;
                lbl.VerticalContentAlignment = VerticalAlignment.Center;
                lbl.Margin = new Thickness(marginLeft, marginTop, 0, 0);
                lbl.BorderThickness = new Thickness(1);
                lbl.BorderBrush = Brushes.Black;
                lbl.MouseDown += new MouseButtonEventHandler(OnAnimationLblMouseDown);
                this.Children.Add(lbl);
                marginLeft += 22;
                if(lblCounter % gridWidth == 0)
                {
                    marginTop += 22;
                    marginLeft = 0;
                }
            }
            
        }
        void OnAnimationLblMouseDown(object sender, MouseButtonEventArgs e)
        {
            Label senderLbl = (Label)sender;
            senderLbl.Background = animationControls.currentColor;
            senderLbl.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
        }
        public void ClearGrid()
        {
            foreach(Label lbl in this.Children)
            {
                lbl.Background = Brushes.Black;
            }
            this.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
        }
    }
}
