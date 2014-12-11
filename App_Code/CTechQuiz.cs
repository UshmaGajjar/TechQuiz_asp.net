using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
/// <summary>
/// Summary description for CTechQuiz
/// </summary>
public class CTechQuiz
{
    public SqlConnection con;
    public SqlCommand cmd;
    public SqlDataAdapter sda;
    public DataSet ds;
    public DataTable dt;
    public int id;
    public CTechQuiz()
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["cn1"].ConnectionString);
    }
    public void dodml(string query)
    {

        con.Open();
        cmd = new SqlCommand("set dateformat 'dmy'",con);
        cmd.ExecuteNonQuery();
        cmd = new SqlCommand(query,con);
        cmd.ExecuteNonQuery();
        con.Close();
    }
    public DataTable getTable(string query)
    {
        con.Open();
        sda = new SqlDataAdapter(query,con);
        dt=new DataTable();
        sda.Fill(dt);
        con.Close();
        return dt;
    }
    public DataSet getds(string query)
    {
        con.Open();
        sda = new SqlDataAdapter(query,con);
        ds = new DataSet();
        sda.Fill(ds);
        con.Close();
        return ds;
    }
}