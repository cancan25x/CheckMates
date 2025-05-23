﻿using IT488_CheckMates_Checklist.Properties;
using IT488_CheckMates_Homescreen;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace IT488_CheckMates_Checklist
{
    public partial class HomePage : Form
    {
        
        public static HomePage instance;
        public TextBox listName;
        public CheckedListBox checkBox;

        //SQLiteConnection connectionString = new SQLiteConnection(@"Data Source = ..\..\Project 3-22-25\LogInPage2\LogInPage2\Files\toDoList.db; Version=3;");
        SQLiteConnection connectionString = new SQLiteConnection(@"Data Source = C:\Users\canyonreynolds\source\Nate work\Project 3-22-25\LogInPage2\LogInPage2\Files\toDoList.db");
        //SQLiteConnection connectionString = new SQLiteConnection(@"Data Source = ..\..\Files\toDoList.db; Version=3;");
        public HomePage()
        {
            InitializeComponent();

            removeButton.Click += new EventHandler(RemoveButton_Click);

            ClearButton.Click += new EventHandler(ClearButton_Click);

            itemTextBox.KeyDown += new KeyEventHandler(ItemTextBox_KeyDown);

            this.ResizeBegin += new EventHandler(Form1_Resize);

            checkedListBox1.ItemCheck += checkedListBox1_ItemCheck;

            instance = this;

           
            //For pulling the list name to another page
            listName = listBox;
            checkBox = checkedListBox1;
            queryHomepage.fillChecklist();
            /*
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
            */
        }
        // Remove selected item from checked list box
        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.SelectedItem != null)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this list?", "Are you sure?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string list = checkedListBox1.SelectedItem.ToString();
                    connectionString.Open();
                    SQLiteCommand cmd = new SQLiteCommand($"Drop TABLE {list}", connectionString);
                    cmd.ExecuteNonQuery();
                    connectionString.Close();
                    queryHomepage.fillChecklist();

                    checkedListBox1.Items.Remove(checkedListBox1.SelectedItem);
                    listBox.Text = string.Empty;
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
        }

        //not actually a clear button but a button that brings up the editlist page 
        private void ClearButton_Click(object sender, EventArgs e)
        {
            //checks if page is open and if not shows it
            string loadList = checkedListBox1.SelectedIndex.ToString();
            TaskPage taskPage = new TaskPage();
            if ((Application.OpenForms["TaskPage"] as TaskPage) != null)
            {
                ;
            }
            else
            {   //stops you from trying to load a list without selecting anything 
                try
                {
                    taskPage.Show();

                }
                catch (Exception)
                {
                    ;
                }
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
            try
            {
                if (!string.IsNullOrEmpty(newItem))
                {
                    
                    string newList = itemTextBox.Text;

                    connectionString.Open();
                    SQLiteCommand cmd = new SQLiteCommand($"CREATE TABLE IF NOT EXISTS {newList} (taskName TEXT NOT NULL PRIMARY KEY," +
                    $@" done TEXT NOT NULL, dueDate TEXT NOT NULL, priority TEXT NOT NULL)", connectionString);
                    cmd.ExecuteNonQuery();                   
                    connectionString.Close();
                    //checkedListBox1.Items.Add(newItem);
                    queryHomepage.fillChecklist();
                    itemTextBox.Text = string.Empty;
                    listBox.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("Please enter a list to add.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please no spaces or duplicate names", "ERROR");                
            }
        }

        //Ensures there is only on check box at a time & Checks if all items are checked and show/hide PictureBox accordingly
        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < checkedListBox1.Items.Count; ++ix)
                if (ix != e.Index) checkedListBox1.SetItemChecked(ix, false);
            listBox.Text = checkedListBox1.SelectedItem.ToString();

            /*
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
            */
        }
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }       
        
        private void editButton_Click(object sender, EventArgs e)
        {
            EditList editList = new EditList();
            if (checkedListBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a list");
            }
            else 
            { 
                if ((Application.OpenForms["EditList"] as EditList) != null)
                {
                    ;
                }
                else
                {
                    editList.Show();
                }
            }
        }
        // Method called when form loads
        private void HomePage_Load(object sender, EventArgs e)
        {
            queryHomepage.fillChecklist();
            //fill_checklist();
        }

        private void HomePage_FormClosing(object sender, FormClosingEventArgs e)
        {
            formClose(sender, e);
        }
        
        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formClose(sender,e);
        }
        private void formClose(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to close CheckItOff?", "Are you sure?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (dialogResult == DialogResult.No)
            {
                ;
            }
        }

        /* Hide PictureBox and stop animation timer when PictureBox is clicked
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
        */


    }
}

