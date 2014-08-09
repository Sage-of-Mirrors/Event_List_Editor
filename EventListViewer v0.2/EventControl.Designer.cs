namespace WindowsFormsApplication1
{
    partial class EventControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.eventNameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.eventPriorityBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.flag1Box = new System.Windows.Forms.TextBox();
            this.flag2Box = new System.Windows.Forms.TextBox();
            this.flag4Box = new System.Windows.Forms.TextBox();
            this.flag3Box = new System.Windows.Forms.TextBox();
            this.flag5Box = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.jingleComboBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // eventNameBox
            // 
            this.eventNameBox.Location = new System.Drawing.Point(47, 10);
            this.eventNameBox.Name = "eventNameBox";
            this.eventNameBox.Size = new System.Drawing.Size(224, 20);
            this.eventNameBox.TabIndex = 1;
            this.eventNameBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.eventNameBox_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Priority:";
            // 
            // eventPriorityBox
            // 
            this.eventPriorityBox.Location = new System.Drawing.Point(47, 42);
            this.eventPriorityBox.Name = "eventPriorityBox";
            this.eventPriorityBox.Size = new System.Drawing.Size(100, 20);
            this.eventPriorityBox.TabIndex = 3;
            this.eventPriorityBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.eventPriorityBox_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Flags:";
            // 
            // flag1Box
            // 
            this.flag1Box.Location = new System.Drawing.Point(47, 74);
            this.flag1Box.Name = "flag1Box";
            this.flag1Box.Size = new System.Drawing.Size(47, 20);
            this.flag1Box.TabIndex = 5;
            this.flag1Box.KeyDown += new System.Windows.Forms.KeyEventHandler(this.flag1Box_KeyDown);
            // 
            // flag2Box
            // 
            this.flag2Box.Location = new System.Drawing.Point(100, 74);
            this.flag2Box.Name = "flag2Box";
            this.flag2Box.Size = new System.Drawing.Size(47, 20);
            this.flag2Box.TabIndex = 6;
            this.flag2Box.KeyDown += new System.Windows.Forms.KeyEventHandler(this.flag2Box_KeyDown);
            // 
            // flag4Box
            // 
            this.flag4Box.Location = new System.Drawing.Point(100, 100);
            this.flag4Box.Name = "flag4Box";
            this.flag4Box.Size = new System.Drawing.Size(47, 20);
            this.flag4Box.TabIndex = 8;
            this.flag4Box.KeyDown += new System.Windows.Forms.KeyEventHandler(this.flag4Box_KeyDown);
            // 
            // flag3Box
            // 
            this.flag3Box.Location = new System.Drawing.Point(47, 100);
            this.flag3Box.Name = "flag3Box";
            this.flag3Box.Size = new System.Drawing.Size(47, 20);
            this.flag3Box.TabIndex = 7;
            this.flag3Box.KeyDown += new System.Windows.Forms.KeyEventHandler(this.flag3Box_KeyDown);
            // 
            // flag5Box
            // 
            this.flag5Box.Location = new System.Drawing.Point(47, 126);
            this.flag5Box.Name = "flag5Box";
            this.flag5Box.Size = new System.Drawing.Size(47, 20);
            this.flag5Box.TabIndex = 9;
            this.flag5Box.KeyDown += new System.Windows.Forms.KeyEventHandler(this.flag5Box_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Play \"Puzzle Solved\" Jingle?";
            // 
            // jingleComboBox
            // 
            this.jingleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.jingleComboBox.FormattingEnabled = true;
            this.jingleComboBox.Items.AddRange(new object[] {
            "No",
            "Yes"});
            this.jingleComboBox.Location = new System.Drawing.Point(155, 154);
            this.jingleComboBox.Name = "jingleComboBox";
            this.jingleComboBox.Size = new System.Drawing.Size(63, 21);
            this.jingleComboBox.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 185);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // EventControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.jingleComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.flag5Box);
            this.Controls.Add(this.flag4Box);
            this.Controls.Add(this.flag3Box);
            this.Controls.Add(this.flag2Box);
            this.Controls.Add(this.flag1Box);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.eventPriorityBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.eventNameBox);
            this.Controls.Add(this.label1);
            this.Name = "EventControl";
            this.Size = new System.Drawing.Size(274, 222);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox eventNameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox eventPriorityBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox flag1Box;
        private System.Windows.Forms.TextBox flag2Box;
        private System.Windows.Forms.TextBox flag4Box;
        private System.Windows.Forms.TextBox flag3Box;
        private System.Windows.Forms.TextBox flag5Box;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox jingleComboBox;
        private System.Windows.Forms.Button button1;
    }
}
