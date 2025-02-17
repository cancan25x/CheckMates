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

namespace IT488_CheckMates_Homescreen
{
    public partial class Form1 : Form
    {
        SQLiteConnection connectionString = new SQLiteConnection(@"Data Source = ..\..\Files\toDoList.db; Version=3;");
        //BindingList<CheckoffList> checkoffLists = new BindingList<CheckoffList>();
        int num = 1;
        public Form1()
        {
            InitializeComponent();
            //SetupDataGridView();
            fillComboBox();
            fillComboxCat();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            comboBoxCat.SelectedIndex = 0;
           
        }

        private void fill_grid()
        {

            dataGridView1.Refresh();

            string listName = comboBoxList.SelectedItem.ToString();
            //string prior = comboBoxCat.SelectedItem.ToString();
            connectionString.Open();

            //the query command to pull the data
            SQLiteCommand cmd = new SQLiteCommand($@"SELECT taskName AS ""Name"", dueDate AS ""Due Date"", priority AS ""Priority"" FROM {listName};", connectionString);

            //data to adapter the data in the grid
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
           
            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
            editButtonColumn.HeaderText = "Edit";
            editButtonColumn.Name = "Edit";
            editButtonColumn.Text = "Edit";
            editButtonColumn.UseColumnTextForButtonValue = true;
            int columnIndexss = 1;
            if (dataGridView1.Columns["Edit"] == null)
            {
                dataGridView1.Columns.Insert(columnIndexss, editButtonColumn);
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

        public void fillComboBox()
        {
            connectionString.Open();
            comboBoxList.Items.Clear();
            SQLiteCommand cmd = new SQLiteCommand(@"SELECT NAME FROM sqlite_master WHERE TYPE =""table"" ORDER BY NAME;", connectionString);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            adapter.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                comboBoxList.Items.Add(dr["Name"].ToString());
            }
            connectionString.Close();
        }

        private void comboBoxList_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill_grid();
        }

        public void fillComboxCat()
        {
            comboBoxCat.Items.Add("High");
            comboBoxCat.Items.Add("Medium");
            comboBoxCat.Items.Add("Low");
            comboBoxCat.SelectedItem = "High";
            comboBoxCat.SelectedText = "High";
        }

        /*
        private void SetupDataGridView()
        {
            dataGridView1.AutoGenerateColumns = false;

            DataGridViewColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.DataPropertyName = "Name";
            nameColumn.HeaderText = "List Name";
            dataGridView1.Columns.Add(nameColumn);

            DataGridViewColumn dueDateColumn = new DataGridViewTextBoxColumn();
            dueDateColumn.DataPropertyName = "DueDate";
            dueDateColumn.HeaderText = "Due Date";
            dataGridView1.Columns.Add(dueDateColumn);

            DataGridViewColumn priorityColumn = new DataGridViewTextBoxColumn();
            priorityColumn.DataPropertyName = "Priority";
            priorityColumn.HeaderText = "Priority";
            dataGridView1.Columns.Add(priorityColumn);

            dataGridView1.DataSource = checkoffLists;
        }       
        

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                checkoffLists.RemoveAt(dataGridView1.SelectedRows[0].Index);
            }
        }
        
        private void btnCreateList_Click(object sender, EventArgs e)
        {
            ListCreationForm listCreationForm = new ListCreationForm();
            if (listCreationForm.ShowDialog() == DialogResult.OK)
            {
                CheckoffList newList = listCreationForm.GetCheckoffList();
                checkoffLists.Add(newList);
            }
        }
        */

    }
}

