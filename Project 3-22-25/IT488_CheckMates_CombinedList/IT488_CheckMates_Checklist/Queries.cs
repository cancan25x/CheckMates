using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Data;
using System.Windows.Forms;
using IT488_CheckMates_Checklist;

public static class queryHomepage
{
    //private static string connectionString = @"Data Source = ..\..\..\Files\toDoList.db; Version=3;";
    SQLiteConnection connectionString = new SQLiteConnection(@"Data Source = ..\..\Project 3-22-25\LogInPage2\LogInPage2\Files\toDoList.db; Version=3;");
    public static void fillChecklist()
    {
        CheckedListBox checkedListBox = HomePage.instance.checkBox;
        SQLiteConnection connectionString = new SQLiteConnection(@"Data Source = ..\..\Files\toDoList.db; Version=3;");
        connectionString.Open();
        checkedListBox.Items.Clear();
        SQLiteCommand cmd = new SQLiteCommand(@"SELECT NAME FROM sqlite_master WHERE TYPE ='table' ORDER BY NAME ASC;", connectionString);        
        DataTable dt = new DataTable();
        SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
        adapter.Fill(dt);
        foreach (DataRow dr in dt.Rows)
        {
            checkedListBox.Items.Add(dr["Name"].ToString());
        }
        connectionString.Close();
    }
}