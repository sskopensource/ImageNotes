using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace ControlPanel
{
    public class ControlPanelView:Canvas
    {
        private TextBox m_txtBox;
        private ControlPanelModel m_model;
        private bool m_changed;

        public ControlPanelView(MainGrid parent, ControlPanelModel model)
        {
            m_model = model;
            m_changed = true;
            this.Background = Brushes.Black;
            parent.Children.Add(this);
            parent.SetControlPanel(this);
            m_txtBox = new TextBox();
            m_txtBox.Text = "";
            m_txtBox.Height = 30;
            m_txtBox.FontSize = 20;
            m_txtBox.VerticalContentAlignment = VerticalAlignment.Center;
            m_txtBox.HorizontalAlignment = HorizontalAlignment.Right;
            this.Children.Add(m_txtBox);
            m_txtBox.TextChanged += OnTextBoxTextChanged;
            Thickness margin = new Thickness() { Left = 5, Top=5,Bottom=5, Right=5 };
            m_txtBox.Margin = margin;
            m_txtBox.Width = 275;
        }

        private void OnTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            //Post Event
            if (m_changed)
            {
                LabellingResources.ActiveLabel.SetActiveLabelText(m_txtBox.Text);
            }
            m_changed = true;
        }

        public void RefreshControl()
        {
            m_changed = false;
            if (!this.Dispatcher.CheckAccess())
            {
                //If not in UI Thread
                this.Dispatcher.Invoke(() =>
                {
                    m_txtBox.Text = m_model.GetTextBoxText();
                    m_txtBox.CaretIndex = m_model.GetTextBoxText().Length;
                });
            }
            else
            {
                //If UI Thread
                m_txtBox.Text = m_model.GetTextBoxText();
                m_txtBox.CaretIndex = m_model.GetTextBoxText().Length;
            }
        }
    }

}
