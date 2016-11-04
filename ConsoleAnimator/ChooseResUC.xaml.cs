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

namespace ConsoleAnimator
{
    /// <summary>
    /// Interaction logic for ChooseResUC.xaml
    /// </summary>
    public partial class ChooseResUC : UserControl
    {
        delegate void LayoutUpdate();
        public ChooseResUC()
        {
            InitializeComponent();
        }
        private void CreateGridBtn_Click(object sender, RoutedEventArgs e)
        {
            int width;
            int height;
            WidthTbx.Text = "20";
            HeightTbx.Text = "20";
            if (int.TryParse(WidthTbx.Text, out width) && int.TryParse(HeightTbx.Text, out height))
            {
                
                Window main = Window.GetWindow(this);
                Grid parentGrid = (Grid)VisualTreeHelper.GetParent(this);
                this.Visibility = Visibility.Hidden;
                AnimationUC animationUC = new AnimationUC(width, height);
                animationUC.Visibility = Visibility.Visible;
                parentGrid.Children.Add(animationUC);
                LayoutUpdate updateLayout = () => parentGrid.UpdateLayout();


            }
            else
                MessageBox.Show("Invalid input please check if your Width and Height are valid numbers");
        }
        
    }
}
