namespace WindowsFormsApplication1
{
    partial class ActionControl
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
            this.actionNameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dupIDBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.array1Box = new System.Windows.Forms.TextBox();
            this.array2Box = new System.Windows.Forms.TextBox();
            this.array3Box = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.unknown5Box = new System.Windows.Forms.TextBox();
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
            // actionNameBox
            // 
            this.actionNameBox.Location = new System.Drawing.Point(47, 10);
            this.actionNameBox.Name = "actionNameBox";
            this.actionNameBox.Size = new System.Drawing.Size(100, 20);
            this.actionNameBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Duplicate ID:";
            // 
            // dupIDBox
            // 
            this.dupIDBox.Location = new System.Drawing.Point(78, 39);
            this.dupIDBox.Name = "dupIDBox";
            this.dupIDBox.Size = new System.Drawing.Size(69, 20);
            this.dupIDBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Flags:";
            // 
            // array1Box
            // 
            this.array1Box.Location = new System.Drawing.Point(83, 70);
            this.array1Box.Name = "array1Box";
            this.array1Box.Size = new System.Drawing.Size(64, 20);
            this.array1Box.TabIndex = 5;
            // 
            // array2Box
            // 
            this.array2Box.Location = new System.Drawing.Point(153, 70);
            this.array2Box.Name = "array2Box";
            this.array2Box.Size = new System.Drawing.Size(64, 20);
            this.array2Box.TabIndex = 6;
            // 
            // array3Box
            // 
            this.array3Box.Location = new System.Drawing.Point(83, 96);
            this.array3Box.Name = "array3Box";
            this.array3Box.Size = new System.Drawing.Size(64, 20);
            this.array3Box.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Flag ID:";
            // 
            // unknown5Box
            // 
            this.unknown5Box.Location = new System.Drawing.Point(71, 125);
            this.unknown5Box.Name = "unknown5Box";
            this.unknown5Box.Size = new System.Drawing.Size(100, 20);
            this.unknown5Box.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 185);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ActionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.unknown5Box);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.array3Box);
            this.Controls.Add(this.array2Box);
            this.Controls.Add(this.array1Box);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dupIDBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.actionNameBox);
            this.Controls.Add(this.label1);
            this.Name = "ActionControl";
            this.Size = new System.Drawing.Size(274, 222);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox actionNameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox dupIDBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox array1Box;
        private System.Windows.Forms.TextBox array2Box;
        private System.Windows.Forms.TextBox array3Box;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox unknown5Box;
        private System.Windows.Forms.Button button1;
    }
}
