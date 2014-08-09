namespace WindowsFormsApplication1
{
    partial class MainUI
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.controlPanel = new System.Windows.Forms.Panel();
            this.eventMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addActorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actorMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addActionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteActorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addPropertyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteActionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deletePropertyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.moveUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveUpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.moveDownToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.moveUpToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.moveDownToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.moveUpToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.moveDownToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.eventMenu.SuspendLayout();
            this.actorMenu.SuspendLayout();
            this.actionMenu.SuspendLayout();
            this.propMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.addEventToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(561, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.fileToolStripMenuItem.Text = "File...";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveAsToolStripMenuItem.Text = "Save as...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // addEventToolStripMenuItem
            // 
            this.addEventToolStripMenuItem.Name = "addEventToolStripMenuItem";
            this.addEventToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.addEventToolStripMenuItem.Text = "Add event";
            this.addEventToolStripMenuItem.Click += new System.EventHandler(this.addEventToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "Event_List.dat";
            this.openFileDialog1.Filter = "Event_List (*.dat)|*.dat";
            // 
            // treeView1
            // 
            this.treeView1.HideSelection = false;
            this.treeView1.Location = new System.Drawing.Point(13, 28);
            this.treeView1.Name = "treeView1";
            this.treeView1.ShowNodeToolTips = true;
            this.treeView1.Size = new System.Drawing.Size(259, 222);
            this.treeView1.TabIndex = 1;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // controlPanel
            // 
            this.controlPanel.Location = new System.Drawing.Point(287, 28);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(259, 222);
            this.controlPanel.TabIndex = 2;
            // 
            // eventMenu
            // 
            this.eventMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addActorToolStripMenuItem,
            this.deleteEventToolStripMenuItem,
            this.moveUpToolStripMenuItem,
            this.moveDownToolStripMenuItem});
            this.eventMenu.Name = "eventMenu";
            this.eventMenu.Size = new System.Drawing.Size(140, 92);
            // 
            // addActorToolStripMenuItem
            // 
            this.addActorToolStripMenuItem.Name = "addActorToolStripMenuItem";
            this.addActorToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.addActorToolStripMenuItem.Text = "Add actor";
            this.addActorToolStripMenuItem.Click += new System.EventHandler(this.addActorToolStripMenuItem_Click);
            // 
            // deleteEventToolStripMenuItem
            // 
            this.deleteEventToolStripMenuItem.Name = "deleteEventToolStripMenuItem";
            this.deleteEventToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.deleteEventToolStripMenuItem.Text = "Delete event";
            this.deleteEventToolStripMenuItem.Click += new System.EventHandler(this.deleteEventToolStripMenuItem_Click);
            // 
            // actorMenu
            // 
            this.actorMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addActionToolStripMenuItem,
            this.deleteActorToolStripMenuItem,
            this.moveUpToolStripMenuItem1,
            this.moveDownToolStripMenuItem1});
            this.actorMenu.Name = "actorMenu";
            this.actorMenu.Size = new System.Drawing.Size(138, 92);
            // 
            // addActionToolStripMenuItem
            // 
            this.addActionToolStripMenuItem.Name = "addActionToolStripMenuItem";
            this.addActionToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.addActionToolStripMenuItem.Text = "Add action";
            this.addActionToolStripMenuItem.Click += new System.EventHandler(this.addActionToolStripMenuItem_Click);
            // 
            // deleteActorToolStripMenuItem
            // 
            this.deleteActorToolStripMenuItem.Name = "deleteActorToolStripMenuItem";
            this.deleteActorToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.deleteActorToolStripMenuItem.Text = "Delete actor";
            this.deleteActorToolStripMenuItem.Click += new System.EventHandler(this.deleteActorToolStripMenuItem_Click);
            // 
            // actionMenu
            // 
            this.actionMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addPropertyToolStripMenuItem,
            this.deleteActionToolStripMenuItem,
            this.moveUpToolStripMenuItem2,
            this.moveDownToolStripMenuItem2});
            this.actionMenu.Name = "actionMenu";
            this.actionMenu.Size = new System.Drawing.Size(145, 92);
            // 
            // addPropertyToolStripMenuItem
            // 
            this.addPropertyToolStripMenuItem.Name = "addPropertyToolStripMenuItem";
            this.addPropertyToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.addPropertyToolStripMenuItem.Text = "Add property";
            this.addPropertyToolStripMenuItem.Click += new System.EventHandler(this.addPropertyToolStripMenuItem_Click);
            // 
            // deleteActionToolStripMenuItem
            // 
            this.deleteActionToolStripMenuItem.Name = "deleteActionToolStripMenuItem";
            this.deleteActionToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.deleteActionToolStripMenuItem.Text = "Delete action";
            this.deleteActionToolStripMenuItem.Click += new System.EventHandler(this.deleteActionToolStripMenuItem_Click);
            // 
            // propMenu
            // 
            this.propMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deletePropertyToolStripMenuItem,
            this.moveUpToolStripMenuItem3,
            this.moveDownToolStripMenuItem3});
            this.propMenu.Name = "propMenu";
            this.propMenu.Size = new System.Drawing.Size(156, 70);
            // 
            // deletePropertyToolStripMenuItem
            // 
            this.deletePropertyToolStripMenuItem.Name = "deletePropertyToolStripMenuItem";
            this.deletePropertyToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.deletePropertyToolStripMenuItem.Text = "Delete property";
            this.deletePropertyToolStripMenuItem.Click += new System.EventHandler(this.deletePropertyToolStripMenuItem_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "event_list.dat";
            this.saveFileDialog1.Filter = "Event List (*.dat)|*.dat";
            // 
            // moveUpToolStripMenuItem
            // 
            this.moveUpToolStripMenuItem.Name = "moveUpToolStripMenuItem";
            this.moveUpToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.moveUpToolStripMenuItem.Text = "Move up";
            this.moveUpToolStripMenuItem.Click += new System.EventHandler(this.moveUpToolStripMenuItem_Click);
            // 
            // moveDownToolStripMenuItem
            // 
            this.moveDownToolStripMenuItem.Name = "moveDownToolStripMenuItem";
            this.moveDownToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.moveDownToolStripMenuItem.Text = "Move down";
            this.moveDownToolStripMenuItem.Click += new System.EventHandler(this.moveDownToolStripMenuItem_Click);
            // 
            // moveUpToolStripMenuItem1
            // 
            this.moveUpToolStripMenuItem1.Name = "moveUpToolStripMenuItem1";
            this.moveUpToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.moveUpToolStripMenuItem1.Text = "Move up";
            this.moveUpToolStripMenuItem1.Click += new System.EventHandler(this.moveUpToolStripMenuItem1_Click);
            // 
            // moveDownToolStripMenuItem1
            // 
            this.moveDownToolStripMenuItem1.Name = "moveDownToolStripMenuItem1";
            this.moveDownToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.moveDownToolStripMenuItem1.Text = "Move down";
            this.moveDownToolStripMenuItem1.Click += new System.EventHandler(this.moveDownToolStripMenuItem1_Click);
            // 
            // moveUpToolStripMenuItem2
            // 
            this.moveUpToolStripMenuItem2.Name = "moveUpToolStripMenuItem2";
            this.moveUpToolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.moveUpToolStripMenuItem2.Text = "Move up";
            this.moveUpToolStripMenuItem2.Click += new System.EventHandler(this.moveUpToolStripMenuItem2_Click);
            // 
            // moveDownToolStripMenuItem2
            // 
            this.moveDownToolStripMenuItem2.Name = "moveDownToolStripMenuItem2";
            this.moveDownToolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.moveDownToolStripMenuItem2.Text = "Move down";
            this.moveDownToolStripMenuItem2.Click += new System.EventHandler(this.moveDownToolStripMenuItem2_Click);
            // 
            // moveUpToolStripMenuItem3
            // 
            this.moveUpToolStripMenuItem3.Name = "moveUpToolStripMenuItem3";
            this.moveUpToolStripMenuItem3.Size = new System.Drawing.Size(155, 22);
            this.moveUpToolStripMenuItem3.Text = "Move up";
            this.moveUpToolStripMenuItem3.Click += new System.EventHandler(this.moveUpToolStripMenuItem3_Click);
            // 
            // moveDownToolStripMenuItem3
            // 
            this.moveDownToolStripMenuItem3.Name = "moveDownToolStripMenuItem3";
            this.moveDownToolStripMenuItem3.Size = new System.Drawing.Size(155, 22);
            this.moveDownToolStripMenuItem3.Text = "Move down";
            this.moveDownToolStripMenuItem3.Click += new System.EventHandler(this.moveDownToolStripMenuItem3_Click);
            // 
            // MainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 262);
            this.Controls.Add(this.controlPanel);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainUI";
            this.Text = "Event Editor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.eventMenu.ResumeLayout(false);
            this.actorMenu.ResumeLayout(false);
            this.actionMenu.ResumeLayout(false);
            this.propMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.ContextMenuStrip eventMenu;
        private System.Windows.Forms.ToolStripMenuItem addActorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteEventToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip actorMenu;
        private System.Windows.Forms.ToolStripMenuItem addActionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteActorToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip actionMenu;
        private System.Windows.Forms.ToolStripMenuItem addPropertyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteActionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip propMenu;
        private System.Windows.Forms.ToolStripMenuItem deletePropertyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem addEventToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveDownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveUpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem moveDownToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem moveUpToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem moveDownToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem moveUpToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem moveDownToolStripMenuItem3;
    }
}

