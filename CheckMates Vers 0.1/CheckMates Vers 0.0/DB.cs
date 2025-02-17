using CheckMates_Vers_0._0;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

public static class db
{

    public static string connectionString = @"Data Source=..\..\Files\toDoList.db;Version=3;";


    public static void InitializeDatabase()
    {
        if (!File.Exists(connectionString))
        {
            SQLiteConnection.CreateFile(@"..\..\Files\toDoList.db");
        }
    }
}

/*
            DialogResult res = MessageBox.Show("Would you like to run the command?", "Confirm", MessageBoxButtons.YesNo
             );
            if (res == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            base.OnClick(e);
*/

/*  connectionString.Open();
    SQLiteCommand cmd = new SQLiteCommand(QUERY YOU NEED, connectionString);
    cmd.ExecuteNonQuery **** GOES THROUGH WITH THE QUERY
   
    THIS ALLOWS THE CODE TO BE PUSHED TO TABLES 
    DataTable dt = new DataTable();
    SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
    adapter.Fill(dt);
    grid1.DataSource = dt;
    
    THIS IS FOR ADDING TO A COMBOBOX
    foreach (DataRow dr in dt.Rows)
            {
                cmbMain.Items.Add(dr["Name"].ToString());
            }

    DONT FORGET TO CLOSE CONNECTION
    connectionString.Close();
*/