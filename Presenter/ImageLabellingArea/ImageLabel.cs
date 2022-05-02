using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using UiEnums;

namespace ImageLabellingArea
{
    public class ImageLabel:TextBox
    {
        private ImageLabellingRegion m_parent;
        private ImageLabelModel m_model;

        public ImageLabel(ImageLabellingRegion parent, ImageLabelModel model)
        {
            m_model = model;
            Height = 40;
            MinWidth = 20;
            Height = 40;
            CaretBrush = Brushes.Black;
            FontSize = 30;
            Thickness x = new Thickness() { Left = 20, Top = 20 };
            Margin = x;
            Thickness borderThickness = new Thickness() { Bottom = 2, Left = 2, Right = 2, Top = 2 };
            BorderThickness = borderThickness;
            BrushConverter bc = new BrushConverter();
            Brush brush = (Brush)bc.ConvertFrom("#569be5");
            brush.Freeze();
            BorderBrush = brush;

            Background = Brushes.Transparent;
            Foreground = Brushes.Black;
            PreviewMouseDoubleClick += Selected;
            parent.PreviewMouseDown += Anchored;
            Select(0, 0);
            TextChanged += OnTextBoxTextChanged;
            m_parent = parent;
            m_parent.labelState = LabelState.Drag;
        }

        public void RefreshLabel()
        {
            if (!this.Dispatcher.CheckAccess())
            {
                //If not in UI Thread
                this.Dispatcher.Invoke(() =>
                {
                    Text = m_model.GetLabelText();
                    CaretIndex = m_model.GetLabelText().Length;
                });
            }
            else
            {
                //If UI Thread
                Text = m_model.GetLabelText();
                CaretIndex = m_model.GetLabelText().Length;
            }
        }

        private void OnTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            //Post Event
            LabellingResources.ActiveLabel.SetActiveLabelText(Text);
        }

        private void Anchored(object sender, MouseButtonEventArgs e)
        {
            if (Text.Length==0 || m_parent.labelState!=LabelState.Select) 
            {
                return;
            }
            m_parent.labelState = LabelState.Anchor;
            Thickness borderThickness = new Thickness() { Bottom = 0, Left = 0, Right = 0, Top = 0 };
            BorderThickness = borderThickness;
            Keyboard.ClearFocus();
        }

        private void Selected(object sender, MouseButtonEventArgs e)
        {
            m_parent.labelState = LabelState.Select;
            Thickness borderThickness = new Thickness() { Bottom = 2, Left = 2, Right = 2, Top = 2 };
            BorderThickness = borderThickness;
        }
    }
}
