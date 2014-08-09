using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class EventControl : UserControl
    {
        MainUI form;

        public EventControl(MainUI form1)
        {
            InitializeComponent();

            form = form1;
        }

        public void loadEventUI(eventClass evt)
        {
            clearEventUI();

            eventNameBox.Text = evt.eventName;

            eventPriorityBox.Text = evt.eventPriority.ToString();

            flag1Box.Text = evt.flags[0].ToString();
            flag2Box.Text = evt.flags[1].ToString();
            flag3Box.Text = evt.flags[2].ToString();
            flag4Box.Text = evt.flags[3].ToString();
            flag5Box.Text = evt.flags[4].ToString();

            jingleComboBox.SelectedIndex = evt.eventSound;
        }

        public void clearEventUI()
        {
            eventNameBox.Clear();
            eventPriorityBox.Clear();
            flag1Box.Clear();
            flag2Box.Clear();
            flag3Box.Clear();
            flag4Box.Clear();
            flag5Box.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form.updateEventData(eventNameBox.Text, Convert.ToInt32(eventPriorityBox.Text.ToString()),
                Convert.ToInt32(flag1Box.Text.ToString()), Convert.ToInt32(flag2Box.Text.ToString()),
                Convert.ToInt32(flag3Box.Text.ToString()), Convert.ToInt32(flag4Box.Text.ToString()),
                Convert.ToInt32(flag5Box.Text.ToString()), jingleComboBox.SelectedIndex);
        }

        private void eventNameBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                button1.PerformClick();

                e.SuppressKeyPress = true;
            }
        }

        private void eventPriorityBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                button1.PerformClick();

                e.SuppressKeyPress = true;
            }
        }

        private void flag1Box_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                button1.PerformClick();

                e.SuppressKeyPress = true;
            }
        }

        private void flag2Box_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                button1.PerformClick();

                e.SuppressKeyPress = true;
            }
        }

        private void flag3Box_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                button1.PerformClick();

                e.SuppressKeyPress = true;
            }
        }

        private void flag4Box_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                button1.PerformClick();

                e.SuppressKeyPress = true;
            }
        }

        private void flag5Box_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                button1.PerformClick();

                e.SuppressKeyPress = true;
            }
        }
    }
}
