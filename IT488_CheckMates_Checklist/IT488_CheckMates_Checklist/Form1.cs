using System;
using System.Windows.Forms;

namespace IT488_CheckMates_Checklist
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            removeButton.Click += new EventHandler(RemoveButton_Click);

            clearButton.Click += new EventHandler(ClearButton_Click);

            itemTextBox.KeyDown += new KeyEventHandler(ItemTextBox_KeyDown);
            
            this.ResizeBegin += new EventHandler(Form1_Resize);

        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.SelectedItem != null)
            {
                checkedListBox1.Items.Remove(checkedListBox1.SelectedItem);
            }
            else
            {
                MessageBox.Show("Please select an item to remove.");
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            checkedListBox1.Width = this.ClientSize.Width;
            checkedListBox1.Height = this.ClientSize.Height;
        }

        private void ItemTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addButton.PerformClick();

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string newItem = itemTextBox.Text.Trim();

            if (!string.IsNullOrEmpty(newItem))
            {
                checkedListBox1.Items.Add(newItem);

                itemTextBox.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Please enter an item to add.");
            }
        }


    }
}