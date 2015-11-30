using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddCard : System.Web.UI.Page
{
    protected string name;
    protected string number;
    protected string ccv;
    protected string date;

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
        name = txtName.Text;
        number = txtNum.Text;
        ccv = txtCCV.Text;
        int year = int.Parse("20" + ddListYear.SelectedValue);
        int month = int.Parse(ddListMonth.SelectedValue);
        DateTime expiration = new DateTime(year, month, DateTime.DaysInMonth(year, month));
        date = expiration.ToString();

        addCard();
    }

    protected void addCard()
    {
        // DB magic goes here
    }
}