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

public partial class Default2 : System.Web.UI.Page
{
    private DateTime dt = DateTime.Now;
    private PersianCalendar pc = new PersianCalendar();
    private SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=School;Integrated Security=True");
    protected void Page_Load(object sender, EventArgs e)
    {
        int m=pc.GetMonth(dt);
        
        if ((m == 4) || (m == 5) || (m == 6) || (m == 7) || (m == 8) || (m == 9) )
        {
            Panel1.Visible = true;

        }
        else
        {
            Panel1.Visible = false;
            Panel4.Visible = true; 
        }
        if (!IsPostBack)
            Session.Add("yer", 1);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int cap = 0;
        int resh=0;
        if (DropDownList2.Visible ==false  )
        {
            if (DropDownList1.SelectedValue =="اول دبیرستان" )
                resh=1;
        }
        else 
            resh =int.Parse(DropDownList2.SelectedValue); 
        SqlCommand com = new SqlCommand();
        con.Open();
        string txtsql="";
        com.Connection = con;
        if (int.Parse(Session["yer"].ToString()) == 1)
        {
            txtsql = "select yer"+Session["yer"].ToString()+" from tblcapacity where id=" + Session["id_s"].ToString() + " and resh="+resh ;
        }
        else if (int.Parse(Session["yer"].ToString()) == 2)
        {
            txtsql = "select yer"+Session["yer"].ToString()+" from tblcapacity where id=" + Session["id_s"].ToString() + " and resh="+resh ;
        }
        else if (int.Parse(Session["yer"].ToString()) == 3)
        {
            txtsql = "select yer" + Session["yer"].ToString() + " from tblcapacity where id=" + Session["id_s"].ToString() + " and resh="+resh ;
        }
        else if (int.Parse(Session["yer"].ToString()) == 4)
            txtsql = "select yer" + Session["yer"].ToString() + " from tblcapacity where id=" + Session["id_s"].ToString() + " and resh="+resh ;
        else
            txtsql = "select yer" + Session["yer"].ToString() + " from tblcapacity where id=" + Session["id_s"].ToString() + " and resh=" + resh;
         
            
        com.CommandText = "select * from tblsudent where name='" + TextBox1.Text + "' and  num_sh=" + TextBox3.Text + " and name_f='" + TextBox2.Text + "'";
        SqlDataReader dr2 = com.ExecuteReader();
        dr2.Read();
        if (!dr2.HasRows  )
        {
            dr2.Close ();           
        com.CommandText = txtsql;
        SqlDataReader dr = com.ExecuteReader();
        dr.Read();
        if (dr.HasRows)
        {
            int y2 = pc.GetYear(dt);
            Panel2.Visible = false;
            cap = int.Parse(dr[0].ToString());
            com.CommandText = "select count(name) from tblsudent where id_school=" + Session["id_s"].ToString() + " and resh=" + resh + " and base=" + Session["yer"].ToString();
            dr.Close();
            dr = com.ExecuteReader();
            dr.Read();
            if (cap >= int.Parse(dr[0].ToString()))
            {
                dr.Close();
                com.CommandText = "insert into tblsudent (name,tel,address,enz,avr,num_sh,base,resh,id_school,name_f,yer) values('" + TextBox1.Text + "','" + TextBox5.Text + "','" + TextBox4.Text + "'," + TextBox7.Text + "," + TextBox6.Text + ",'" + TextBox3.Text + "'," + Session["yer"].ToString() + "," + resh + "," + Session["id_s"].ToString() + ",'" + TextBox2.Text + "'," + y2 + ")";
                com.ExecuteNonQuery();
                Panel3.Visible = true;
                com.CommandText = "select id from tblsudent where id_school=" + Session["id_s"].ToString() + " and num_sh=" + TextBox3.Text + " and name='" + TextBox1.Text + "'";

                SqlDataReader dr1 = com.ExecuteReader();
                dr1.Read();
                int id = int.Parse(dr1["id"].ToString());
                dr1.Close();
                com.CommandText = "insert into tbl_login_s values(" + Session["id_s"].ToString() + ",'" + id + "','" + TextBox3.Text + "')";
                dr1.Close();
                com.ExecuteNonQuery();
                lblrepeat.Visible = false;

            }
            else
                Panel2.Visible = true;
            Panel1.Visible = false;

        }
            else
             Panel2.Visible = true;
            Panel1.Visible = false;
        }

        else
            lblrepeat.Visible = true;
            
           
        
   
    }
    
    
    
            
        
         
       
         
        


    
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["yer"]= DropDownList1.SelectedIndex+1;  
        if ((DropDownList1.SelectedItem.Text == "دوم دبیرستان") || (DropDownList1.SelectedItem.Text == "سوم دبیرستان") || (DropDownList1.SelectedItem.Text == "پیش دانشگاهی"))
        {
            Label9.Visible = true;
            DropDownList2.Visible = true;
        }
        else
        {
            Label9.Visible = false;
            DropDownList2.Visible = false; 
        }
    }
}
