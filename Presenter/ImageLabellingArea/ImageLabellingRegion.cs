using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ImageLabellingArea
{
    public class ImageLabellingRegion:Canvas
    {
        private ImageLabel label;
        private UIElement dragObject =null;
        public LabelState labelState;
        private Point pt;

        public ImageLabellingRegion(MainGrid parent)
        {
            label = new ImageLabel(this);
            this.Background = System.Windows.Media.Brushes.White;
            this.Children.Add(label);
            parent.Children.Add(this);
            parent.SetLabelRegion(this);
            SetCursorDefaultPosition();
            label.PreviewMouseDown += Drag;
            this.PreviewMouseMove += Move;
            this.PreviewMouseUp += Release;
        }

        private void SetCursorDefaultPosition()
        {
            SetTop(label, 0);
            SetTop(label, 0);
        }
        private void Release(object sender, MouseButtonEventArgs e)
        {
            this.dragObject = null;
            this.ReleaseMouseCapture();
        }

        private void Move(object sender, MouseEventArgs e)
        {
            if (labelState == LabelState.Select)
            {
                return;
            }
            if (dragObject == null)
            {
                return;
            }
            var position = e.GetPosition(sender as IInputElement );
            SetTop(this.dragObject,position.Y-40);
            SetLeft(this.dragObject, position.X-pt.X-20);
        }

        private void Drag(object sender, MouseButtonEventArgs e)
        {
            if (labelState == LabelState.Select)
            {
                return;
            }
            pt.X = e.GetPosition(label).X;
            this.dragObject = sender as UIElement;
            this.CaptureMouse();
        }
    }
}
