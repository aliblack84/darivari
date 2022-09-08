using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Data.SqlClient; 
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class editProsudent : System.Web.UI.Page
{
    private SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=School;Integrated Security=True"); 
    private SqlCommand com =new SqlCommand(); 
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
            Session["ba2"] = dr["base"].ToString();

            
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Session.Remove("ba2");
        Response.Redirect("PageSchool.aspx"); 
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string sql="";
        string s1 = RadioButtonList1.SelectedValue;
        Panel2.Visible = true;
        if (TextBox1.Text != "")
        {
            sql = " "+s1+" id=" + TextBox1.Text; 
        }
        if (TextBox2.Text != "")
        {
            sql+=" "+s1+" name='" + TextBox2.Text+"'";
        }
        if (DropDownList1.SelectedValue !="" )
        {
            sql += " "+s1+" nameclass='" + DropDownList1.SelectedValue+"'";
        }
        if (DropDownList2.SelectedValue != "")
        {
            sql += " "+s1+" base=" + DropDownList1.SelectedValue ;
        }
        if (DropDownList3.SelectedValue != "")
        {
            sql += " "+s1+" resh=" + DropDownList1.SelectedValue ;

        }
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter("select id,name,name_f,yer,nameclass,tel,address from tblsudent where id_school=" + Session["id_s"].ToString() + sql,con);
        da.Fill(ds, "t1");
        GridView1.DataSource = ds.Tables["t1"];
        GridView1.DataBind(); 


    }
    protected void DropDownList2_PreRender(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DropDownList2.Items.Add("");
            DropDownList2.SelectedIndex = DropDownList2.Items.Count - 1;   
        }
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Session["base"].ToString() == "3")
        {
            if (DropDownList2.SelectedValue != "اول دبیرستان")
            {
                DropDownList3.Visible = true;
                Label5.Visible = true;
            }
            else
            {
                DropDownList3.Visible =false;
                Label5.Visible = false ;
            }
        }
    }
    protected void DropDownList1_PreRender(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DropDownList1.Items.Add("");
            DropDownList1.SelectedIndex = DropDownList1.Items.Count - 1;    
        }
    }
}
