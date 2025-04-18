﻿using IT488_CheckMates_Homescreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace IT488_CheckMates_Checklist
{
    public partial class AddTask : Form
    {
        //SQLiteConnection connectionString = new SQLiteConnection(@"Data Source = ..\..\Project 3-22-25\LogInPage2\LogInPage2\Files\toDoList.db; Version=3;");
        SQLiteConnection connectionString = new SQLiteConnection(@"Data Source = C:\Users\canyonreynolds\source\Nate work\Project 3-22-25\LogInPage2\LogInPage2\Files\toDoList.db");
        //SQLiteConnection connectionString = new SQLiteConnection(@"Data Source = ..\..\Files\toDoList.db; Version=3;");
        public AddTask()
        {
            InitializeComponent();
            
            
        }
        //pulls the list name from the homepage to allow it to be used as a variable 
        private void AddTask_Load(object sender, EventArgs e)
        {
            listBox.Text = HomePage.instance.listName.Text;
            fill_priority();
            taskName.Select();

        }

        private void fill_priority()
        {
            string[] priority = { "1 - High","2 - Medium", "3 - Low" };
            foreach (string i in priority)
            {
                comboPriority.Items.Add(i);                
            }
            comboPriority.SelectedItem = "1 - High";
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                string dueDate1 = CheckDate(dueDate.Text);
                if (dueDate1 == null)
                {
                    MessageBox.Show("Please make sure you have a valid date","ERROR");
                }
                else
                {
                    string taskName1 = taskName.Text;
                    string done = "No";
                    string priority1 = comboPriority.SelectedItem.ToString();
                    string listName = listBox.Text;
                    connectionString.Open();
                    SQLiteCommand cmd = new SQLiteCommand($@"INSERT INTO {listName} VALUES (""{taskName1}"",""{done}"",""{dueDate1}"",""{priority1}"");",
                    connectionString);
                    cmd.ExecuteNonQuery();
                    connectionString.Close();
                    TaskPage.instance.fill_grid();
                    this.Close();
                }

                
            }
            catch (Exception)
            {
                MessageBox.Show("Please ensure you have all information entered", "ERROR");
            }
            
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            taskName.Clear();
            this.Close();            

        }
        
        private static string CheckDate(string date)
        {
            string[] theDueDate = date.Split('/');
            int month = Convert.ToInt32(theDueDate[0]);
            int day = Convert.ToInt32(theDueDate[1]);
            int year = Convert.ToInt32(theDueDate[2]);
            try
            {
                if (month > 12)
                {                    
                    MessageBox.Show("Please enter a valid month", "ERROR");
                    return null;
                }
                else if (day > 31)
                {
                    MessageBox.Show("Pleasse enter a valid day", "ERROR");
                    return null;
                }
                else if (year < 2025)
                {
                    MessageBox.Show("Please enter a valid year", "ERROR");
                    return null;
                }
                else
                {
                    return date;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid date", "ERROR");      
                return null;
            }           
        }
    }
}
