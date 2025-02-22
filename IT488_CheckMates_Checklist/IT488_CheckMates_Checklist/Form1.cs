using System;
using System.Drawing;
using System.Windows.Forms;
using IT488_CheckMates_Checklist.Properties; // Ensure this namespace is referenced

namespace IT488_CheckMates_Checklist
{
    public partial class Form1 : Form
    {
        // Timer to handle GIF animation
        private Timer animationTimer;
        public Form1()
        {
            InitializeComponent();

            // Wire up event handlers for buttons and text box
            removeButton.Click += new EventHandler(RemoveButton_Click);

            clearButton.Click += new EventHandler(ClearButton_Click);

            itemTextBox.KeyDown += new KeyEventHandler(ItemTextBox_KeyDown);

            this.ResizeBegin += new EventHandler(Form1_Resize);

            // Initialize existing PictureBox with embedded image
            pictureBox1.Image = Resources.fireworks; // Access the GIF from resources
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Visible = false; // Hide initially

            // Set up the animation timer
            animationTimer = new Timer();
            animationTimer.Interval = 100; // Refresh every 100 milliseconds
            animationTimer.Tick += new EventHandler(OnAnimationTimerTick);

            // Add click event handler for PictureBox
            pictureBox1.Click += new EventHandler(PictureBox_Click);
            checkedListBox1.ItemCheck += new ItemCheckEventHandler(CheckedListBox_ItemCheck);

            // Hook up the Load event
            this.Load += new EventHandler(Form1_Load);
        }

        // Method called when form loads
        private void Form1_Load(object sender, EventArgs e)
        {
            // Logic to execute when the form loads
        }

        // Remove selected item from checked list box
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

        // Clear all items in the checked list box
        private void ClearButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to clear the list?", "Confirm Clear", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                checkedListBox1.Items.Clear();
            }
        }

        // Resize the checked list box when the form is resized
        private void Form1_Resize(object sender, EventArgs e)
        {
            checkedListBox1.Width = this.ClientSize.Width;
            checkedListBox1.Height = this.ClientSize.Height;
        }

        // Handle Enter key press to add item
        private void ItemTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addButton.PerformClick();

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        // Add item to checked list box
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

        // Check if all items are checked and show/hide PictureBox accordingly
        private void CheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                bool allChecked = true;
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (checkedListBox1.GetItemCheckState(i) != CheckState.Checked)
                    {
                        allChecked = false;
                        break;
                    }
                }

                if (allChecked && e.NewValue == CheckState.Checked)
                {
                    pictureBox1.Visible = true;
                    animationTimer.Start(); // Start the animation timer
                }
                else
                {
                    pictureBox1.Visible = false;
                    animationTimer.Stop(); // Stop the animation timer
                }
            }));
        }

        // Hide PictureBox and stop animation timer when PictureBox is clicked
        private void PictureBox_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false; // Hide the PictureBox when clicked
            animationTimer.Stop(); // Stop the animation timer
        }

        // Update GIF frames in PictureBox
        private void OnAnimationTimerTick(object sender, EventArgs e)
        {
            ImageAnimator.UpdateFrames(pictureBox1.Image); // Update the frames of the GIF
            pictureBox1.Invalidate(); // Redraw the PictureBox
        }
    }
}