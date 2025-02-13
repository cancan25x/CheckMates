namespace CheckMates_Vers_0._0
{
    partial class NewList
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
            this.label1 = new System.Windows.Forms.Label();
            this.newListSave = new System.Windows.Forms.Button();
            this.newListCancel = new System.Windows.Forms.Button();
            this.textbox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(116, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please enter the name of your list";
            // 
            // newListSave
            // 
            this.newListSave.Location = new System.Drawing.Point(120, 124);
            this.newListSave.Name = "newListSave";
            this.newListSave.Size = new System.Drawing.Size(75, 23);
            this.newListSave.TabIndex = 1;
            this.newListSave.Text = "Save";
            this.newListSave.UseVisualStyleBackColor = true;
            this.newListSave.Click += new System.EventHandler(this.newListSave_Click);
            // 
            // newListCancel
            // 
            this.newListCancel.Location = new System.Drawing.Point(285, 124);
            this.newListCancel.Name = "newListCancel";
            this.newListCancel.Size = new System.Drawing.Size(75, 23);
            this.newListCancel.TabIndex = 2;
            this.newListCancel.Text = "Cancel";
            this.newListCancel.UseVisualStyleBackColor = true;
            this.newListCancel.Click += new System.EventHandler(this.newListCancel_Click);
            // 
            // textbox1
            // 
            this.textbox1.Location = new System.Drawing.Point(120, 70);
            this.textbox1.Name = "textbox1";
            this.textbox1.Size = new System.Drawing.Size(240, 20);
            this.textbox1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(170, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Please do not use spaces";
            // 
            // NewList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 169);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textbox1);
            this.Controls.Add(this.newListCancel);
            this.Controls.Add(this.newListSave);
            this.Controls.Add(this.label1);
            this.Name = "NewList";
            this.Text = "Check It Off";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button newListSave;
        private System.Windows.Forms.Button newListCancel;
        private System.Windows.Forms.TextBox textbox1;
        private System.Windows.Forms.Label label2;
    }
}