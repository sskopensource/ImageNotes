using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ImageLabellingArea
{
    public enum LabelState
    {
        Select,
        Anchor,
        Drag,
        Move
    }
    public class ImageLabel:TextBox
    {
        ImageLabellingRegion _parent;
        public ImageLabel(ImageLabellingRegion parent)
        {
            this.Height = 40;
            this.MinWidth = 20;
            this.Height = 40;
            this.CaretBrush = Brushes.Black;
            this.FontSize = 30;
            Thickness x = new Thickness() { Left = 20, Top = 20 };
            this.Margin = x;
            Thickness borderThickness = new Thickness() { Bottom = 2, Left = 2, Right = 2, Top = 2 };
            this.BorderThickness = borderThickness;
            BrushConverter bc = new BrushConverter();
            Brush brush = (Brush)bc.ConvertFrom("#569be5");
            brush.Freeze();
            this.BorderBrush = brush;

            this.Background = Brushes.Transparent;
            this.Foreground = Brushes.Black;
            this.PreviewMouseDoubleClick += Selected;
            parent.PreviewMouseDown += Anchored;
            this.Select(0, 0);
            _parent = parent;
            _parent.labelState = LabelState.Drag;
        }

        private void Anchored(object sender, MouseButtonEventArgs e)
        {
            if (this.Text.Length==0 || _parent.labelState!=LabelState.Select) 
            {
                return;
            }
            _parent.labelState = LabelState.Anchor;
            Thickness borderThickness = new Thickness() { Bottom = 0, Left = 0, Right = 0, Top = 0 };
            this.BorderThickness = borderThickness;
            Keyboard.ClearFocus();
        }

        private void Selected(object sender, MouseButtonEventArgs e)
        {
            _parent.labelState = LabelState.Select;
            Thickness borderThickness = new Thickness() { Bottom = 2, Left = 2, Right = 2, Top = 2 };
            this.BorderThickness = borderThickness;
        }
    }
}
