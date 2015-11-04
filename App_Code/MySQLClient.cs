using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

public class MySQLClient
{
        MySqlConnection conn = null;
        //what things should be currently, will leave the server running on Baralai and hope for the best for now.
        //hostname = 173.194.241.131   //google cloud host 
        //database = aution_powers
        //username = root
        //password = root
        //port number = 3306 // shouldnt need to use this 3306 is default for MySQL
        #region Constructors
        public MySQLClient(string hostname, string database, string username, string password)
        {
            conn = new MySqlConnection("host=" + hostname + ";database=" + database +";username=" + username +";password=" + password +";");
        }

        public MySQLClient(string hostname, string database, string username, string password, int portNumber)
        {
            conn = new MySqlConnection("host=" + hostname + ";database=" + database + ";username=" + username + ";password=" + password + ";port=" + portNumber.ToString() +";");
        }

        public MySQLClient(string hostname, string database, string username, string password, int portNumber, int connectionTimeout)
        {
            conn = new MySqlConnection("host=" + hostname + ";database=" + database + ";username=" + username + ";password=" + password + ";port=" + portNumber.ToString() + ";Connection Timeout=" + connectionTimeout.ToString() +";");
        }
        #endregion

        #region Open/Close Connection
        private bool Open()
        {
            //This opens temporary connection
            try
            {
                conn.Open();
                return true;
            }
            catch
            {
                //msgbox error
                return false;
            }
        }

        private bool Close()
        {
            //This method closes the open connection
            try
            {
                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Methods
        public void Insert(string table, string column, string value)
        {
            //Insert values into the database.

            //Example: INSERT INTO user (Fname, Lname, username, password, email, phone, address, city, state, zipcode) VALUES('Eric', 'Abbott', 'eabb', 'password', 'eabbott113@gmail.com', '7066913464', '2111 N Oak', 'Valdosta', 'GA', '31698')
            //Code: MySQLClient.Insert("user", "first_name, last_name, username, password, email, phone, address, city, state, zipcode", "'Eric', 'Abbott', 'eabb', 'password', 'eabbott113@gmail.com', '7066913464', '2111 N Oak', 'Valdosta', 'GA', '31698'");
            string query = "INSERT INTO " + table + " (" + column + ") VALUES (" + value + ")";

            try
            {
                if (this.Open())
                {
                    //Opens a connection, if successful; run the query and then close the connection.

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.ExecuteNonQuery();
                    this.Close();
                }
            }
            catch { }
            return;
        }

        public void Update(string table, string SET, string WHERE)
        {
            //Update existing values in the database.

            //Example: UPDATE user SET Fname='Bill', password='password2' WHERE Fname='Eric'
            //Code: MySQLClient.Update("user", "Fname='Bill', password='password2'", "Fname='Eric'");
            string query = "UPDATE " + table + " SET " + SET + " WHERE " + WHERE + "";

            if (this.Open())
            {
                try
                {
                    //Opens a connection, if succefull; run the query and then close the connection.

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    this.Close();
                }
                catch { this.Close(); }
            }
            return;
        }

        public void Delete(string table, string WHERE) 
        {
            //Removes an entry from the database.

            //Example: DELETE FROM user WHERE Fname='Eric'
            //Code: MySQLClient.Delete("user", "Fname='Eric'");
            string query = "DELETE FROM " + table + " WHERE " + WHERE + "";

            if (this.Open())
            {
                try
                {
                    //Opens a connection, if succefull; run the query and then close the connection.

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    this.Close();
                }
                catch { this.Close(); }
            }
            return;
        }

        public int Count(string table)
        {
            //This counts the numbers of entries in a table and returns it as an integer

            //Example: SELECT Count(*) FROM user
            //Code: int myInt = MySQLClient.Count("user");

            string query = "SELECT Count(*) FROM " + table + "";
            int Count = -1;
            if (this.Open() == true)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    Count = int.Parse(cmd.ExecuteScalar() + "");
                    this.Close();
                }
                catch { this.Close(); }
                return Count;
            }
            else
            {
                return Count;
            }
        }
        #endregion
}
        


