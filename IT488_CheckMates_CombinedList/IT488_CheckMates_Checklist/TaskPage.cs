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
        
        SQLiteConnection connectionString = new SQLiteConnection(@"Data Source = ..\..\Files\toDoList.db; Version=3;");        
        int num = 1;
        public TaskPage()
        {
            InitializeComponent();
            fill_grid();            
            instance = this;
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            
        }
        
        private void fill_grid()
        {
            string listName = HomePage.instance.listName.Text;
            dataGridView1.Refresh();            
            connectionString.Open();
            SQLiteCommand cmd = new SQLiteCommand($@"SELECT taskName AS ""Name"", dueDate AS ""Due Date"", priority AS ""Priority"" FROM {listName};", connectionString);            
            DataTable dt = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);

            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            deleteButtonColumn.HeaderText = "Delete";
            deleteButtonColumn.Name = "Delete";
            deleteButtonColumn.Text = "Delete";
            deleteButtonColumn.UseColumnTextForButtonValue = true;
            int columnIndexs = 0;
            if (dataGridView1.Columns["Delete"] == null)
            {
                dataGridView1.Columns.Insert(columnIndexs, deleteButtonColumn);
            }        
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
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
    }
}

