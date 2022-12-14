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

public partial class program : System.Web.UI.Page
{
    private SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=School;Integrated Security=True");
    private SqlCommand com = new SqlCommand();
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
    protected void TextBox1_Load(object sender, EventArgs e)
    {
         
        
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList1.Items[DropDownList1.Items.Count - 1].Selected = false;
        com.CommandText = "select base,resh from tblclass where id_school="+Session["id_s"].ToString()+" and name='"+DropDownList1.SelectedValue+"'";
        com.Connection = con;
        con.Open();
        SqlDataReader dr = com.ExecuteReader();
        dr.Read();
        int y = int.Parse(dr["base"].ToString());
        int r = int.Parse(dr["resh"].ToString());
        dr.Close();
        com.CommandText = " select base from tblschool where id="+Session["id_s"].ToString();
        dr = com.ExecuteReader();
        dr.Read();
        TextBox1.Visible = true;
        Label2.Visible = true; 
        int b = int.Parse(dr["base"].ToString());
        filltextbox(b, r, y);
        fillsqldata(y, r); 


    }
    protected void DropDownList1_PreRender(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DropDownList1.Items.Add(" ");
            DropDownList1.Items[DropDownList1.Items.Count - 1].Selected = true;
        }
        

    }
    protected void DropDownList1_Init(object sender, EventArgs e)
    {

    }
    protected void DropDownList1_Load(object sender, EventArgs e)
    {

    }
    private void filltextbox(int b, int r,int y)
    {
        if ((r == 2) || (r == 3) || (r == 4))
        {
            TextBox2.Visible = true;
            Label3.Visible = true;
            if (r == 2)
                TextBox2.Text = "ریاضی فیزیک";
            else if (r == 3)
                TextBox2.Text = "علوم تجربی";
            else if (r == 4)
                TextBox2.Text = "علوم انسانی";
        }
        else
        {
            TextBox2.Visible = false;
            Label3.Visible = false; 
        }
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
                        TextBox1.Text ="اول راهنمایی"; 
                        break ;
                    case 2:
                        TextBox1.Text ="دوم راهنمایی"; 
                        break ;
                    case 3:
                        TextBox1.Text ="سوم راهنمایی"; 
                        break ;
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
                        break ;
                }
            }
        
    }
    private void fillsqldata(int b, int r)
    {
        SqlDataSource1.ConnectionString = "Data Source=.;Initial Catalog=School;Integrated Security=True";
        SqlDataSource1.SelectCommand = "select name from lesson where id_school=" + Session["id_s"].ToString() + " and yer=" + b + " and resh=" + r;
        SqlDataSource1.DataBind();
    }
}
