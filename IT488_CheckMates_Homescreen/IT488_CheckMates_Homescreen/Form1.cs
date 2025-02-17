using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IT488_CheckMates_Homescreen
{
    public partial class Form1 : Form
    {
        BindingList<CheckoffList> checkoffLists = new BindingList<CheckoffList>();

        public Form1()
        {
            InitializeComponent();
            SetupDataGridView();
        }


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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CheckoffList newList = new CheckoffList
            {
                Name = txtListName.Text,
                DueDate = dateTimePicker.Value,
                Priority = cmbPriority.SelectedItem.ToString()
            };

            checkoffLists.Add(newList);
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
    }
}
