using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineLibraryManagement
{
    public partial class userprofile : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["username"].ToString() == "" || Session["username"] == null)
                {
                    Response.Write("<script>alert('Session Timeout Login again');</script>");
                    Response.Redirect("userlogin.aspx");
                }
                else {
                         Getmemberbookdata();

                        if (!Page.IsPostBack)            // because when the page is refreshed this page is posted back to the back end (dynamic web app)  => Postback
                        {                               //  when the first time the page is loaded that is not Post back event
                        Getuserdetails(); 
                        }
                     }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }


        // update  button 
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE member_master_tbl SET full_name=@name,dob=@date,contact_no=@no ,email=@mail,state=@state,city=@city,pincode=@pin,full_address=@add,password=@pass WHERE member_id=@id", con);
                
                cmd.Parameters.AddWithValue("@id", Session["username"].ToString());
                cmd.Parameters.AddWithValue("@name", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@date", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@no", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@mail", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@state", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@city", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@pin", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@add", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@pass", TextBox19.Text.Trim());
             
                cmd.ExecuteNonQuery();
                con.Close();
                 Response.Write("<script>alert(' updated Successful');</script>");

                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }


        // user defined functions
        void Getmemberbookdata()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from book_issue_tbl where member_id = '" + Session["username"].ToString() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

        }


        // Get uer data
        void Getuserdetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                
                SqlCommand cmd = new SqlCommand("SELECT * from member_master_tbl where member_id = '" + Session["username"].ToString() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                TextBox1.Text = dt.Rows[0][1].ToString();
                TextBox2.Text = dt.Rows[0][3].ToString();
                TextBox6.Text = dt.Rows[0][2].ToString();
                TextBox4.Text = dt.Rows[0][4].ToString();

                DropDownList1.SelectedValue = dt.Rows[0][5].ToString().Trim();
                TextBox3.Text = dt.Rows[0][6].ToString();
                TextBox5.Text = dt.Rows[0][7].ToString();
                TextBox7.Text = dt.Rows[0][8].ToString();
                TextBox8.Text = dt.Rows[0][0].ToString();
                TextBox10.Text = dt.Rows[0][9].ToString();

                Label1.Text = dt.Rows[0][10].ToString().Trim();

                if (dt.Rows[0][10].ToString().Trim() == "active")
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-success");
                }
                else if(dt.Rows[0][10].ToString().Trim() == "pending")
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-warning");
                }
                else if (dt.Rows[0][10].ToString().Trim() == "deactive")
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-danger");
                }
                else 
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-info");
                }



            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }




        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //Check your condition here
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime today = DateTime.Today;
                    if (today > dt)
                    {
                        e.Row.BackColor = System.Drawing.Color.PaleVioletRed;
                    }else
                        e.Row.BackColor = System.Drawing.Color.DarkOliveGreen;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }


    }
}