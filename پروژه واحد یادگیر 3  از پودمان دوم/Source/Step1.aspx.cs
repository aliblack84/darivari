using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class Step1 : System.Web.UI.Page
{
    private SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=School;Integrated Security=True");
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        SqlCommand com = new SqlCommand("select * from tblschool where id=" + txtId.Text, con);
        con.Open();
        SqlDataReader dr = com.ExecuteReader(); 
        dr.Read();
        if (dr.HasRows)
        {
            lblerror.Visible = true;
        }
        else
        {
            dr.Close();
            con.Close(); 
            Session.Add("base", dr1.SelectedValue);
            Session.Add("id", txtId.Text);
            com.CommandText = "insert into tblschool values ('" + txtnamesch.Text + "','" + txtnameman.Text + "'," + r1.SelectedValue + ",'" + txtaddres.Text + "'," + txtarea.Text + ",'" + txttel.Text + "'," + dr1.SelectedValue + "," + txtId.Text + ",'" + txtnamecity.Text + "')";
            con.Open(); 
            com.ExecuteNonQuery();
            Response.Redirect("Step2.aspx");  


        }


    }
}
