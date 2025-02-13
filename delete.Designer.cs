namespace CheckMates_Vers_0._0
{
    partial class delete
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
            this.confirm = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.txtBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(44, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(589, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter the name of the list you want to delete.";
            // 
            // confirm
            // 
            this.confirm.Location = new System.Drawing.Point(143, 152);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(89, 29);
            this.confirm.TabIndex = 1;
            this.confirm.Text = "Confirm";
            this.confirm.UseVisualStyleBackColor = true;
            this.confirm.Click += new System.EventHandler(this.confirm_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(437, 152);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(89, 29);
            this.cancel.TabIndex = 2;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // txtBox1
            // 
            this.txtBox1.Location = new System.Drawing.Point(175, 106);
            this.txtBox1.Name = "txtBox1";
            this.txtBox1.Size = new System.Drawing.Size(341, 20);
            this.txtBox1.TabIndex = 3;
            // 
            // delete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 193);
            this.Controls.Add(this.txtBox1);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.confirm);
            this.Controls.Add(this.label1);
            this.Name = "delete";
            this.Text = "delete";
            this.Load += new System.EventHandler(this.delete_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button confirm;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.TextBox txtBox1;
    }
}