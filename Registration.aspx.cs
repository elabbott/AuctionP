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

    protected void RegisterUser2(object sender, EventArgs e)
    {
        int user_Id;
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
                    user_Id = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
            }
            string message = string.Empty;
            switch (user_Id)
            {
                case -1:
                    message = "Username already exists.\\nPlease choose a different username.\\n" + txtUsername.Text;
                    break;
                case -2:
                    message = "Supplied email address has already been used.";
                    break;
                default:
                    message = "Registration successful.\\nUser Id: " + user_Id/*.ToString()*/;
                    SendActivationEmail(user_Id);//line 81
                    break;
            }
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
        }
    }
    // this isn't quite working look at line 75 for some reason it is passing in the integer 0 instead of the userId
    private void SendActivationEmail(int user_Id)
    {
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        string activation_Code = Guid.NewGuid().ToString();
        //string message = "The activation code: " + activation_Code + "\\n The User_Id: " + user_Id;
        //ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            //using (MySqlCommand cmd = new MySqlCommand("INSERT INTO User_Activation VALUES(_User_Id, _Activation_Code)"))
            using (MySqlCommand cmd = new MySqlCommand("User_Activation"))
            {
                using (MySqlDataAdapter sda = new MySqlDataAdapter())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("_User_Id", user_Id);
                    cmd.Parameters.AddWithValue("_Activation_Code", activation_Code);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();                                        
                }
            }
        }
        using (MailMessage mm = new MailMessage("auctionpowers2015fall@gmail.com", txtEmail.Text))
        {
            mm.Subject = "Account Activation";
            string body = "Hello " + txtUsername.Text.Trim() + ",";
            body += "<br /><br />Please click the following link to activate your account";
            body += "<br /><a href = '" + Request.Url.AbsoluteUri.Replace("Registration.aspx", "Activation.aspx?Activation_Code=" + activation_Code) + "'>Click here to activate your account.</a>";
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