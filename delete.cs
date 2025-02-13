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

namespace CheckMates_Vers_0._0
{
    public partial class delete : Form
    {
        SQLiteConnection connectionString = new SQLiteConnection(@"Data Source=..\..\Files\toDoList.db;Version=3;");
        public delete()
        {
            InitializeComponent();
        }
        private Form1 mainForm = null;
        public delete(Form callingForm)
        {
            mainForm = callingForm as Form1;
            InitializeComponent();
        }
        private void confirm_Click(object sender, EventArgs e)
        {
            string listName = txtBox1.Text;
            connectionString.Open();
            SQLiteCommand cmd = new SQLiteCommand($"DROP TABLE {listName};", connectionString);
            cmd.ExecuteNonQuery();
            connectionString.Close();
            this.Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void delete_Load(object sender, EventArgs e)
        {

        }
    }
}
