using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

public partial class result : System.Web.UI.Page
{
    public SortedDictionary<int, string> qid_ans = new SortedDictionary<int, string>();
    public DataTable dt1;
    public int category;
    public int score=0;
    public string s;
    public ArrayList ar = new ArrayList();
    public string user_name;
    public int user_id;

    protected void Page_Load(object sender, EventArgs e)
    {
        user_name = Session["user_name"].ToString();
        user_id = Convert.ToInt32(Session["user_id"]);

        category = Convert.ToInt32(Session["category"]);
        qid_ans = (SortedDictionary<int, string>)Session["que_ans"];
        string s = string.Join(",", qid_ans.Select(x => x.Key).ToArray());
             
        CTechQuiz tq = new CTechQuiz();
        dt1 = new DataTable();
        dt1 = tq.getTable("SELECT * FROM question_bank WHERE que_id IN ("+s+") AND category=" + category + "");

       // Response.Write(dt1.Rows.Count);
        generate_controls();
        Response.Write("Score : "+ score);
        

        //tq.dodml("INSERT INTO quiz_info VALUES (NULL,"+user_id+",,"+category+","+score+" / 10)");
    }
    public void generate_controls()
    {
        int n = 0;
        foreach (int qid in qid_ans.Keys)
        {
            string q_id = dt1.Rows[n].ItemArray.GetValue(0).ToString();
         
            Literal breakline = new Literal();
            LiteralControl lc = new LiteralControl("<br>");

            Label lbl = new Label();
            lbl.ID = "que_id" + q_id;
            lbl.Text = " [ " + (n+1) + " ] ";
            result_list.Controls.Add(lbl);
            //result_list.Controls.Add(lc);

            Label lbl1 = new Label();
            lbl1.ID = "question" + q_id;
            lbl1.Text = dt1.Rows[n].ItemArray.GetValue(1).ToString();
            result_list.Controls.Add(lbl1);
            result_list.Controls.Add(lc);

            Label opt1 = new Label();
            opt1.ID = "option1_" + q_id;
            opt1.Text = " A. " + dt1.Rows[n].ItemArray.GetValue(2).ToString();
            result_list.Controls.Add(opt1);
            result_list.Controls.Add(new LiteralControl("<br>"));

            Label opt2 = new Label();
            opt2.ID = "option2_" + q_id;
            opt2.Text = " B. " + dt1.Rows[n].ItemArray.GetValue(3).ToString();
            result_list.Controls.Add(opt2);
            result_list.Controls.Add(new LiteralControl("<br>"));

            Label opt3 = new Label();
            opt3.ID = "option3_" + q_id;
            opt3.Text = " C. " + dt1.Rows[n].ItemArray.GetValue(4).ToString();
            result_list.Controls.Add(opt3);
            result_list.Controls.Add(new LiteralControl("<br>"));

            Label opt4 = new Label();
            opt4.ID = "option4_" + q_id;
            opt4.Text = " D. " + dt1.Rows[n].ItemArray.GetValue(5).ToString();
            result_list.Controls.Add(opt4);
            result_list.Controls.Add(new LiteralControl("<br>"));
            result_list.Controls.Add(new LiteralControl("<br>"));

            Label c_ans = new Label();
            c_ans.ID = "c_ans" + q_id;
            c_ans.Text = " Correct Answer : " + dt1.Rows[n].ItemArray.GetValue(6).ToString();
            result_list.Controls.Add(c_ans);
            result_list.Controls.Add(new LiteralControl("<br>"));

            Label u_ans = new Label();
            u_ans.ID = "u_ans" + q_id;
            if(qid_ans[qid] == "")
                u_ans.Text = " Your Answer : no answer";
            else
                u_ans.Text = " Your Answer : " + qid_ans[qid];
            result_list.Controls.Add(u_ans);

            result_list.Controls.Add(new LiteralControl("<br>"));
            result_list.Controls.Add(new LiteralControl("<br>"));
            result_list.Controls.Add(new LiteralControl("<hr width='70%'>"));

            if (dt1.Rows[n].ItemArray.GetValue(6).ToString().Equals(qid_ans[qid]))
                score++;

            n++;           
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        create_result();

        Byte[] bytes=System.Text.Encoding.UTF8.GetBytes(s);
        Response.Clear();
        Response.ContentType = "application/octet-stream";
        Response.AddHeader("Content-Disposition","attachment; filename=quiz_result.doc");
        Response.Buffer = true;
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.BinaryWrite(bytes);

        Response.End();
        Response.Close(); ;
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        create_result();

        Document document = new Document(PageSize.A4, 88f, 88f, 10f, 10f);
        Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL, Color.BLACK);
        using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
        {
            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
            Phrase phrase = null;
            PdfPCell cell = null;
            PdfPTable table = null;
            Color color = null;

            document.Open();

            //Header Table
            table = new PdfPTable(2);
            table.TotalWidth = 500f;
            table.LockedWidth = true;
            table.SetWidths(new float[] { 0.3f, 0.7f });

            //quiz Logo
            cell = ImageCell("~/images/TechQuiz.png", 30f, PdfPCell.ALIGN_CENTER);
            table.AddCell(cell);

            phrase = new Phrase();
            phrase.Add(new Chunk("\nTECH QUIZ - result\n\n\n\n", FontFactory.GetFont("Arial", 16, Font.BOLD, Color.BLACK)));
            cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
            cell.VerticalAlignment = PdfCell.ALIGN_TOP;
            table.AddCell(cell);

            //Separater Line
            color = new Color(System.Drawing.ColorTranslator.FromHtml("#A9A9A9"));
            DrawLine(writer, 25f, document.Top - 79f, document.PageSize.Width - 25f, document.Top - 79f, color);
            DrawLine(writer, 25f, document.Top - 80f, document.PageSize.Width - 25f, document.Top - 80f, color);
            document.Add(table);

            table = new PdfPTable(2);
            table.HorizontalAlignment = Element.ALIGN_LEFT;
            table.SetWidths(new float[] { 0.3f, 1f });
            table.SpacingBefore = 20f;


            cell = PhraseCell(new Phrase("SCORE : "+score, FontFactory.GetFont("Arial", 12, Font.BOLD, Color.BLACK)), PdfPCell.ALIGN_LEFT);
            cell.Colspan = 2;
            table.AddCell(cell);
            cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
            cell.Colspan = 2;
            cell.PaddingBottom = 30f;
            table.AddCell(cell);

            cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
            table.AddCell(cell);

            document.Add(table);

            table = new PdfPTable(1);
            table.SetWidths(new float[] { 2.5f });
            table.TotalWidth = 340f;
            table.LockedWidth = true;
            table.SpacingBefore = 20f;
            table.HorizontalAlignment = Element.ALIGN_LEFT;

            //Employee Id
            for (int k = 0; k < ar.Count; k++)
            {
                table.AddCell(PhraseCell(new Phrase("" + ar[k], FontFactory.GetFont("Arial", 8, Font.NORMAL, Color.BLACK)), PdfPCell.ALIGN_LEFT));
                cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                cell.PaddingBottom = 10f;
                table.AddCell(cell);
            }

            document.Add(table);
            document.Close();
            byte[] bytes = memoryStream.ToArray();
            memoryStream.Close();
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment; filename=quiz_result.pdf");
            Response.ContentType = "application/pdf";
            Response.Buffer = true;
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(bytes);
            Response.End();
            Response.Close();
        }
    }
    private static void DrawLine(PdfWriter writer, float x1, float y1, float x2, float y2, Color color)
    {
        PdfContentByte contentByte = writer.DirectContent;
        contentByte.SetColorStroke(color);
        contentByte.MoveTo(x1, y1);
        contentByte.LineTo(x2, y2);
        contentByte.Stroke();
    }
    private static PdfPCell PhraseCell(Phrase phrase, int align)
    {
        PdfPCell cell = new PdfPCell(phrase);
        cell.BorderColor = Color.WHITE;
        cell.VerticalAlignment = PdfCell.ALIGN_TOP;
        cell.HorizontalAlignment = align;
        cell.PaddingBottom = 2f;
        cell.PaddingTop = 0f;
        return cell;
    }
    private static PdfPCell ImageCell(string path, float scale, int align)
    {
        iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));
        image.ScalePercent(scale);
        PdfPCell cell = new PdfPCell(image);
        cell.BorderColor = Color.WHITE;
        cell.VerticalAlignment = PdfCell.ALIGN_TOP;
        cell.HorizontalAlignment = align;
        cell.PaddingBottom = 0f;
        cell.PaddingTop = 0f;
        return cell;
    }

    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        FileInfo f = new FileInfo(Server.MapPath("~/files/quiz_result.txt"));
        if (!f.Exists)
        {
            write_txt();
        }
        else
        {
            f.Delete();
            write_txt();
        }
         string path = Server.MapPath("~/files/quiz_result.txt"); //get file object as FileInfo  
         FileInfo file = new System.IO.FileInfo(path); //-- if the file exists on the server  

         if ( file.Exists ) //set appropriate headers  
         {
             Response.Clear();
             Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
             Response.AddHeader("Content-Length", file.Length.ToString());
             Response.ContentType = "application/octet-stream";

             // write file to browser
             Response.WriteFile(file.FullName);
             Response.End();
         }
    }
    public void create_result()
    {
        s = "<h2 align='center'> QUIZ RESULT </h2>";
        s = " Score : " + score + "<br>";

        foreach (int qid in qid_ans.Keys)
        {
            Label lbl_qid = (Label)this.Page.FindControl("que_id" + qid);
            Label lbl_que = (Label)this.Page.FindControl("question" + qid);
            Label opt1 = (Label)this.Page.FindControl("option1_" + qid);
            Label opt2 = (Label)this.Page.FindControl("option2_" + qid);
            Label opt3 = (Label)this.Page.FindControl("option3_" + qid);
            Label opt4 = (Label)this.Page.FindControl("option4_" + qid);
            Label lbl_cans = (Label)this.Page.FindControl("c_ans" + qid);
            Label lbl_uans = (Label)this.Page.FindControl("u_ans" + qid);

            s += lbl_qid.Text + lbl_que.Text + " <br> ";
            s += opt1.Text + "<br>";
            s += opt2.Text + "<br>";
            s += opt3.Text + "<br>";
            s += opt4.Text + "<br><br>";
            s += lbl_cans.Text + "<br>";
            s += lbl_uans.Text + "<br><br>";

            ar.Add(lbl_qid.Text + lbl_que.Text);
            ar.Add(opt1.Text);
            ar.Add(opt2.Text);
            ar.Add(opt3.Text);
            ar.Add(opt4.Text);
            ar.Add(lbl_cans.Text);
            ar.Add(lbl_uans.Text);
         }
        Label1.Text = s;
    }
    public void write_txt()
    {
        StreamWriter sw = File.CreateText(Server.MapPath("~/files/quiz_result.txt"));
        sw.WriteLine(" QUIZ RESULT ");
        sw.WriteLine(" Score : " + score);

        foreach (int qid in qid_ans.Keys)
        {
            Label lbl_qid = (Label)this.Page.FindControl("que_id" + qid);
            Label lbl_que = (Label)this.Page.FindControl("question" + qid);
            Label opt1 = (Label)this.Page.FindControl("option1_" + qid);
            Label opt2 = (Label)this.Page.FindControl("option2_" + qid);
            Label opt3 = (Label)this.Page.FindControl("option3_" + qid);
            Label opt4 = (Label)this.Page.FindControl("option4_" + qid);
            Label lbl_cans = (Label)this.Page.FindControl("c_ans" + qid);
            Label lbl_uans = (Label)this.Page.FindControl("u_ans" + qid);

            sw.WriteLine(" [ " + qid + " ] " + lbl_que.Text);
            sw.WriteLine(opt1.Text);
            sw.WriteLine(opt2.Text);
            sw.WriteLine(opt3.Text);
            sw.WriteLine(opt4.Text);
            sw.WriteLine(lbl_cans.Text);
            sw.WriteLine(lbl_uans.Text);
        }
        sw.Close();
    }
}