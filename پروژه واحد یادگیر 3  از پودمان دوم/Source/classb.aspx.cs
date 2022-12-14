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

public partial class classb : System.Web.UI.Page
{
    private SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=School;Integrated Security=True");
    private SqlCommand com = new SqlCommand();
    private int i1;
    private DataSet ds = new DataSet();
    private int resh1;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            Session.Add("sql", "tt");
            con.Open();
            com.CommandText = "select base,ns from tblschool where id=" + Session["id_s"].ToString();
            com.Connection = con;
            SqlDataReader dr = com.ExecuteReader();
            dr.Read();
            lbltitr.Text = "آموزشگاه" + " " + dr["ns"].ToString();
            int base1 = int.Parse(dr["base"].ToString());
            Session.Add("ba1", dr["base"].ToString());
        }
    }
 
    private void fillgrid()
    {
        com.CommandText = "select base,resh from tblclass2 where id_s=" + Session["id_s"].ToString() + " and name='" + DropDownList3.SelectedValue + "'";
        SqlDataReader dr = com.ExecuteReader();
        dr.Read();
        resh1 = int.Parse(dr["resh"].ToString ());
        i1 = int.Parse(dr["base"].ToString ());
        dr.Close();
        SqlDataAdapter da = new SqlDataAdapter("select name,avr,enz from tblsudent where nameclass='qw'and id_school=" + Session["id_s"].ToString() + " and resh=" +resh1+ " and base=" + i1  , con);
        Session["sql"] =" select * from tblsudent where nameclass='qw' and id_school=" + Session["id_s"].ToString() + " and resh=" +resh1+ " and base=" + i1 ;
        Session["sql1"] = " select name,avr,enz from tblsudent where nameclass='qw' and id_school=" + Session["id_s"].ToString() + " and resh=" + resh1 + " and base=" + i1;
        
        DataSet ds = new DataSet();
        da.Fill(ds, "t1");
        GridView1.DataSource = ds;
        GridView1.DataBind();

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        com.Connection = con;
        con.Open();
        SqlDataAdapter da =new SqlDataAdapter(Session["sql"].ToString(),con);
        da.Fill(ds, "t2");
        DataRow dr;
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            dr = ds.Tables["t2"].Rows[i];
            CheckBox cb = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
            if (cb.Checked == true)
            {
                
                
                int id = int.Parse(dr["id"].ToString());
                com.CommandText = "update tblsudent set nameclass='"+DropDownList3.SelectedValue+"' where id="+dr["id"].ToString();
                com.ExecuteNonQuery();

                  
                
                
            }
        }
        SqlDataAdapter da1 = new SqlDataAdapter(Session["sql1"].ToString(), con);
        da1.Fill(ds, "t3");
        GridView1.DataSource = ds.Tables["t3"];
        GridView1.DataBind();
        
        
          
    }
    protected void DropDownList3_PreRender(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DropDownList3.Items.Add(" ");
            DropDownList3.SelectedIndex = DropDownList3.Items.Count -1  ; 
        }
    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        com.CommandText = "select base,resh from tblclass2 where id_s=" + Session["id_s"].ToString()+" and name='"+DropDownList3.SelectedValue+"'";
        con.Open();
        com.Connection = con;
        SqlDataReader dr = com.ExecuteReader();
        dr.Read();
        getbase(int.Parse(dr["base"].ToString()));
        if (int.Parse(dr["resh"].ToString()) > 1)
        {
            TextBox2.Visible = true;
            Label3.Visible = true;
            setresh(int.Parse(dr["resh"].ToString()));
            
        }
        else
        {
            TextBox2.Visible = false;
            Label3.Visible = false; 
        }
        dr.Close();
        fillgrid();
    }
    private void getbase(int y)
    {
        int b = int.Parse(Session["ba1"].ToString());
        if (b == 3)
        {
            switch (y)
            {
                case 1:
                    TextBox1.Text = "اول دبیرستان";
                    break;
                case 2:
                    TextBox1.Text = "دوم دبرستان";
                    break;
                case 3:
                    TextBox1.Text = "سوم دبیرستان";
                    break;
                case 4:
                    TextBox1.Text = "پیش دانشگاهی";
                    break;

            }
        }
        else if (b == 2)
        {
            switch (y)
            {
                case 1:
                    TextBox1.Text = "اول راهنمایی";
                    break;
                case 2:
                    TextBox1.Text = "دوم راهنمایی";
                    break;
                case 3:
                    TextBox1.Text = "سوم راهنمایی";
                    break;
            }
        }
        else if (b == 1)
        {
            switch (y)
            {
                case 1:
                    TextBox1.Text = "اول دبستان";
                    break;
                case 2:
                    TextBox1.Text = "دوم دبستان";
                    break;
                case 3:
                    TextBox1.Text = "سوم دبستان";
                    break;
                case 4:
                    TextBox1.Text = "چهارم دبستان";
                    break;
                case 5:
                    TextBox1.Text = "پنجم دبستان";
                    break;
            }
        }
    
    }
    private void setresh(int r)
    {
        if (r == 2)
            TextBox2.Text = "ریاضی فیزیک";
        else if (r == 3)
            TextBox2.Text = "علوم تجربی";
        else if (r == 4)
            TextBox2.Text = "علوم انسانی"; 
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("PageSchool.aspx");  
    }
}
