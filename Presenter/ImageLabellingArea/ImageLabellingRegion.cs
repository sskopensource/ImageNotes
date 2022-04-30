using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using UiEnums;

namespace ImageLabellingArea
{

    public class ImageLabellingRegion:Canvas
    {
        private ImageLabelControl labelControl;
        private UIElement dragObject =null;
        public UiEnums.LabelState labelState;
        private Point pt;

        public ImageLabellingRegion(MainGrid parent)
        {
            labelControl = new ImageLabelControl(this);
            this.Background = System.Windows.Media.Brushes.White;
            this.Children.Add(labelControl.GetView());
            parent.Children.Add(this);
            parent.SetLabelRegion(this);
            SetCursorDefaultPosition();
            labelControl.GetView().PreviewMouseDown += Drag;
            this.PreviewMouseMove += Move;
            this.PreviewMouseUp += Release;
        }

        private void SetCursorDefaultPosition()
        {
            SetTop(labelControl.GetView(), 0);
            SetTop(labelControl.GetView(), 0);
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
            pt.X = e.GetPosition(labelControl.GetView()).X;
            this.dragObject = sender as UIElement;
            this.CaptureMouse();
        }
    }
}
