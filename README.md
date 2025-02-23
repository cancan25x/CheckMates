# CheckMates
IT488 Software Product Development

//These are the basic lines used in executing SQLite queries

//first we create a variable of what we want to take from users inputs to use in our queries
//below is taking the text from the text box and creating that into a variable  
string newList = itemTextBox.Text;

//connectionString is the datasource string i have been placing in the top of every page so we dont need to copy and paste it a ton and can just reference connectionString
SQLiteConnection connectionString = new SQLiteConnection(@"Data Source = ..\..\Files\toDoList.db; Version=3;");

//this string opens the connection to allow writing to the database
connectionString.Open();

//SQLiteCommand is the function where we write our query out and i have been assigning it to the variable cmd. 
//first part is always the query then a comma into the connectionString
//to call a variable in SQL you need to use the $ sign before the quotes then { } around the variable you are calling. It will put that variable in the SQL query
//as show below with {newList}
SQLiteCommand cmd = new SQLiteCommand($"CREATE TABLE IF NOT EXISTS {newList} (taskName TEXT NOT NULL PRIMARY KEY, dueDate TEXT NOT NULL, priority TEXT NOT NULL)", connectionString);

//this line is where we fully execute the query to the database
cmd.ExecuteNonQuery();

//you always have to close the connection after you are done with the database or it will break
connectionString.Close();

//if you are adding to the task page you need to remember to call the fill_grid() method whenever querying and wanting information to show
//this method will refresh the grid with new information if you put the fill_grid() method at the end