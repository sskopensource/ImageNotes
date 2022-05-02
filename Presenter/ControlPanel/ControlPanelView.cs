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
    public class ControlPanelView:StackPanel
    {
        private TextBox m_txtBox;
        private ControlPanelModel m_model;

        public ControlPanelView(MainGrid parent, ControlPanelModel model)
        {
            m_model = model;
            this.Background = Brushes.Black;
            parent.Children.Add(this);
            parent.SetControlPanel(this);
            m_txtBox = new TextBox();
            m_txtBox.Text = "";
            m_txtBox.Height = 30;
            m_txtBox.FontSize = 20;
            m_txtBox.VerticalContentAlignment = VerticalAlignment.Center;
            this.Children.Add(m_txtBox);
            m_txtBox.TextChanged += OnTextBoxTextChanged;
            Thickness margin = new Thickness() { Left = 5, Top=5,Bottom=5, Right=5 };
            m_txtBox.Margin = margin;
        }

        private void OnTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            //Post Event
            LabellingResources.ActiveLabel.SetActiveLabelText(m_txtBox.Text);
        }

        public void RefreshControl()
        {
         //   m_changed = false;
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
