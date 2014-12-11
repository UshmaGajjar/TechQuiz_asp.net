using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

public partial class admin_questions : System.Web.UI.Page
{

    public DataTable dt1;
    public DataSet ds1;
    public int category;
    public string user_name;
    public int user_id;
    public Random ra = new Random(DateTime.Now.Ticks.GetHashCode());
    public List<int> id_list = new List<int>();
    public List<int> qid_list = new List<int>();

    int no = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        user_name = Session["user_name"].ToString();
        user_id = Convert.ToInt32(Session["user_id"]);

       // user.Text = "Logged in as | " + user_name;

        category = Convert.ToInt32(Session["category"]);
        if(!IsPostBack)
         load_data();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        load_data();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        string qque_id = ((Label)GridView1.Rows[e.RowIndex] .FindControl("q_id")).Text;
        string qquestion = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("e_question")).Text;
        string qoption1 = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("e_option1")).Text;
        string qoption2 = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("e_option2")).Text;
        string qoption3 = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("e_option3")).Text;
        string qoption4 = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("e_option4")).Text;
        string qanswer = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("e_answer")).Text;
        string qcategory = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("e_category")).Text;
        CheckBox qisd = (CheckBox)GridView1.Rows[e.RowIndex].FindControl("e_isdeleted");
         string qisdeleted="";
        if( qisd.Checked == true)
             qisdeleted ="true";
        else
            qisdeleted = "false";
        //Response.Write("UPDATE question_bank SET question='" + qquestion + "', option1='" + qoption1 + "', option2='" + qoption2 + "', option3='" + qoption3 + "', option4='" + qoption4 + "', answer='" + qanswer + "', category =" + qcategory + ", isDeleted='" + qisdeleted + "' WHERE que_id=" + qque_id + ";");
        
        GridView1.EditIndex = -1;
        CTechQuiz tq = new CTechQuiz();
        tq.dodml("UPDATE question_bank SET question='" + qquestion + "', option1='" + qoption1 + "', option2='" + qoption2 + "', option3='" + qoption3 + "', option4='" + qoption4 + "', answer='" + qanswer + "', category =" + qcategory + ", isDeleted='" + qisdeleted + "' WHERE que_id=" + qque_id + ";");
        load_data();
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        load_data();
    }
    public void load_data()
    {
        CTechQuiz tq = new CTechQuiz();
        ds1 = new DataSet();
        ds1 = tq.getds("SELECT * FROM question_bank WHERE category=" + category + " AND isDeleted=0;");

        GridView1.DataSource = ds1;
        GridView1.DataBind();
    }
    protected void add_question(object sender, EventArgs e)
    {
        string qquestion = ((TextBox)GridView1.FooterRow.FindControl("question")).Text;
        string qoption1 = ((TextBox)GridView1.FooterRow.FindControl("option1")).Text;
        string qoption2 = ((TextBox)GridView1.FooterRow.FindControl("option2")).Text;
        string qoption3 = ((TextBox)GridView1.FooterRow.FindControl("option3")).Text;

        string qoption4 = ((TextBox)GridView1.FooterRow.FindControl("option4")).Text;
        string qanswer = ((TextBox)GridView1.FooterRow.FindControl("answer")).Text;

        string qcategory = ((TextBox)GridView1.FooterRow.FindControl("category")).Text;

        CheckBox qisd = (CheckBox)GridView1.FooterRow.FindControl("isdeleted");
        string qisdeleted = "";
        if (qisd.Checked == true)
            qisdeleted = "true";
        else
            qisdeleted = "false";

        CTechQuiz tq = new CTechQuiz();
        tq.dodml("INSERT INTO question_bank VALUES (NULL,'" + qquestion + "','" + qoption1 + "','" + qoption2 + "','" + qoption3 + "','" + qoption4 + "','" + qanswer + "'," + qcategory + ",'" + qisdeleted + "';");
        load_data();

    }
}