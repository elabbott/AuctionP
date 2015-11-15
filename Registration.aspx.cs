using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;

public partial class Registration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void RegisterUser(object sender, EventArgs e)
    {
        #region commented hardcode insert
        //MySqlConnection con = new MySqlConnection();
        //con.ConnectionString = "server=173.194.241.131;database=auction_powers;uid=root;pwd=root;";
        //MySqlCommand cmd = null;

        ////add freetext to db
        //con.Open();
        //cmd = new MySqlCommand();
        //cmd.Parameters.AddWithValue("?username", txtUsername.Text.Trim());
        //cmd.Parameters.AddWithValue("?password", txtPassword.Text.Trim());
        //cmd.Parameters.AddWithValue("?email", txtEmail.Text.Trim());
        //cmd.Connection = con;
        //cmd.CommandText = "INSERT INTO user (username, `password`, email) VALUES (?username, ?password, ?email)";
        //cmd.ExecuteNonQuery();
        //con.Close();
        #endregion

        User registering_user = new User(txtUsername.Text.Trim(), txtPassword.Text.Trim(), txtEmail.Text.Trim());
        MySqlConnection conn = new MySqlConnection();
        conn.ConnectionString = "server=173.194.241.131;database=auction_powers;uid=root;pwd=root;";
        MySQLClient register_user = new MySQLClient(conn);
        register_user.Insert_Users(registering_user);


        //currently failed attempt at getting stored procedure to work
        ////int userId = 0;
        //MySqlConnection conn = new MySqlConnection();
        //conn.ConnectionString = "server=173.194.241.131;database=auction_powers;uid=root;pwd=root;";
        //MySqlCommand cmd = new MySqlCommand();
        //try
        //{
        //    conn.Open();

        //    cmd.Connection = conn;
        //    cmd.CommandText = "Insert_User";
        //    cmd.CommandType = CommandType.StoredProcedure;

        //    cmd.Parameters.AddWithValue("Username", txtUsername.Text.Trim());
        //    cmd.Parameters["Username"].Direction = ParameterDirection.Input;

        //    cmd.Parameters.AddWithValue("Pass", txtPassword.Text.Trim());
        //    cmd.Parameters["Pass"].Direction = ParameterDirection.Input;

        //    cmd.Parameters.AddWithValue("Email", txtEmail.Text.Trim());
        //    cmd.Parameters["Email"].Direction = ParameterDirection.Input;

        //    cmd.ExecuteNonQuery();

        //}
        //catch (MySqlException ex)
        //{
        //    string message = string.Empty;
        //    message = "Insert failed with: " + ex.Message;
        //    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
        //}
        //finally
        //{
        //    conn.Close();
        //}

        //catch
        //{
        //    string message = string.Empty;
        //    switch (userId)
        //    {
        //        case -1:
        //            message = "Username already exists.\\nPlease choose a different username.";
        //            break;
        //        case -2:
        //            message = "Supplied email address has already been used.";
        //            break;
        //        default:
        //            message = "Registration successful.\\nUser Id: " + userId.ToString();
        //            break;
        //    }
        //    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
        //}
    }
}