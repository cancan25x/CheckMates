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
using Microsoft.SqlServer.Server;
using System.Drawing.Text;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.SqlClient;
using System.Xml.Linq;



namespace CheckMates_Vers_0._0
{
    public partial class Form1 : Form
    {
        SQLiteConnection connectionString = new SQLiteConnection(@"Data Source=..\..\Files\toDoList.db;Version=3;");

        int num = 1;
        public static Form1 form1Instance;
        public static DataGridView grid1Instance;
        public static ComboBox cmbx1;
        public Form1()
        {
            InitializeComponent();
            form1Instance = this;
            grid1Instance = grid1;
            cmbx1 = cmbMain;
        }

        public void button1_Click(object sender, EventArgs e)
        {
            NewList newList = new NewList();
            newList.Show();
            fillComboBox();
        }

        private void cmbMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill_grid();
        }            

        private void Form1_Load(object sender, EventArgs e)
        {
            fillComboBox();
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            fillComboBox();
        }

        protected void deleteList_Click(object sender, EventArgs e)
        {
            string list = cmbMain.SelectedItem.ToString();
            DialogResult res = MessageBox.Show("Are you sure you want to delete the current list?", "Confirm", MessageBoxButtons.YesNo
             );
            if (res == DialogResult.Yes)
            {
                connectionString.Open();
                SQLiteCommand cmd = new SQLiteCommand($@"DROP TABLE {list};", connectionString);
                cmd.ExecuteNonQuery();
                connectionString.Close();
            }
            else if (res == DialogResult.No)
            {
                return;
            }          
            fillComboBox();
        }

        private void addTask_Click(object sender, EventArgs e)
        {
            try
            {
                string list = cmbMain.SelectedItem.ToString();
                string description = desTxt.Text;
                string dueDate = ddTxt.Text;
                string comment = comTxt.Text;
                connectionString.Open();
                SQLiteCommand cmd = new SQLiteCommand($@"INSERT INTO {list} Values (""{description}"",""{dueDate}"",""{comment}"");", connectionString);
                cmd.ExecuteNonQuery();
                connectionString.Close();
                fill_grid();
                desTxt.Clear();
                ddTxt.Clear();
                comTxt.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        //Deletes only from table not from db
        private void grid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          /*DataGridView dgv = (DataGridView)sender;
            e.RowIndex row = new e.RowIndex();
            connectionString.Open();
            string listName = cmbMain.SelectedItem.ToString();
            SQLiteCommand cmd = new SQLiteCommand($@"DELETE FROM {listName} WHERE ");
            grid1.Rows.RemoveAt(row);
           */ 
        }

        private void fill_grid()
        {

            grid1.Refresh();
            //Connection string for the database
            string listName = cmbMain.SelectedItem.ToString();
            connectionString.Open();

            //the query command to pull the data
            SQLiteCommand cmd = new SQLiteCommand($"SELECT Description, DueDate, Comments FROM {listName};", connectionString);

            //data to adapter the data in the grid
            DataTable dt = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);

            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            deleteButtonColumn.HeaderText = "Delete";
            deleteButtonColumn.Name = "Delete";
            deleteButtonColumn.Text = "Delete";
            deleteButtonColumn.UseColumnTextForButtonValue = true;
            int columnIndexs = 0;
            if (grid1.Columns["Delete"] == null)
            {
                grid1.Columns.Insert(columnIndexs, deleteButtonColumn);
            }
            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
            editButtonColumn.HeaderText = "Edit";
            editButtonColumn.Name = "Edit";
            editButtonColumn.Text = "Edit";
            editButtonColumn.UseColumnTextForButtonValue = true;
            int columnIndexss = 1;
            if (grid1.Columns["Edit"] == null)
            {
                grid1.Columns.Insert(columnIndexss, editButtonColumn);
            }

            adapter.Fill(dt);
            grid1.DataSource = dt;
            connectionString.Close();            
         
            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.Name = "X";
            checkColumn.HeaderText = "X";
            checkColumn.Width = 50;
            checkColumn.ReadOnly = false;
            checkColumn.FillWeight = 10;
            while (num < 2)
            {
                grid1.Columns.Add(checkColumn);
                num = num + num;
            }
        }

        public void fillComboBox()
        {
            connectionString.Open();
            cmbMain.Items.Clear();           
            SQLiteCommand cmd = new SQLiteCommand(@"SELECT NAME FROM sqlite_master WHERE TYPE =""table"" ORDER BY NAME;", connectionString);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            adapter.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                cmbMain.Items.Add(dr["Name"].ToString());
            }
            connectionString.Close();
        }

    }
}


