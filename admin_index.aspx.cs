using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class admin_index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void login_Click(object sender, EventArgs e)
    {
        CTechQuiz tq = new CTechQuiz();

        DataTable dt = tq.getTable("SELECT user_id FROM user_info WHERE username='" + uname.Text + "' AND password='" + password.Text + "'");

        if (dt.Rows.Count == 0)
            notify.Text = "Username or password donot match";
        else
        {
            Session["user_id"] = dt.Rows[0].ItemArray.GetValue(0);
            Session["user_name"] = uname.Text.Substring(0, uname.Text.IndexOf('@'));
            Response.Redirect("admin_home.aspx");
        }
    }
}