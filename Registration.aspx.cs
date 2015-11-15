using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Net.Mail;
using System.Net;

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
    }
    protected void RegisterUser2(object sender, EventArgs e)
    {
        int userId = 0;
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            using (MySqlCommand cmd = new MySqlCommand("Insert_User"))
            {
                using (MySqlDataAdapter sda = new MySqlDataAdapter())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Username", txtUsername.Text.Trim());
                    cmd.Parameters.AddWithValue("Pass", txtPassword.Text.Trim());
                    cmd.Parameters.AddWithValue("Email", txtEmail.Text.Trim());
                    cmd.Connection = con;
                    con.Open();
                    userId = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
            }
            string message = string.Empty;
            switch (userId)
            {
                case -1:
                    message = "Username already exists.\\nPlease choose a different username.\\n" + txtUsername.Text;
                    break;
                case -2:
                    message = "Supplied email address has already been used.";
                    break;
                default:
                    message = "Registration successful.\\nUser Id: " + userId.ToString();
                    SendActivationEmail(userId);//line 81
                    break;
            }
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
        }
    }
    // this isn't quite working look at line 75 for some reason it is passing in the integer 0 instead of the userId
    private void SendActivationEmail(int userId)
    {
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        string activationCode = Guid.NewGuid().ToString();
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            using (MySqlCommand cmd = new MySqlCommand("INSERT INTO User_Activation VALUES(User_Id, Activation_Code)"))
            {
                using (MySqlDataAdapter sda = new MySqlDataAdapter())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("User_Id", userId);
                    cmd.Parameters.AddWithValue("Activation_Code", activationCode);
                    cmd.Connection = con;
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (MySqlException e)
                    {
                        Console.Write(e.ToString() + userId);
                    }
                    finally
                    {
                        con.Close();
                    }                    
                }
            }
        }
        using (MailMessage mm = new MailMessage("auctionpowers2015fall@gmail.com", txtEmail.Text))
        {
            mm.Subject = "Account Activation";
            string body = "Hello " + txtUsername.Text.Trim() + ",";
            body += "<br /><br />Please click the following link to activate your account";
            body += "<br /><a href = '" + Request.Url.AbsoluteUri.Replace("Registration.aspx", "Activation.aspx?Activation_Code=" + activationCode) + "'>Click here to activate your account.</a>";
            body += "<br /><br />Thanks";
            mm.Body = body;
            mm.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            NetworkCredential NetworkCred = new NetworkCredential("auctionpowers2015fall@gmail.com", "auctionp1");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;
            smtp.Send(mm);
        }
    }
}