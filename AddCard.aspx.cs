using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
        int year = int.Parse("20" + ddListYear.SelectedValue);
        int month = int.Parse(ddListMonth.SelectedValue);
        expiration_date = new DateTime(year, month, DateTime.DaysInMonth(year, month));

        addCard();
    }

    protected void addCard()
    {
        // DB magic goes here
    }
}