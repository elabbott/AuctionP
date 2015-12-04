using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Web.UI.WebControls;

public partial class UserPage : System.Web.UI.Page
{
    protected string username;
    protected int user_id;
    protected double balance;
    protected double available_balance;
    protected int selectedCard;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.User.Identity.IsAuthenticated)
        {
            FormsAuthentication.RedirectToLoginPage();
        }
        username = HttpContext.Current.User.Identity.Name;
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            using (MySqlCommand cmd = new MySqlCommand("SELECT Balance, Available_Balance, User_Id FROM User WHERE Username=@name"))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@name", username);
                cmd.Connection = con;
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    balance = Convert.ToDouble(reader["Balance"]);
                    available_balance = Convert.ToDouble(reader["Available_Balance"]);
                    user_id = Convert.ToInt32(reader["User_Id"]);
                }
                con.Close();
            }

            using (MySqlCommand cmd = new MySqlCommand("SELECT Card_Number, Card_Id FROM CreditCard WHERE User_Id=@number"))
            {
                con.Open();
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@number", user_id);
                cmd.Connection = con;
                DataTable cards = new DataTable();
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                sda.Fill(cards);
                ddListCard.DataSource = cards;
                ddListCard.DataTextField = "Card_Number";
                ddListCard.DataValueField = "Card_Id";
                ddListCard.DataBind();
                con.Close();
            }
        }
        ddListCard.Items.Insert(0, new ListItem("--Select Card--", "0"));
        ddListCard.ClearSelection();
        lblBalance.Text = String.Format("{0:C}", balance);
        lblCurrentBids.Text = String.Format("{0:C}", balance-available_balance);
        lblAvailableBalance.Text = String.Format("{0:C}",available_balance);
    }

    protected void ddListCard_SelectedIndexChanged(object sender, EventArgs e)
    {
        selectedCard = Convert.ToInt32(ddListCard.SelectedValue);
    }

    protected void deposit()
    {
        if (txtAmount.Text != null)
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            MySqlConnection con = new MySqlConnection(constr);
            //update user balance and available balance
            using (MySqlCommand cmd = new MySqlCommand("UPDATE User SET Balance=Balance+@amount, Available_Balance=Available_Balance+@amount WHERE Username=@name"))
            {
                con.Open();
                cmd.CommandType = CommandType.Text;
                double amount = Convert.ToDouble(txtAmount.Text.Trim());
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.Parameters.AddWithValue("@name", username);
                cmd.Connection = con;
                cmd.ExecuteScalar();
                con.Close();
            }
            con.Dispose();
            Response.Redirect("User.aspx");
        }
    }

    protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
    {
        Response.Redirect("~/Search.aspx");
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/UserAuctions.aspx");
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("~Home.aspx");
    }

    protected void withdraw()
    {
        if(txtAmount.Text != null)
        {
            double amount = Convert.ToDouble(txtAmount.Text.Trim());
            if(amount <= available_balance)
            {
                string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                MySqlConnection con = new MySqlConnection(constr);
                //update user balance and available balance
                using (MySqlCommand cmd = new MySqlCommand("UPDATE User SET Balance=Balance-@amount, Available_Balance=Available_Balance-@amount WHERE Username=@name"))
                {
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Parameters.AddWithValue("@name", username);
                    cmd.Connection = con;
                    cmd.ExecuteScalar();
                    con.Close();
                }
                con.Dispose();
                Response.Redirect("User.aspx");
            }
        }
    }

    protected void rdBtnType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdBtnType.SelectedValue == "Withdraw")
        {
            CompareValidator2.Operator = ValidationCompareOperator.LessThanEqual;
            CompareValidator2.ValueToCompare = Convert.ToString(available_balance);
            CompareValidator2.Enabled = true;
        }
        else
        {
            CompareValidator2.Enabled = false;
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        double amount = Convert.ToDouble(txtAmount.Text.Trim());
        
        switch (rdBtnType.SelectedIndex)
        {
            case 0:
                deposit();
                break;
            case 1:
                if(amount <= balance)
                {
                    withdraw();
                }
                break;
            default:
                break;
        }
    }

    protected void lbSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("Search.aspx");
    }
}