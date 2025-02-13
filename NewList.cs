using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace CheckMates_Vers_0._0
{
    public partial class NewList : Form
    {
        public NewList()
        {
            InitializeComponent();
        }

        private void newListCancel_Click(object sender, EventArgs e)
        {
            textbox1.Clear();
            this.Close();
        }

        private void newListSave_Click(object sender, EventArgs e)
        {
            try
            {
                Name = textbox1.Text;
                SQLiteConnection connectionString = new SQLiteConnection(@"Data Source=..\..\Files\toDoList.db;Version=3;");
                connectionString.Open();
                SQLiteCommand cmd = new SQLiteCommand($"CREATE TABLE IF NOT EXISTS {Name} (Description TEXT NOT NULL PRIMARY KEY, DueDate TEXT NOT NULL, Comments TEXT NOT NULL);", connectionString);
                DataTable dt = new DataTable();
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                adapter.Fill(dt);
                connectionString.Close();
                textbox1.Clear();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }                 
        }
    }
}
