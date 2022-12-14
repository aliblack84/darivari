using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Data.SqlClient; 
using System.Web.Security;
using System.Web.UI;
using System.Globalization;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class program : System.Web.UI.Page
{
    private SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=School;Integrated Security=True");
    private SqlCommand com = new SqlCommand();
    private DateTime dt = DateTime.Now;
    private PersianCalendar pc = new PersianCalendar();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            con.Open();
            com.CommandText = "select base,ns from tblschool where id=" + Session["id_s"].ToString();
            com.Connection = con;
            SqlDataReader dr = com.ExecuteReader();
            dr.Read();
            lbltitr.Text = "آموزشگاه" + " " + dr["ns"].ToString();
        }

    }
    
    
    protected void DropDownList1_PreRender(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
             
            DropDownList1.Items.Add(" ");
            DropDownList1.SelectedIndex  = DropDownList1.Items .Count -1 ;
            Session["fdg"] = DropDownList1.SelectedValue;
        }
        

    }


    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Panel2.Visible = false;

        if (DropDownList1.SelectedValue != " ")
        {
            com.Connection = con;
            con.Open();
            com.CommandText = "SELECT  Lesson.name FROM tblteach INNER JOIN Lesson ON tblteach.id_l =Lesson.code where tblteach.id_t=" + Session["id_t"].ToString() + " and tblteach.name=" + DropDownList1.SelectedValue + " and id_s=" + Session["id_s"].ToString();
            SqlDataSource1.SelectCommand = com.CommandText;
            SqlDataSource1.DataBind();
            DropDownList2.Enabled = true;

        }
        else
        {
            
            DropDownList2.Enabled = false;
            DropDownList3.Enabled = false;
        }
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        Panel2.Visible = false;
        if (DropDownList2.SelectedValue != " ")
        {
            DropDownList3.Enabled = true;
            DropDownList3.Items.Clear();
            DropDownList3.Items.Add("");

            if (pc.GetMonth(dt) < 6)
            {
                dt = pc.AddYears(dt, -1);
            }
            con.Open();
            com.Connection = con;

            com.CommandText = "select id_l from tblteach where id_s=" + Session["id_s"].ToString() + " and name='" + DropDownList1.SelectedValue + "' and id_l=(select code from lesson where id_school=" + Session["id_s"].ToString() + " and name='" + DropDownList2.SelectedValue + "')";
            SqlDataReader dr = com.ExecuteReader();
            dr.Read();
            Session.Add("id_l", dr["id_l"].ToString());
            dr.Close();
            com.CommandText = "select * from tblmark where mark1<>'' and id_school=" + Session["id_s"] + " and id_lesson=" + Session["id_l"].ToString() + " and yer=" + pc.GetYear(dt);
            dr = com.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                DropDownList3.Items.Add("اول");

            }
            dr.Close();
            com.CommandText = "select * from tblmark where mark2<>'' and id_school=" + Session["id_s"] + " and id_lesson=" + Session["id_l"].ToString() + " and yer=" + pc.GetYear(dt);
            dr = com.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                DropDownList3.Items.Add("دوم");

            }
        }
        else
        {
            
            DropDownList3.Enabled =false;
        }

        

    }
    protected void DropDownList2_PreRender(object sender, EventArgs e)
    {
        if (IsPostBack==false  || DropDownList1.SelectedValue != Session["fdg"].ToString() )
        {
            Session["fdg"] = DropDownList1.SelectedValue;
            DropDownList2.Items.Add(" ");
            DropDownList2.SelectedIndex  = DropDownList2.Items .Count -1 ;
        }
    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList3.SelectedValue != "")
        {
            if (pc.GetMonth(dt) < 6)
            {
                dt = pc.AddYears(dt, -1);
            }
            Panel2.Visible = true;
            if (DropDownList3.SelectedValue == "اول")
            {
                com.CommandText = "SELECT tblsudent.id,tblsudent.name,tblmark.mark1 FROM tblmark INNER JOIN tblteach ON tblmark.Id_lesson =tblteach.id_l INNER JOIN tblsudent ON tblmark.id_su =tblsudent.id where tblmark.id_school=" + Session["id_s"].ToString() + " and tblsudent.nameclass='" + DropDownList1.SelectedValue + "' and tblmark.yer=" + pc.GetYear(dt) + " and tblmark.id_lesson=" + Session["id_l"].ToString();
            }
            else if (DropDownList3.SelectedValue == "دوم")
            {
                com.CommandText = "SELECT tblsudent.id,tblsudent.name,tblmark.mark2 FROM tblmark INNER JOIN tblteach ON tblmark.Id_lesson =tblteach.id_l INNER JOIN tblsudent ON tblmark.id_su =tblsudent.id where tblmark.id_school=" + Session["id_s"].ToString() + " and tblsudent.nameclass='" + DropDownList1.SelectedValue + "' and tblmark.yer=" + pc.GetYear(dt) + " and tblmark.id_lesson=" + Session["id_l"].ToString();
            }

            SqlDataAdapter da = new SqlDataAdapter(com.CommandText, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "t1");
            GridView1.DataSource = ds.Tables["t1"];
            GridView1.DataBind();
            DataRow dr1;
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                dr1 = ds.Tables["t1"].Rows[i];
                TextBox tb = (TextBox)GridView1.Rows[i].FindControl("TextBox1");

                if (DropDownList3.SelectedValue == "اول")
                {
                    tb.Text = dr1["mark1"].ToString();
                }
                else if (DropDownList3.SelectedValue == "دوم")
                {
                    tb.Text = dr1["mark2"].ToString();
                }
            }
        }
        else
            Panel2.Visible = false;

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Session.Remove("id_l");
        Response.Redirect("PageSchool.aspx"); 
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        com.Connection = con;
        con.Open();
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            
            TextBox tb = (TextBox)GridView1.Rows[i].FindControl("TextBox1");

            if (DropDownList3.SelectedValue == "اول")
            {
                com.CommandText = "update tblmark set mark1="+tb.Text  +" where id_su="+GridView1.Rows[i].Cells [3].Text;
            }
            else if (DropDownList3.SelectedValue == "دوم")
            {
                com.CommandText = "update tblmark set mark2=" + tb.Text + " where id_su=" + GridView1.Rows[i].Cells[3].Text;
                
            }
            com.ExecuteNonQuery();
              
        }
        Button1.Enabled = false;
        Panel2.Visible = false;
        Panel3.Visible = true;

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Panel3.Visible = false;
        Button1.Enabled = true;
        DropDownList2.SelectedIndex = DropDownList2.Items.Count - 1;
        DropDownList1.SelectedIndex = DropDownList1.Items.Count - 1;
        DropDownList3.Items.Clear();
        DropDownList3.Items.Add("");
        DropDownList2.Enabled = false;
        DropDownList3.Enabled = false; 
    }
}
