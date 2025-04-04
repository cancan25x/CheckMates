namespace IT488_CheckMates_Homescreen
{
    partial class TaskPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskPage));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.taskGrid = new System.Windows.Forms.DataGridView();
            this.addTask = new System.Windows.Forms.Button();
            this.deleteTasks = new System.Windows.Forms.Button();
            this.listBox = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskGrid)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(303, 138);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // taskGrid
            // 
            this.taskGrid.AllowUserToAddRows = false;
            this.taskGrid.AllowUserToDeleteRows = false;
            this.taskGrid.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.taskGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.taskGrid.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.taskGrid.Location = new System.Drawing.Point(39, 203);
            this.taskGrid.MultiSelect = false;
            this.taskGrid.Name = "taskGrid";
            this.taskGrid.RowHeadersVisible = false;
            this.taskGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.taskGrid.ShowCellToolTips = false;
            this.taskGrid.ShowEditingIcon = false;
            this.taskGrid.Size = new System.Drawing.Size(353, 218);
            this.taskGrid.TabIndex = 8;
            this.taskGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.taskGrid_CellContentClick);
            // 
            // addTask
            // 
            this.addTask.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.addTask.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addTask.Location = new System.Drawing.Point(39, 143);
            this.addTask.Margin = new System.Windows.Forms.Padding(2);
            this.addTask.Name = "addTask";
            this.addTask.Size = new System.Drawing.Size(141, 36);
            this.addTask.TabIndex = 11;
            this.addTask.Text = "Add a New Task";
            this.addTask.UseVisualStyleBackColor = false;
            this.addTask.Click += new System.EventHandler(this.addTask_Click);
            // 
            // deleteTasks
            // 
            this.deleteTasks.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.deleteTasks.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.deleteTasks.Location = new System.Drawing.Point(251, 143);
            this.deleteTasks.Margin = new System.Windows.Forms.Padding(2);
            this.deleteTasks.Name = "deleteTasks";
            this.deleteTasks.Size = new System.Drawing.Size(141, 36);
            this.deleteTasks.TabIndex = 12;
            this.deleteTasks.Text = "Delete Checked Tasks";
            this.deleteTasks.UseVisualStyleBackColor = false;
            this.deleteTasks.Click += new System.EventHandler(this.deleteTasks_Click);
            // 
            // listBox
            // 
            this.listBox.Location = new System.Drawing.Point(267, 27);
            this.listBox.Name = "listBox";
            this.listBox.ReadOnly = true;
            this.listBox.Size = new System.Drawing.Size(100, 20);
            this.listBox.TabIndex = 13;
            this.listBox.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(99, 26);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(432, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.BackColor = System.Drawing.Color.White;
            this.saveToolStripMenuItem1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(43, 20);
            this.saveToolStripMenuItem1.Text = "Save";
            this.saveToolStripMenuItem1.Click += new System.EventHandler(this.saveToolStripMenuItem1_Click);
            // 
            // TaskPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(432, 453);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.deleteTasks);
            this.Controls.Add(this.addTask);
            this.Controls.Add(this.taskGrid);
            this.Controls.Add(this.pictureBox1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TaskPage";
            this.Text = "CheckItOff";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskGrid)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView taskGrid;
        private System.Windows.Forms.Button addTask;
        private System.Windows.Forms.Button deleteTasks;
        private System.Windows.Forms.TextBox listBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
    }
}

