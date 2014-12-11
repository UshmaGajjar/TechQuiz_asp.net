using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class user_home : System.Web.UI.Page
{
    public string user_name;
    public int user_id;
    protected void Page_Load(object sender, EventArgs e)
    {
        CTechQuiz ct = new CTechQuiz();
        DataSet ds = ct.getds("SELECT q.quiz_id,u.username,q.category,q.score,q.date_time FROM quiz_info q,user_info u WHERE q.user_id = u.user_id");

        GridView1.DataSource = ds;
        GridView1.DataBind();
      /*  user_name = Session["user_name"].ToString();
        user_id=Convert.ToInt32(Session["user_id"]);

        user.Text = "Welcome! "+user_name+" |";*/
    }
    protected void php_Click(object sender, EventArgs e)
    {
        Session["category"]=2;
        Response.Redirect("admin_questions.aspx");
    }
    protected void dotnet_Click(object sender, EventArgs e)
    {
        Session["category"] = 1;
        Response.Redirect("admin_questions.aspx");
    }
    protected void datamining_Click(object sender, EventArgs e)
    {
        Session["category"] = 3;
        Response.Redirect("admin_questions.aspx");
    }
}