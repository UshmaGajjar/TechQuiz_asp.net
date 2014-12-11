using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

public partial class questions : System.Web.UI.Page
{
    public DataTable dt1;
    public int category;
    public string user_name;
    public int user_id;
    public Random ra = new Random(DateTime.Now.Ticks.GetHashCode());
    public  List<int> id_list = new List<int>();
    public  List<int> qid_list = new List<int>();
  
    int no = 0;
    protected void Page_Init(object sender, EventArgs e)
    {
        
    }
    protected void Page_Load(object sender, EventArgs e)
    {
            user_name = Session["user_name"].ToString();
            user_id = Convert.ToInt32(Session["user_id"]);

            user.Text ="Logged in as | "+ user_name ;

        category = Convert.ToInt32(Session["category"]);
        CTechQuiz tq = new CTechQuiz();
        dt1 = new DataTable();
        dt1 = tq.getTable("SELECT * FROM question_bank WHERE category=" + category + "");

        if (!IsPostBack)
        {
         for (int i = 0; id_list.Count < 10; i++)
               NewNumber();
         id_list.Sort();
        }
        else
        {
            id_list = (List<int>)ViewState["vs_id"];
        }
        generate_controls();
    }
    public void generate_controls()
    {
        int i = 1;
        foreach (int n in id_list)
        //for (int n = 0; n < 10;n++ )
        {
            string q_id = dt1.Rows[n].ItemArray.GetValue(0).ToString();
            qid_list.Add(Convert.ToInt32(q_id));
            Literal breakline = new Literal();
            LiteralControl lc = new LiteralControl("<br>");

            Label lbl = new Label();
            lbl.ID = "que_id" + q_id;
            lbl.Text = " [ " + i + " ] ";
            ques_list.Controls.Add(lbl);
            ques_list.Controls.Add(breakline);

            Label lbl1 = new Label();
            lbl1.ID = "question" + q_id;
            lbl1.Text = dt1.Rows[n].ItemArray.GetValue(1).ToString();
            ques_list.Controls.Add(lbl1);
            ques_list.Controls.Add(breakline);

            RadioButtonList rd = new RadioButtonList();
            rd.ID = "options" + q_id;
            rd.Items.Add(new ListItem(" A. " + dt1.Rows[n].ItemArray.GetValue(2).ToString(), "A"));
            rd.Items.Add(new ListItem(" B. " + dt1.Rows[n].ItemArray.GetValue(3).ToString(), "B"));
            rd.Items.Add(new ListItem(" C. " + dt1.Rows[n].ItemArray.GetValue(4).ToString(), "C"));
            rd.Items.Add(new ListItem(" D. " + dt1.Rows[n].ItemArray.GetValue(5).ToString(), "D"));
            ques_list.Controls.Add(rd);
            ques_list.Controls.Add(breakline);
            ques_list.Controls.Add(lc);

            i++;
        }
       /* string s = "";
        foreach (int n in qid_list)
        {
           // RadioButtonList rd = (RadioButtonList)this.Page.FindControl("options" + n);
            s += "id : " + n + "           <br> " ;//+ "ans:     " + rd.SelectedValue + "<br>";
        }
        Label1.Text = s;*/
        ViewState["vs_id"] = id_list;
        ViewState["vs_qid"] = qid_list;
    }
    private void NewNumber()
    {
        no = ra.Next(0,14);
        if (!id_list.Contains(no))
        {
            id_list.Add(no);
        }
    }
    protected void submit_tq_Click(object sender, EventArgs e)
    {
        List<int> vs_qid_list = new List<int>();
        vs_qid_list = (List<int>)ViewState["vs_qid"];
        string s = "";
        SortedDictionary<int, string> sorted_qid = new SortedDictionary<int, string>();

        foreach(int n in vs_qid_list){
            RadioButtonList rd = (RadioButtonList)this.Page.FindControl("options"+n);
            sorted_qid.Add(n,rd.SelectedValue);
        }
       
        foreach (var qid in sorted_qid.Keys)
        {
            s += " id : " + qid + "  ans : " + sorted_qid[qid] + "<br>";
            //Response.Write(qid);
        }
        lbl.Text = s;
        Session["que_ans"] = sorted_qid;
        Response.Redirect("result.aspx");
    }

}