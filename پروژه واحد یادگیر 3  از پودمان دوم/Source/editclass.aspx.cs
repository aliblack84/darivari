using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Data .SqlClient;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Default3 : System.Web.UI.Page
{
    private SqlConnection con=new SqlConnection ("Data Source=.;Initial Catalog=School;Integrated Security=True");
    private SqlCommand com=new SqlCommand ();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["index"].ToString ()=="1" )
            {
                Panel1.Visible =true ; 
            }
            else
                Panel2 .Visible =true ;
            con.Open();
            com.CommandText = "select base,ns from tblschool where id=" + Session["id_s"].ToString();
            com.Connection = con;
            SqlDataReader dr = com.ExecuteReader();
            dr.Read();
            lbltitr.Text = "آموزشگاه" + " " + dr["ns"].ToString();

        }

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        filldrop2();
        

    }
    private void filldrop2()
    {
        if ((DropDownList1.SelectedValue == "دوم دبیرستان") || (DropDownList1.SelectedValue == "سوم دبیرستان") || (DropDownList1.SelectedValue == "پیش دانشگاهی"))
        {
            Label3.Visible = true;
            DropDownList2.Visible = true;
            

        }
        else
        {
            Label3.Visible = false;
            DropDownList2.Visible = false;

        }
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        int resh = 0;
        com.Connection =con;
        con.Open ();
        int base1=DropDownList1.SelectedIndex ;
        base1 ++;
        if (DropDownList2.Visible == false)
        {
            if (DropDownList1.SelectedValue == "اول دبیرستان")
            {
                resh = 1;
            }
            else
                resh = 0;
        }
        else
            resh =int.Parse (DropDownList2.SelectedValue); 
        com.CommandText ="insert into tblclass2 values('"+TextBox1.Text +"',"+Session["id_s"].ToString () +","+base1+","+resh+")";
        com.ExecuteNonQuery();
        TextBox1.Text = ""; 
    }
protected void  DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
{
    DropDownList3.Items[DropDownList3 .Items.Count-1]  .Selected =false ;
    DropDownList4.Visible =true ;
    Label5.Visible =true; 
    setdropbase();
    setdropresh(); 
}
protected void  DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
{
    if ((DropDownList4.SelectedValue == "دوم دبیرستان") || (DropDownList4.SelectedValue == "سوم دبیرستان") || (DropDownList4.SelectedValue == "پیش دانشگاهی"))
        {
            Label6.Visible = true;
            DropDownList5.Visible = true;
            

        }
        else
        {
            Label6.Visible = false;
            DropDownList5.Visible = false;

        }
    

}
protected void  DropDownList3_PreRender(object sender, EventArgs e)
{
    if (!IsPostBack)
    {
        
        DropDownList5.Items.Add(" ");
        DropDownList5.SelectedIndex = DropDownList5.Items.Count - 1;
        DropDownList3.Items.Add(" ");
        DropDownList3.SelectedIndex = DropDownList3.Items.Count - 1;
    }
}
    private void setdropbase()
    {
        con.Open();
        com.CommandText ="select base from tblclass2 where id_s="+Session ["id_s"].ToString ()+" and name='"+DropDownList3.SelectedValue +"'" ;
        com.Connection =con;
        SqlDataReader dr=com.ExecuteReader();
        dr.Read ();
        DropDownList4.SelectedIndex =int.Parse(dr["base"].ToString() )-1;
        dr.Close();
 
    }
    private void setdropresh()
    {
        
        com.CommandText ="select resh from tblclass2 where id_s="+Session ["id_s"].ToString ()+" and name='"+DropDownList3.SelectedValue +"'" ;
        com.Connection =con;
        SqlDataReader dr=com.ExecuteReader();
        dr.Read ();
        if (int.Parse(dr["resh"].ToString()) > 1)
        {

            DropDownList5.SelectedIndex = int.Parse(dr["resh"].ToString()) - 2;
            Label6.Visible = true;
            DropDownList5.Visible = true;
        }
        else
        {
            Label6.Visible = false;
            DropDownList5.Visible = false;

        }

    }
protected void  Button2_Click(object sender, EventArgs e)
{
    DropDownList4.Enabled =true ; 
    DropDownList5.Enabled =true ;
    Button4.Visible=true ;
    Button5.Visible=true ;
    Button2.Visible = false;
    Button3.Visible = false; 
    TextBox2.Visible =true ; 
    TextBox2 .Text =DropDownList3.SelectedValue ;
    DropDownList3.Visible = false;
    RequiredFieldValidator2.Enabled = true; 
}
protected void  Button5_Click(object sender, EventArgs e)
{
    cansel ();
     

}
protected void  Button4_Click(object sender, EventArgs e)
{
    int resh=0;
    if (DropDownList5.Visible == false)
        {
            if (DropDownList4.SelectedValue == "اول دبیرستان")
            {
                resh = 1;
            }
            else
                resh = 0;
        }
        else
            resh =int.Parse (DropDownList5.SelectedValue);
    com.Connection =con;
    con.Open ();
    int b1=DropDownList4.SelectedIndex ;
    b1++;
    com.CommandText ="update tblclass2 set name='"+TextBox2.Text+"' , base="+b1+" , resh="+resh+" where name='"+DropDownList3.SelectedValue +"' and id_s="+ Session ["id_s"].ToString ();
    com.ExecuteNonQuery();
    DropDownList3.Items[DropDownList3.SelectedIndex].Text = TextBox2.Text;
    com.CommandText = "update tblsudent set nameclass='" + TextBox2.Text + "' where nameclass='" + DropDownList3.SelectedValue + "' and id_school=" + Session["id_s"].ToString();
    com.ExecuteNonQuery();
    com.CommandText = "update tblteach set name='" + TextBox2.Text + "' where name='" + DropDownList3.SelectedValue + "' and id_s=" + Session["id_s"].ToString();
    com.ExecuteNonQuery();
    cansel ();
    
}
    private void cansel()
    {
        Button2.Visible=true ;
        Button3.Visible=true ;
        Button4.Visible=false;
        Button5.Visible=false ;
        DropDownList4.Enabled =false ; 
        DropDownList5.Enabled =false ;
        TextBox2.Visible =false ;
        DropDownList3.Visible = true;
        RequiredFieldValidator2.Enabled = false;
    }
protected void  Button3_Click(object sender, EventArgs e)
{
    com.Connection =con;
    con.Open ();
    string name=DropDownList3.SelectedValue;
    com.CommandText ="delete from tblclass2 where name='"+DropDownList3.SelectedValue +"' and id_s="+ Session ["id_s"].ToString ();
    com.ExecuteNonQuery();
    com.CommandText ="delete from tblprogram where nameclass='"+name +"' and id_school="+ Session ["id_s"].ToString ();
    com.ExecuteNonQuery();
    com.CommandText = "update tblsudent set nameclass='qw' where nameclass='" + name + "' and id_school=" + Session["id_s"].ToString();
    com.ExecuteNonQuery(); 
    DropDownList3.Items.Remove(DropDownList3.SelectedValue);
    DropDownList4.SelectedIndex = DropDownList4.Items.Count - 1;
    DropDownList3.SelectedIndex = DropDownList3.Items.Count - 1;
    DropDownList5.SelectedIndex = DropDownList5.Items.Count - 1;
       
      
     

}
    protected void DropDownList4_PreRender(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DropDownList4.Items.Add(" ");
            DropDownList4.SelectedIndex = DropDownList4.Items.Count - 1;
        }
    }
}