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
        public AnimationUC()
        {
            InitializeComponent();
        }
        public AnimationUC(int width, int height)
        {
            InitializeComponent();
            AnimationControls animationControl = new AnimationControls(width, height, this);
            this.Width = animationControl.ControlWidth;
            this.Height = animationControl.ControlHeight;
            Application.Current.MainWindow.Height = animationControl.ControlHeight + 20;
            Application.Current.MainWindow.Width = animationControl.ControlWidth + 20;
            
        }
    }
}
