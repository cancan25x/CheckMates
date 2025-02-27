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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskPage));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.addTask = new System.Windows.Forms.Button();
            this.deleteTasks = new System.Windows.Forms.Button();
            this.listBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-22, 1);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(303, 138);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridView1.Location = new System.Drawing.Point(39, 203);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ShowCellToolTips = false;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(396, 218);
            this.dataGridView1.TabIndex = 8;
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
            this.deleteTasks.Location = new System.Drawing.Point(294, 143);
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
            this.listBox.Location = new System.Drawing.Point(349, 34);
            this.listBox.Name = "listBox";
            this.listBox.ReadOnly = true;
            this.listBox.Size = new System.Drawing.Size(100, 20);
            this.listBox.TabIndex = 13;
            this.listBox.Visible = false;
            // 
            // TaskPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(475, 453);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.deleteTasks);
            this.Controls.Add(this.addTask);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TaskPage";
            this.Text = "CheckItOff";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button addTask;
        private System.Windows.Forms.Button deleteTasks;
        private System.Windows.Forms.TextBox listBox;
    }
}

