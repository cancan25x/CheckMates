using CheckMates_Vers_0._0;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

public static class DatabaseHelper
{
    public static string connectionString = @"Data Source=..\..\Files\toDoList.db;Version=3;";

    public static void InitializeDatabase()
    {
        if (!File.Exists(@"Data Source=..\..\Files\toDoList.db"))
        {
            SQLiteConnection.CreateFile(@"..\..\Files\toDoList.db");
            /*using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string createtoDoListTableQuery = @"
                    CREATE TABLE IF NOT EXISTS FirstList (
                        Description TEXT NOT NULL PRIMARY KEY, 
                        DueDate TEXT NOT NULL,
                        Comments TEXT NOT NULL);";

                using (var cmd = new SQLiteCommand(connection))
                {
                    cmd.CommandText = createtoDoListTableQuery;
                    cmd.ExecuteNonQuery();
                }*/

            }
        }
    }
   

    /*public static void fill_cmb()
    {
        void fill_cmb()
        {
            System.Windows.Forms.ComboBox cmbMain = new System.Windows.Forms.ComboBox();
            DataTable dt = new DataTable();
            SQLiteConnection connectionString = new SQLiteConnection(@"Data Source=..\..\Files\toDoList.db;Version=3;");

            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            try
            {
                adapter.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    cmbMain.Items.Add(row["name"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }*/

    /*public  string[,] ReadObjects(connectionString)
     {
         SQLiteConnection connectionString = new SQLiteConnection(@"Data Source=..\..\Files\toDoList.db;Version=3;");

         connectionString.Open();
         SQLiteCommand cmd = new SQLiteCommand(@"""SELECT NAME FROM sqlite_master WHERE TYPE =""table:"";", connectionString);
         SQLiteDataReader read;
         read = cmd.ExecuteReader();

         int rowCount = 0;
         while (read.Read())
         {
             rowCount++;
         }

         string[,] Info = new string[rowCount, 2];

         read.Close();
         read = cmd.ExecuteReader();
         int row = 0;
         while (read.Read())
         {
             Info[row, 0] = read.GetString(1);
             Info[row, 1] = read.GetString(2);
             row++;
         }

         read.Close();
         connectionString.Close();
         return Info;
     }
 }*/


    




