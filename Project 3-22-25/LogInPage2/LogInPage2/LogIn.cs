using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using IT488_CheckMates_Checklist; // Required for file handling

namespace LogInPage2
{
    public partial class loginForm : Form
    {
        // Connection string for SQLite database
        //private readonly string connectionString = "Data Source=your_database_file.db;Version=3;";
        private readonly string connectionString = @"Data Source = ..\..\..\..\LogInPage2\LogInPage2\bin\Debug\users.db; Version=3;";

        // File for storing the remembered username
        private readonly string rememberMeFile = "remember_me.txt";

        public loginForm()
        {
            InitializeComponent();

            // Attach KeyDown event for the password textbox
            passwordTextBox.KeyDown += PasswordTextBox_KeyDown;

            // Existing event handler connections
            submitButton.Click += SubmitButton_Click;
            showPasswordButton.MouseDown += ShowPasswordButton_MouseDown;
            showPasswordButton.MouseUp += ShowPasswordButton_MouseUp;          

            // Step 2: Create SQLite database file if it doesn't exist
            //EnsureDatabaseFileExists();

            // Step 3: Initialize database schema
            //InitializeDatabase();

            // Step 6: Test the database connection
            TestConnection();

            // Step 7: Load remembered username
            LoadRememberedUser();

            // Adding event handlers for the "Show" button
            showPasswordButton.MouseDown += ShowPasswordButton_MouseDown;
            showPasswordButton.MouseUp += ShowPasswordButton_MouseUp;

            // Adding event handler for Register New Account button
            registerNewAccount.Click += RegisterNewAccountButton_Click; 
            
        }

        private void EnsureDatabaseFileExists()
        {
            string dbFilePath = "users.db";
            if (!System.IO.File.Exists(dbFilePath))
            {
                SQLiteConnection.CreateFile(dbFilePath);
            }
        }

        private void InitializeDatabase()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    // Create Users table if it doesn't exist
                    string createTableQuery = "CREATE TABLE IF NOT EXISTS Users (ID INTEGER PRIMARY KEY AUTOINCREMENT, Username TEXT NOT NULL, Password TEXT NOT NULL)";
                    SQLiteCommand cmd = new SQLiteCommand(createTableQuery, conn);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing database: {ex.Message}");
            }
        }

        private void TestConnection()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    MessageBox.Show("Database connection successful!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database connection failed: {ex.Message}");
            }
        }

        private void LoadRememberedUser()
        {
            // Check if the file exists
            if (File.Exists(rememberMeFile))
            {
                try
                {
                    // Read the saved username
                    string savedUsername = File.ReadAllText(rememberMeFile);
                    usernameTextbox.Text = savedUsername;
                    rememberMeCheckbox.Checked = true; // Automatically check the checkbox
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading saved username: {ex.Message}");
                }
            }
        }

        private void SaveRememberedUser()
        {
            try
            {
                if (rememberMeCheckbox.Checked)
                {
                    // Save the username to the file
                    File.WriteAllText(rememberMeFile, usernameTextbox.Text);
                }
                else
                {
                    // Delete the file if the user unchecks "Remember Me"
                    if (File.Exists(rememberMeFile))
                    {
                        File.Delete(rememberMeFile);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving username: {ex.Message}");
            }
        }

        private void ValidateLogin()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    string username = usernameTextbox.Text;
                    string password = passwordTextBox.Text;
                    conn.Open();

                    // Query to validate username and password
                    string query = $"SELECT * FROM Users WHERE Username={username} AND Password={password}";
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    //cmd.Parameters.AddWithValue("@username", usernameTextbox.Text);
                    //cmd.Parameters.AddWithValue("@password", passwordTextBox.Text);
                    SQLiteDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        MessageBox.Show("Login successful!");

                        // Open the main form
                        runCheckList();
                        
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error validating login: {ex.Message}");
            }
        }

        // Event handler to show the password
        private void ShowPasswordButton_MouseDown(object sender, MouseEventArgs e)
        {
            passwordTextBox.UseSystemPasswordChar = false; // Show the actual text
        }

        // Event handler to hide the password
        private void ShowPasswordButton_MouseUp(object sender, MouseEventArgs e)
        {
            passwordTextBox.UseSystemPasswordChar = true; // Hide the text again
        }

        // Event handler for Submit button
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            ValidateLogin();

            // Save or forget the username based on the checkbox state
            SaveRememberedUser();
        }

        // Event handler for Register New Account button
        private void RegisterNewAccountButton_Click(object sender, EventArgs e)
        {
            // Open the RegisterForm
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog(); // Open as a modal dialog
        }

        private void PasswordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Trigger the Submit button click event
                SubmitButton_Click(sender, e);
                e.Handled = true; // Mark the event as handled
                e.SuppressKeyPress = true; // Prevent the 'ding' sound
            }
        }

        private void runCheckList()
        {
            Application.Run(new HomePage());
            this.Hide(); // Hide the login form
        }
    }
}
