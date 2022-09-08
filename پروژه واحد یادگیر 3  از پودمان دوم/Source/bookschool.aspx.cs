using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient; 
using System.Web.UI.HtmlControls;

public partial class bookschool : System.Web.UI.Page
{
    private SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=School;Integrated Security=True"); 
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string txt1="",rd;
        Panel2.Visible = true; 
        
        rd = r2.SelectedValue;
        if (txtteacher.Text != "")
        {
            txt1 = txt1 + " " + rd + " tblteacher.name='" + txtteacher.Text + "'"; 
        }
        if (txtnamesch.Text != "")
        {
            txt1 = txt1 +" "+ rd + " tblschool.ns='" + txtnamesch.Text + "'"; 
        }
        if (txtnameman.Text !="" )
        {
            txt1 = txt1 + " " + rd + " tblschool.nm='" + txtnameman.Text + "'"; 
        }
        if (txtarea.Text != "")
        {
            txt1 = txt1 + " " + rd + " tblschool.area=" + txtarea.Text;  
        }
        if (txtaddress.Text != "")
        {
            txt1 =txt1 + " "+ rd + " tblschool.address like '%" + txtaddress.Text + "%'";   
        }
        SqlDataAdapter da = new SqlDataAdapter("SELECT distinct(tblschool.ns), tblschool.nm, tblschool.s, tblschool.address, tblschool.area, tblschool.tel, tblschool.namecity FROM tblteacher right JOIN tblschool ON tblteacher.id_school = tblschool.id where tblschool.base='" + dr1.SelectedValue + "' " + rd + " tblschool.s=" + r1.SelectedValue + " " + rd + " tblschool.namecity='" + dr2.SelectedValue + "' " + txt1, con);
        DataSet ds = new DataSet();
        da.Fill(ds, "tbl");
        DataTable dt = ds.Tables["tbl"];
        GridView1.DataSource = dt;
        GridView1.DataBind();
        if (GridView1.Rows.Count > 0)
        {
            GridView1.HeaderRow.Cells[1].Text = "نام مدرسه";
            GridView1.HeaderRow.Cells[2].Text = "نام مدیر";
            GridView1.HeaderRow.Cells[3].Text = "دخترانه";
            GridView1.HeaderRow.Cells[4].Text = "آدرس";
            GridView1.HeaderRow.Cells[5].Text = "منطقه";
            GridView1.HeaderRow.Cells[6].Text = "شماره تلفن";
            GridView1.HeaderRow.Cells[7].Text = "نام شهر";
        }
        
        
 
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
         
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int i = int.Parse(e.CommandArgument.ToString()); 
        SqlCommand com = new SqlCommand();
        com.CommandText = "select id from tblschool where ns='"+GridView1.Rows[i].Cells[1].Text+"' and nm='"+GridView1.Rows[i].Cells[2].Text+"' and tel='"+GridView1.Rows[i].Cells[6].Text+"' and namecity='"+GridView1.Rows[i].Cells[7].Text+"'";
        com.Connection = con;
        con.Open ();
        SqlDataReader dr = com.ExecuteReader();
        dr.Read();
        Session.Add("id_s", dr["id"].ToString());
        Response.Redirect("bookpro.aspx");  
          
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");  
    }
}
