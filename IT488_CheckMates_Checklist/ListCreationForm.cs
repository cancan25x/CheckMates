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
    public partial class ListCreationForm : Form
    {
        SQLiteConnection connectionString = new SQLiteConnection(@"Data Source=..\..\Files\toDoList.db;Version=3;");
        public ListCreationForm()
        {
            InitializeComponent();
        }

        public CheckoffList GetCheckoffList()
        {
            return new CheckoffList
            {
                Name = txtListName.Text,
                DueDate = dateTimePicker.Value,
                Priority = cmbPriority.SelectedItem.ToString()
            };
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

        }
    }
}

//@"Data Source=..\..\Files\toDoList.db;Version=3;"