using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenTK;

namespace WindowsFormsApplication1
{
    public partial class PropertyControl : UserControl
    {
        MainUI form;

        public PropertyControl(MainUI form1)
        {
            InitializeComponent();

            form = form1;
        }

        public void loadPropUI(propertyClass propClass)
        {
            clearUI();

            nameBox.Text = propClass.name;

            switch (propClass.dataType)
            {
                case 0:
                    typeCombo.SelectedIndex = 0;

                    dataBox.Text = propClass.propData.ToString();

                    break;
                case 1:
                    typeCombo.SelectedIndex = 1;

                    dataBox.Text = propClass.propData.ToString();

                    break;
                case 3:
                    typeCombo.SelectedIndex = 2;

                    dataBox.Text = propClass.propData.ToString();

                    break;
                case 4:
                    typeCombo.SelectedIndex = 3;

                    dataBox.Text = propClass.propData;

                    break;
                default:
                    MessageBox.Show("Something wicked this way comes");
                    break;
            }
        }

        public void clearUI()
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int correctDataType = 0;

            switch (typeCombo.SelectedIndex)
            {
                case 0:
                    correctDataType = 0;
                    break;
                case 1:
                    correctDataType = 1;
                    break;
                case 2:
                    correctDataType = 3;
                    break;
                case 3:
                    correctDataType = 4;
                    break;
            }

            form.updatePropData(nameBox.Text, correctDataType, dataBox.Text);
        }

        private void keyCheck(KeyEventArgs keyArgs)
        {
            switch (typeCombo.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    if ((keyArgs.KeyCode >= Keys.D0 && keyArgs.KeyCode <= Keys.D9) || 
                        (keyArgs.KeyCode >= Keys.NumPad0 && keyArgs.KeyCode <= Keys.NumPad9))
                    {
                    }
                    break;
                case 3:
                    break;
            }
        }

        private void dataBox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            switch (typeCombo.SelectedIndex)
            {
                case 0:

                    e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

                    if ((e.KeyChar == '-') || (e.KeyChar == '.'))
                    {
                        e.Handled = false;
                    }

                    break;
                case 1:

                    e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

                    if ((e.KeyChar == '-') || (e.KeyChar == '.') || (e.KeyChar == '(') || (e.KeyChar == ')') || (e.KeyChar == ','))
                    {
                        e.Handled = false;
                    }

                    break;
                case 2:
                    e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
                    break;
                case 3:
                    break;
            }
        }
    }
}
