using Newtonsoft.Json;
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
    public class ThumbsGrid : Grid
    {
        private static Action EmptyDelegate = delegate () { };
        AnimationControls animationControls;
        public List<Thumbnail> thumbnailList { get; set; }
        public ThumbsGrid(AnimationControls aControls)
        {
            thumbnailList = new List<Thumbnail>();
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
        }
        
        
    }
}
