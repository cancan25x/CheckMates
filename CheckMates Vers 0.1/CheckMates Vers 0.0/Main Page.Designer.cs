namespace CheckMates_Vers_0._0
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.button1 = new System.Windows.Forms.Button();
            this.grid1 = new System.Windows.Forms.DataGridView();
            this.cmbMain = new System.Windows.Forms.ComboBox();
            this.refresh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.deleteList = new System.Windows.Forms.Button();
            this.addTask = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.desTxt = new System.Windows.Forms.TextBox();
            this.comTxt = new System.Windows.Forms.TextBox();
            this.ddTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1075, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(590, 112);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(179, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Add New List";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // grid1
            // 
            this.grid1.AllowUserToOrderColumns = true;
            this.grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid1.Location = new System.Drawing.Point(0, 190);
            this.grid1.Name = "grid1";
            this.grid1.ShowEditingIcon = false;
            this.grid1.Size = new System.Drawing.Size(1075, 506);
            this.grid1.TabIndex = 4;
            this.grid1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid1_CellContentClick);
            // 
            // cmbMain
            // 
            this.cmbMain.FormattingEnabled = true;
            this.cmbMain.Location = new System.Drawing.Point(663, 64);
            this.cmbMain.Name = "cmbMain";
            this.cmbMain.Size = new System.Drawing.Size(338, 21);
            this.cmbMain.TabIndex = 5;
            this.cmbMain.SelectedIndexChanged += new System.EventHandler(this.cmbMain_SelectedIndexChanged);
            // 
            // refresh
            // 
            this.refresh.Location = new System.Drawing.Point(822, 112);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(179, 23);
            this.refresh.TabIndex = 6;
            this.refresh.Text = "Refresh Lists";
            this.refresh.UseVisualStyleBackColor = true;
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(792, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 29);
            this.label1.TabIndex = 7;
            this.label1.Text = "Lists";
            // 
            // deleteList
            // 
            this.deleteList.Location = new System.Drawing.Point(590, 146);
            this.deleteList.Name = "deleteList";
            this.deleteList.Size = new System.Drawing.Size(179, 23);
            this.deleteList.TabIndex = 8;
            this.deleteList.Text = "Delete a List";
            this.deleteList.UseVisualStyleBackColor = true;
            this.deleteList.Click += new System.EventHandler(this.deleteList_Click);
            // 
            // addTask
            // 
            this.addTask.Location = new System.Drawing.Point(97, 26);
            this.addTask.Name = "addTask";
            this.addTask.Size = new System.Drawing.Size(179, 23);
            this.addTask.TabIndex = 9;
            this.addTask.Text = "Add a task";
            this.addTask.UseVisualStyleBackColor = true;
            this.addTask.Click += new System.EventHandler(this.addTask_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Description";
            // 
            // desTxt
            // 
            this.desTxt.Location = new System.Drawing.Point(55, 70);
            this.desTxt.Name = "desTxt";
            this.desTxt.Size = new System.Drawing.Size(196, 20);
            this.desTxt.TabIndex = 11;
            // 
            // comTxt
            // 
            this.comTxt.Location = new System.Drawing.Point(55, 149);
            this.comTxt.Name = "comTxt";
            this.comTxt.Size = new System.Drawing.Size(196, 20);
            this.comTxt.TabIndex = 12;
            // 
            // ddTxt
            // 
            this.ddTxt.Location = new System.Drawing.Point(55, 112);
            this.ddTxt.Name = "ddTxt";
            this.ddTxt.Size = new System.Drawing.Size(196, 20);
            this.ddTxt.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Comments";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Due Date";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 696);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ddTxt);
            this.Controls.Add(this.comTxt);
            this.Controls.Add(this.desTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.addTask);
            this.Controls.Add(this.deleteList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.refresh);
            this.Controls.Add(this.cmbMain);
            this.Controls.Add(this.grid1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Check It Off";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView grid1;
        private System.Windows.Forms.ComboBox cmbMain;
        private System.Windows.Forms.Button refresh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button deleteList;
        private System.Windows.Forms.Button addTask;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox desTxt;
        private System.Windows.Forms.TextBox comTxt;
        private System.Windows.Forms.TextBox ddTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

