using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IT488_CheckMates_Checklist
{
    public partial class EditList : Form
    {
        SQLiteConnection connectionString = new SQLiteConnection(@"Data Source = ..\..\Files\toDoList.db; Version=3;");
        public EditList()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string listName = HomePage.instance.listName.Text;
            string newlistName = editText.Text;
            try
            {
                connectionString.Open();
                SQLiteCommand cmd = new SQLiteCommand($"ALTER TABLE {listName} RENAME TO {newlistName}", connectionString);
                cmd.ExecuteNonQuery();
                connectionString.Close();
                HomePage.instance.fillCheckList();
                editText.Clear();
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a unique name without spaces","ERROR");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
