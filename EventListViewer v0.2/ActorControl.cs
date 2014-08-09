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
    public partial class ActorControl : UserControl
    {
        MainUI form;

        public ActorControl(MainUI form1)
        {
            InitializeComponent();

            form = form1;
        }

        public void loadActorUI(actorClass act)
        {
            clearUI();

            actorNameBox.Text = act.name;
            staffIDBox.Text = act.staffIdentifer.ToString();
            unknown1Box.Text = act.unknown1.ToString();
            staffTypeBox.Text = act.staffType.ToString();
        }

        public void clearUI()
        {
            actorNameBox.Clear();
            staffIDBox.Clear();
            unknown1Box.Clear();
            staffTypeBox.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form.updateActorData(actorNameBox.Text, Convert.ToInt32(staffIDBox.Text), Convert.ToInt32(unknown1Box.Text),
                Convert.ToInt32(staffTypeBox.Text));
        }
    }
}
