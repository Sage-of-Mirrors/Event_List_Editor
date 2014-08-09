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
    public partial class ActionControl : UserControl
    {
        MainUI form;

        public ActionControl(MainUI form1)
        {
            InitializeComponent();

            form = form1;
        }

        public void loadActionUI(actionClass acnClass)
        {
            clearActionUI();

            actionNameBox.Text = acnClass.name;
            dupIDBox.Text = acnClass.uniqueID.ToString();
            array1Box.Text = acnClass.unknownAry1[0].ToString();
            array2Box.Text = acnClass.unknownAry1[1].ToString();
            array3Box.Text = acnClass.unknownAry1[2].ToString();
            unknown5Box.Text = acnClass.unknown5.ToString();
        }

        public void clearActionUI()
        {
            actionNameBox.Clear();
            dupIDBox.Clear();
            array1Box.Clear();
            array2Box.Clear();
            array3Box.Clear();
            unknown5Box.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form.updateActionData(actionNameBox.Text, Convert.ToInt32(dupIDBox.Text), Convert.ToInt32(array1Box.Text),
                Convert.ToInt32(array2Box.Text), Convert.ToInt32(array3Box.Text), Convert.ToInt32(unknown5Box.Text));
        }
    }
}
