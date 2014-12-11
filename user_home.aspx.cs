using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_home : System.Web.UI.Page
{
    public string user_name;
    public int user_id;
    protected void Page_Load(object sender, EventArgs e)
    {
       user_name = Session["user_name"].ToString();
        user_id=Convert.ToInt32(Session["user_id"]);

        user.Text = "Welcome! "+user_name+" |";
    }
    protected void php_Click(object sender, EventArgs e)
    {
        Session["category"]=2;
        Response.Redirect("questions.aspx");
    }
    protected void dotnet_Click(object sender, EventArgs e)
    {
        Session["category"] = 1;
        Response.Redirect("questions.aspx");
    }
    protected void datamining_Click(object sender, EventArgs e)
    {
        Session["category"] = 3;
        Response.Redirect("questions.aspx");
    }
}