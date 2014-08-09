namespace WindowsFormsApplication1
{
    partial class ActorControl
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
            this.actorNameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.staffIDBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.unknown1Box = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.staffTypeBox = new System.Windows.Forms.TextBox();
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
            // actorNameBox
            // 
            this.actorNameBox.Location = new System.Drawing.Point(47, 10);
            this.actorNameBox.Name = "actorNameBox";
            this.actorNameBox.Size = new System.Drawing.Size(193, 20);
            this.actorNameBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Staff Identifier:";
            // 
            // staffIDBox
            // 
            this.staffIDBox.Location = new System.Drawing.Point(84, 42);
            this.staffIDBox.Name = "staffIDBox";
            this.staffIDBox.Size = new System.Drawing.Size(51, 20);
            this.staffIDBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Flag ID:";
            // 
            // unknown1Box
            // 
            this.unknown1Box.Location = new System.Drawing.Point(71, 74);
            this.unknown1Box.Name = "unknown1Box";
            this.unknown1Box.Size = new System.Drawing.Size(64, 20);
            this.unknown1Box.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Staff Type:";
            // 
            // staffTypeBox
            // 
            this.staffTypeBox.Location = new System.Drawing.Point(68, 106);
            this.staffTypeBox.Name = "staffTypeBox";
            this.staffTypeBox.Size = new System.Drawing.Size(67, 20);
            this.staffTypeBox.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 185);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ActorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.staffTypeBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.unknown1Box);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.staffIDBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.actorNameBox);
            this.Controls.Add(this.label1);
            this.Name = "ActorControl";
            this.Size = new System.Drawing.Size(274, 222);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox actorNameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox staffIDBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox unknown1Box;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox staffTypeBox;
        private System.Windows.Forms.Button button1;
    }
}
