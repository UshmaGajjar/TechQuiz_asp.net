using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class user_signup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       /* Calendar c=new Calendar();
        string y=c.TodaysDate.Year.ToString();
        for (int i = 1920; i < Int32.Parse(y);i++)
            year.Items.Add(i.ToString());*/  
    }

    protected void signup_Click(object sender, EventArgs e)
    {
       CTechQuiz tq = new CTechQuiz();
       
       tq.dodml("INSERT INTO user_info (username,password,first_name,last_name,occupation,gender,birth_date,isActive,role) VALUES ('"+email.Text+"','"+passwd1.Text+"','"+fname.Text+"','"+lname.Text+"',"+occupation.SelectedValue+",'"+gender.SelectedValue+"','"+bdate.Text+"',1,1)");
       notify.Text="User added successfully";
       cleardata();
    }
    public void cleardata()
    {
        fname.Text = "";
        lname.Text = "";
        email.Text = "";
        passwd1.Text = "";
        passwd2.Text = "";
        occupation.SelectedIndex = 0;
        gender.ClearSelection();
        bdate.Text = "";
    }
    protected void reset_Click(object sender, EventArgs e)
    {
        cleardata();
    }
           
protected void Calendar1_SelectionChanged(object sender, EventArgs e)
{
     bdate.Text = Calendar1.SelectedDate.ToShortDateString();
}

}