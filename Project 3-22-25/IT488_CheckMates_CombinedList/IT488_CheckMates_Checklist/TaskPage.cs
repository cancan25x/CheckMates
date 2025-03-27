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
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Runtime.Remoting.Messaging;

namespace IT488_CheckMates_Homescreen
{
    public partial class TaskPage : Form
    {
        public static TaskPage instance;
        public TextBox listName;

        SQLiteConnection connectionString = new SQLiteConnection(@"Data Source = ..\..\Project 3-22-25\LogInPage2\LogInPage2\Files\toDoList.db; Version=3;");
        int num = 1;
        public TaskPage()
        {
            InitializeComponent();
            instance = this;      
            fill_grid();
            listName = listBox;    
        }
        //pulls the list name from the homepage to allow it to be used as a variable
        private void Form1_Load_1(object sender, EventArgs e)
        {            
            listBox.Text = HomePage.instance.listName.Text;
        }

        //Fills the grid on task page by taking the list name from the homepage this is to only be used when loading in
        public void fill_grid()
        {
            try
            {
                string listName = HomePage.instance.listName.Text;
                taskGrid.Refresh();
                connectionString.Open();
                SQLiteCommand cmd = new SQLiteCommand($@"SELECT taskName AS 'Name', done AS 'Done', dueDate AS 'Due Date', priority
                AS 'Priority' FROM {listName};", connectionString);
                DataTable dt = new DataTable();
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);               
                adapter.Fill(dt);                
                taskGrid.DataSource = dt;
                connectionString.Close();                              

                DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
                checkColumn.Name = "X";
                checkColumn.HeaderText = "X";
                checkColumn.Width = 50;
                checkColumn.ReadOnly = false;
                checkColumn.FillWeight = 10;
                while (num < 2)
                {
                    taskGrid.Columns.Add(checkColumn);
                    num = num + num;
                }
                checkColumn.TrueValue = 1;
                checkColumn.FalseValue = 0;
                //checkCheckmark();
            }
            catch (Exception)
            {
                this.Close();
                MessageBox.Show("Please select a list", "ERROR");
            }
        }       

        private void addTask_Click(object sender, EventArgs e)
        {
            AddTask addTask = new AddTask();
            addTask.Show();
        }
        private void deleteTasks_Click(object sender, EventArgs e)
        {
            
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete these tasks off your list?", "Are you sure?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {                   
                    for (int i = taskGrid.Rows.Count - 1; i >= 0; i--)  
                    {
                        DataGridViewRow row = taskGrid.Rows[i];
                        DataGridViewCheckBoxCell cell = row.Cells["X"] as DataGridViewCheckBoxCell;                        
                        if (cell != null && Convert.ToBoolean(cell.Value) == true)
                            {
                                string list = listBox.Text;
                                string name = taskGrid.Rows[i].Cells[1].Value.ToString();                                
                                connectionString.Open();
                                SQLiteCommand cmd = new SQLiteCommand($@"DELETE FROM {list} WHERE taskName = ""{name}"";", connectionString);
                                cmd.ExecuteNonQuery();
                                connectionString.Close();
                            }                       
                    }
                    fill_grid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (dialogResult == DialogResult.No)
            {

            }            
        }

        private void taskGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
            foreach (DataGridViewRow row in taskGrid.Rows)
            {
                //DataGridViewRow row = taskGrid.Rows[i];
                DataGridViewCheckBoxCell cell = row.Cells["X"] as DataGridViewCheckBoxCell;
                if (cell != null && Convert.ToBoolean(cell.Value) == true)
                {
                    string list = listBox.Text;
                    string name = row.Cells[1].Value.ToString();
                    connectionString.Open();
                    SQLiteCommand cmd = new SQLiteCommand($@"UPDATE {list} SET done = ""Yes"" WHERE taskName = ""{name}"";", connectionString);
                    cmd.ExecuteNonQuery();
                    connectionString.Close();
                }

             }
            
            for (int i = taskGrid.Rows.Count - 1; i >= 0; i--)
            {
                DataGridViewRow row = taskGrid.Rows[i];
                DataGridViewCheckBoxCell cell = row.Cells["X"] as DataGridViewCheckBoxCell;
                if (cell != null && Convert.ToBoolean(cell.Value) == true)
                {
                    string list = listBox.Text;
                    string name = taskGrid.Rows[i].Cells[1].Value.ToString();
                    connectionString.Open();
                    SQLiteCommand cmd = new SQLiteCommand($@"DELETE FROM {list} WHERE taskName = ""{name}"";", connectionString);
                    cmd.ExecuteNonQuery();
                    connectionString.Close();
                }
            }
            */           

        }
        //This is the code for the save button it changes the values for done to yes
        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            taskGrid.CurrentCell = taskGrid.Rows[0].Cells[1];
            connectionString.Open();
            for (int i = 0; i< taskGrid.Rows.Count; i++)
            {                
                DataGridViewRow row = taskGrid.Rows[i];
                DataGridViewCheckBoxCell cell = row.Cells["X"] as DataGridViewCheckBoxCell;
                if (cell != null && Convert.ToBoolean(cell.Value) == true)
                {
                    string list = listBox.Text;
                    string name = taskGrid.Rows[i].Cells[1].Value.ToString();
                    //Uncomment line below for testing save button
                    //DialogResult dialogResult = MessageBox.Show($@"{i} {name}", $@"Are you sure", MessageBoxButtons.YesNo);
                    SQLiteCommand cmd = new SQLiteCommand($@"UPDATE {list} SET done = ""Yes"" WHERE taskName = ""{name}"";", connectionString);
                    cmd.ExecuteNonQuery();                    
                }
                else
                {
                    string list = listBox.Text;
                    string name = taskGrid.Rows[i].Cells[1].Value.ToString();
                    //Uncomment line below for testing save button
                    //DialogResult dialogResult = MessageBox.Show($@"{i} {name}", $@"Are you sure", MessageBoxButtons.YesNo);
                    SQLiteCommand cmd = new SQLiteCommand($@"UPDATE {list} SET done = ""No"" WHERE taskName = ""{name}"";", connectionString);
                    cmd.ExecuteNonQuery();
                }
            }
            connectionString.Close();        

        }
        //eventually this will be the code that will check the checkboxes if the value in the done column is yes
        private void checkCheckmark()
        {
            
            foreach (DataGridViewRow dr in taskGrid.Rows)
            {
                DataGridViewCheckBoxCell cell = dr.Cells["X"] as DataGridViewCheckBoxCell;
                if (dr.Cells[2].Value.ToString() == "Yes")
                {
                    cell.TrueValue = true;
                }
            }
            for (int i = 0; i <  taskGrid.Rows.Count; i++)
            {
                DataGridViewRow row = taskGrid.Rows[i];
                DataGridViewCheckBoxCell cell = row.Cells["X"] as DataGridViewCheckBoxCell;
                if (row.Cells[2].Value.ToString() == "Yes")
                {
                    taskGrid.CurrentCell = cell;
                }
            }
        }
    }
}
                    
   
