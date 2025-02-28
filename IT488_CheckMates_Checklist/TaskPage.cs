using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using IT488_CheckMates_Checklist;

namespace IT488_CheckMates_Homescreen
{
    public partial class TaskPage : Form
    {
        public static TaskPage instance;
        public TextBox listName;
        public TextBox textBox1;
        private DataTable taskTable; // Add a DataTable to hold the data

        SQLiteConnection connectionString = new SQLiteConnection(@"Data Source = ..\..\Files\toDoList.db; Version=3;");
        int num = 1;

        public TaskPage()
        {
            InitializeComponent();
            instance = this;
            InitializeTaskTable(); // Initialize the DataTable
            fill_grid();
            listName = listBox;
        }

        private void InitializeTaskTable()
        {
            // Initialize the DataTable and define columns
            taskTable = new DataTable();
            taskTable.Columns.Add("Name", typeof(string));
            taskTable.Columns.Add("Due Date", typeof(string));
            taskTable.Columns.Add("Priority", typeof(string));
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            listBox.Text = HomePage.instance.listName.Text;
        }


        public void fill_grid()
        {
            try
            {
                string listName = HomePage.instance.listName.Text;
                dataGridView1.Refresh();
                connectionString.Open();
                SQLiteCommand cmd = new SQLiteCommand($@"SELECT taskName AS ""Name"", dueDate AS ""Due Date"", priority AS ""Priority"" FROM {listName};", connectionString);

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                adapter.Fill(taskTable); // Fill the DataTable
                dataGridView1.DataSource = taskTable; // Set the DataGridView DataSource to the DataTable
                connectionString.Close();

                DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
                checkColumn.Name = "X";
                checkColumn.HeaderText = "X";
                checkColumn.Width = 50;
                checkColumn.ReadOnly = false;
                checkColumn.FillWeight = 10;
                while (num < 2)
                {
                    dataGridView1.Columns.Add(checkColumn);
                    num = num + num;
                }
            }
            catch (Exception)
            {
                this.Close();
                MessageBox.Show("Please select a list", "ERROR");
            }
        }

        private void refresh_grid()
        {
            try
            {
                string listName = HomePage.instance.listName.Text;
                dataGridView1.Refresh();
                connectionString.Open();
                SQLiteCommand cmd = new SQLiteCommand($@"SELECT taskName AS ""Name"", dueDate AS ""Due Date"", priority AS ""Priority"" FROM {listName};", connectionString);
                taskTable.Clear();
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                adapter.Fill(taskTable); // Fill the DataTable
                dataGridView1.DataSource = taskTable; // Set the DataGridView DataSource to the DataTable
                connectionString.Close();

                DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
                checkColumn.Name = "X";
                checkColumn.HeaderText = "X";
                checkColumn.Width = 50;
                checkColumn.ReadOnly = false;
                checkColumn.FillWeight = 10;
                while (num < 2)
                {
                    dataGridView1.Columns.Add(checkColumn);
                    num = num + num;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addTask_Click(object sender, EventArgs e)
        {
            string taskName = textBox2.Text.Trim();
            string dueDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string priority = comboBox1.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(taskName) && !string.IsNullOrEmpty(dueDate) && !string.IsNullOrEmpty(priority))
            {
                DataRow newRow = taskTable.NewRow();
                newRow["Name"] = taskName;
                newRow["Due Date"] = dueDate;
                newRow["Priority"] = priority;
                taskTable.Rows.Add(newRow); // Add the new row to the DataTable

                textBox2.Text = string.Empty;    // Clear textBox1 after adding the item
                dateTimePicker1.Value = DateTime.Now; // Reset the date picker
                comboBox1.SelectedIndex = -1; // Reset the priority combo box
            }
            else
            {
                MessageBox.Show("Please fill in all fields (Task Name, Due Date, and Priority).");
            }
        }

        private void deleteTasks_Click(object sender, EventArgs e)
        {
            // Iterate through the DataGridView rows in reverse order to avoid issues while removing rows
            for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
            {
                DataGridViewRow row = dataGridView1.Rows[i];
                DataGridViewCheckBoxCell cell = row.Cells["X"] as DataGridViewCheckBoxCell;

                // Check if the checkbox cell is selected
                if (cell != null && Convert.ToBoolean(cell.Value) == true)
                {
                    // Remove the row from the DataTable
                    taskTable.Rows[row.Index].Delete();
                }
            }

            // Accept changes to refresh the DataGridView
            taskTable.AcceptChanges();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Implement the functionality for cell content click here
        }
    }

}