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
        public SolidColorBrush currentColor { get; set; }
        public ColorGrid ChooseColorGrid { get; }
        public AnimationGrid AnimationGrid { get; }
        
        public AnimationControls(int charWidth, int charHeight, AnimationUC UCcontrol)
        {
            Grid animationControlsgrid = new Grid();
            AnimationGrid animationGrid = new AnimationGrid(charWidth, charHeight, this);
            this.AnimationGrid = animationGrid;
            ColorGrid chooseColorGrid = new ColorGrid(this);
            this.ChooseColorGrid = chooseColorGrid;
            chooseColorGrid.Margin = new Thickness(5, 5, 0, 0);
            animationGrid.Margin = new Thickness(5, (chooseColorGrid.Height), 0, 0);
            ButtonGrid btnGrid = new ButtonGrid(this);
            btnGrid.Margin = new Thickness(animationGrid.Width, chooseColorGrid.Height, 0,0);

            ControlHeight = Convert.ToInt32(animationGrid.Height + chooseColorGrid.Height + 20);
            ControlWidth = Convert.ToInt32(animationGrid.Width + btnGrid.Width + 20);
            
            
            animationControlsgrid.Background = Brushes.Gray;
            animationControlsgrid.Height = ControlHeight;
            animationControlsgrid.Width = ControlWidth;
            animationControlsgrid.HorizontalAlignment = HorizontalAlignment.Left;
            animationControlsgrid.VerticalAlignment = VerticalAlignment.Top;
            animationControlsgrid.Children.Add(chooseColorGrid);
            animationControlsgrid.Children.Add(animationGrid);
            animationControlsgrid.Children.Add(btnGrid);
            UCcontrol.Dispatcher.Invoke(new Action(() => UCcontrol.AnimationUCContentGrid.Children.Add(animationControlsgrid)), DispatcherPriority.Render);
            
        }
        public int ControlWidth { get; set; }
        public int ControlHeight { get; set; }
    }
}
