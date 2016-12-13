using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Windows.Input;
using System.Windows.Media;

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
        public Frame GetFrame(AnimationGrid aGrid)
        {
            List<Pixel> pixelList = new List<Pixel>();
            int i = 0;
            int y = 1;
            foreach (Label lbl in this.Children)
            {
                i++;
                int x = i;
                Pixel pixel = new Pixel(x, y, (SolidColorBrush)lbl.Background);
                pixelList.Add(pixel);
                if (i == aGrid.CharacterWidth)
                {
                    i = 0;
                    y++;
                }
            }
            Frame frame = new ConsoleAnimator.Frame(pixelList);
            return frame;
        }
        public void AddThumbnailToGrid()
        {
            Thumbnail thumb = new Thumbnail(this.GetFrame(animationControls.AnimationGrid), animationControls);
            thumb.MouseDown += new MouseButtonEventHandler(LoadThumbnailToAnimationGrid);
            thumbnailList.Add(thumb);
            this.Dispatcher.Invoke(new Action(() => this.Children.Add(thumb)), DispatcherPriority.Render);
        }
        public void AddThumbnailToGrid(Thumbnail thumb)
        {
            Thumbnail completeThumb = new Thumbnail(thumb.PixelList, animationControls);
            completeThumb.MouseDown += new MouseButtonEventHandler(LoadThumbnailToAnimationGrid);
            thumbnailList.Add(completeThumb);
            this.Dispatcher.Invoke(new Action(() => this.Children.Add(completeThumb)), DispatcherPriority.Render);
        }
        public void AddThumbnailListToGrid(List<Thumbnail> thumbList)
        {
            this.Children.Clear();
            thumbnailList = new List<Thumbnail>();
            foreach(Thumbnail thumb in thumbList)
            {
                AddThumbnailToGrid(thumb);
            }
        }
        private void LoadThumbnailToAnimationGrid(object sender, MouseButtonEventArgs e)
        {
            Thumbnail thumb = (Thumbnail)sender;
            animationControls.AnimationGrid.LoadThumbToGrid(thumb);
        }
    }
}
