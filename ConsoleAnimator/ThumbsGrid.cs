using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace ConsoleAnimator
{
    class ThumbsGrid : Grid
    {
        private static Action EmptyDelegate = delegate () { };
        AnimationControls animationControls;
        public List<Thumbnail> thumbnailList = new List<Thumbnail>();
        public ThumbsGrid(AnimationControls aControls)
        {
            
            this.animationControls = aControls;
            this.Width = aControls.AnimationGrid.CharacterWidth*4 + 20;
            this.HorizontalAlignment = HorizontalAlignment.Left;
            this.VerticalAlignment = VerticalAlignment.Top;

            

        }
        public void AddThumbnailToGrid()
        {
            Thumbnail thumb = new Thumbnail(animationControls.AnimationGrid.GetPixelList(), animationControls);
            thumbnailList.Add(thumb);
            this.Dispatcher.Invoke(new Action(() => this.Children.Add(thumb)), DispatcherPriority.Render);
            //this.Children.Add(thumb);
        }
        
        
    }
}
