using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace ConsoleAnimator
{
    /// <summary>
    /// Interaction logic for AnimationUC.xaml
    /// </summary>
    public partial class AnimationUC : UserControl
    {
        delegate void LayoutUpdate();
        public AnimationUC()
        {
            //InitializeComponent();
            InitializeComponent();
            AnimationControls animationControl = new AnimationControls(20, 20, this);
            
            this.Width = animationControl.ControlWidth;
            this.Height = animationControl.ControlHeight;
            Grid animationControlGrid = animationControl.DrawGrid();
            Application.Current.MainWindow.Height = animationControl.ControlHeight + 20;
            Application.Current.MainWindow.Width = animationControl.ControlWidth + 20;
            
            
        }
        public AnimationUC(int width, int height)
        {
            InitializeComponent();
            AnimationControls animationControl = new AnimationControls(width, height, this);

            this.Width = animationControl.ControlWidth;
            this.Height = animationControl.ControlHeight;
            Grid animationControlGrid = animationControl.DrawGrid();
            Application.Current.MainWindow.Height = animationControl.ControlHeight + 20;
            Application.Current.MainWindow.Width = animationControl.ControlWidth + 20;
            //AnimationControls animationControl = new AnimationControls(width,height, this);
            //InitializeComponent();
            //this.Width = animationControl.ControlWidth;
            //this.Height = animationControl.ControlHeight;
            ////AnimationUCContentGrid.Children.Add(animationControl.DrawGrid());
            //Grid animationControlGrid = animationControl.DrawGrid();
            //Application.Current.MainWindow.Height = animationControl.ControlWidth + 20;
            //Application.Current.MainWindow.Width = animationControl.ControlHeight + 20;
            ////LayoutUpdate updateLayout = () => this.AnimationUCContentGrid.UpdateLayout();
            //this.Dispatcher.Invoke(new Action(() => AnimationUCContentGrid.Children.Add(animationControlGrid)),  DispatcherPriority.Render);
            //bool visibility = this.AnimationUCContentGrid.IsVisible;
        }
    }
}
