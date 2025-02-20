using IT488_CheckMates_Homescreen;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace IT488_CheckMates_Checklist
{
    public partial class HomePage : Form
    {
        public static HomePage instance;
        public TextBox listName;

        SQLiteConnection connectionString = new SQLiteConnection(@"Data Source = ..\..\Files\toDoList.db; Version=3;");
        public HomePage()
        {
            InitializeComponent();

            removeButton.Click += new EventHandler(RemoveButton_Click);

            ClearButton.Click += new EventHandler(ClearButton_Click);

            itemTextBox.KeyDown += new KeyEventHandler(ItemTextBox_KeyDown);

            this.ResizeBegin += new EventHandler(Form1_Resize);

            checkedListBox1.ItemCheck += checkedListBox1_ItemCheck;

            instance = this;

            fillCheckList();

            listName = listBox;

        }

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
                    fillCheckList();

                    checkedListBox1.Items.Remove(checkedListBox1.SelectedItem);
                    listBox.Text = string.Empty;
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            string loadList = checkedListBox1.SelectedIndex.ToString();
            TaskPage taskPage = new TaskPage();
            if ((Application.OpenForms["TaskPage"] as TaskPage) != null)
            {
                ;
            }
            else
            {
                taskPage.Show();
            }

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
                string newList = itemTextBox.Text;

                connectionString.Open();
                SQLiteCommand cmd = new SQLiteCommand($"CREATE TABLE IF NOT EXISTS {newList} (taskName TEXT NOT NULL PRIMARY KEY," +
                    $@" dueDate TEXT NOT NULL, priority TEXT NOT NULL)", connectionString);
                SQLiteCommand cmd2 = new SQLiteCommand($@"INSERT INTO {newList} VALUES("" "", "" "", "" "");", connectionString);
                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                connectionString.Close();
                fillCheckList();
                itemTextBox.Text = string.Empty;
                listBox.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Please enter a list to add.");
            }
        }

        //Ensures there is only on check box at a time 
        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < checkedListBox1.Items.Count; ++ix)
                if (ix != e.Index) checkedListBox1.SetItemChecked(ix, false);
            listBox.Text = checkedListBox1.SelectedItem.ToString();
        }
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        public void fillCheckList()
        {
            connectionString.Open();
            checkedListBox1.Items.Clear();
            SQLiteCommand cmd = new SQLiteCommand(@"SELECT NAME FROM sqlite_master WHERE TYPE =""table"" ORDER BY NAME;", connectionString);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            adapter.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                checkedListBox1.Items.Add(dr["Name"].ToString());
            }
            connectionString.Close();
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
    }
}

