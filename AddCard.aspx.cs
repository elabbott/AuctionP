using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;

public partial class AddCard : System.Web.UI.Page
{
    protected int user_id;
    protected string card_number;
    protected string owner_name;
    protected string ccv_number;
    protected DateTime expiration_date;

    protected void Page_Load(object sender, EventArgs e)
    {

        for (int i = 0; i <= 11; i++)
        {
            String year = (DateTime.Today.Year + i).ToString();
            ListItem li = new ListItem(year, year);
            ddListYear.Items.Add(li);
        }

        CompareValidatorExpire.ValueToCompare = Convert.ToString(DateTime.Now.Month);

        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        string username = HttpContext.Current.User.Identity.Name;
        
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT User_Id FROM User WHERE Username=@text";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@text", username);
                user_id = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {

            }
        }
    }


    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("User.aspx");
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        owner_name = txtName.Text;
        card_number = txtNum.Text;
        ccv_number = txtCCV.Text;
        int year = int.Parse(ddListYear.SelectedValue);
        int month = int.Parse(ddListMonth.SelectedValue);
        expiration_date = new DateTime(year, month, DateTime.DaysInMonth(year, month));

        addCard();
    }

    protected void addCard()
    {
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        int card_id;
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            using (MySqlCommand cmd = new MySqlCommand("Insert_CreditCard"))
            {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("UserID", user_id);
                    cmd.Parameters.AddWithValue("CardNumber", card_number);
                    cmd.Parameters.AddWithValue("OwnerName", owner_name);
                    cmd.Parameters.AddWithValue("CCVNumber", ccv_number);
                    cmd.Parameters.AddWithValue("Expiration", expiration_date);
                    cmd.Connection = con;
                    con.Open();
                    card_id = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
            }
            /*using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE CreditCard SET Card_Id=@card WHERE User_Id=@user";
                cmd.Parameters.AddWithValue("@card", card_id);
                cmd.Parameters.AddWithValue("@user", user_id);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }*/
        }
        Response.Redirect("User.aspx");
    }
}