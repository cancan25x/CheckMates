using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace LogInPage2
{
    public partial class RegisterForm : Form
    {
        // Connection string for SQLite database
        private readonly string connectionString = "Data Source=your_database_file.db;Version=3;";

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            // Input validation
            if (string.IsNullOrWhiteSpace(usernameTextbox.Text) || string.IsNullOrWhiteSpace(passwordTextbox.Text))
            {
                MessageBox.Show("Please fill out all fields.");
                return;
            }

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    // Check if username already exists
                    string checkQuery = "SELECT * FROM Users WHERE Username=@username";
                    SQLiteCommand checkCmd = new SQLiteCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@username", usernameTextbox.Text);
                    SQLiteDataReader reader = checkCmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        MessageBox.Show("Username already exists. Please choose a different one.");
                        return;
                    }
                    reader.Close();

                    // Insert new user into the Users table
                    string query = "INSERT INTO Users (Username, Password) VALUES (@username, @password)";
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", usernameTextbox.Text);
                    cmd.Parameters.AddWithValue("@password", passwordTextbox.Text); // Note: You should hash the password for security
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("User registered successfully!");

                    this.Close(); // Close the registration form after successful registration
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error registering user: {ex.Message}");
            }
        }

        private void cancelButton_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
