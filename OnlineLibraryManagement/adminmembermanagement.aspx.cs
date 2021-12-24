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
    public partial class adminmembermanegment : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }


        bool checkmemberExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from member_master_tbl where member_id ='" + TextBox2.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }



        void getmemberById()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from member_master_tbl where member_id ='" + TextBox2.Text.Trim() + "';", con);
                SqlDataReader dr = cmd.ExecuteReader();
               
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        TextBox3.Text = dr.GetValue(10).ToString();
                        TextBox1.Text = dr.GetValue(1).ToString();
                        TextBox4.Text = dr.GetValue(2).ToString();
                        TextBox5.Text = dr.GetValue(3).ToString();
                        TextBox6.Text = dr.GetValue(4).ToString();
                        TextBox7.Text = dr.GetValue(5).ToString();
                        TextBox8.Text = dr.GetValue(6).ToString();
                        TextBox9.Text = dr.GetValue(7).ToString();
                        TextBox10.Text = dr.GetValue(8).ToString();
                    }
                }
                else
                {
                    Response.Write("<script>alert('member Id didnot exist');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }

        }



        protected void LinkButton3_Click1(object sender, EventArgs e)
        {
            updatestatusbyid("active");
            TextBox3.Text = "active";
        }

        protected void LinkButton1_Click1(object sender, EventArgs e)
        {
            updatestatusbyid("pending");
            TextBox3.Text = "pending";
        }


        // Go button
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            getmemberById();
        }


        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            updatestatusbyid("deactive");
            TextBox3.Text = "deactive";
        }




        void updatestatusbyid(string status)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE member_master_tbl SET account_status= '" + status + "' WHERE member_id='" + TextBox2.Text.Trim() + "'", con);

                cmd.ExecuteNonQuery();
                con.Close();
              //  Response.Write("<script>alert('m updated Successful');</script>");

                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

        }




        // delete button
        protected void Button6_Click1(object sender, EventArgs e)
        {
            if (checkmemberExists())
            {
                deletemember();
            }
            else
            {
                Response.Write("<script>alert('member do not Exist');</script>");
            }
        }



        void deletemember()
        {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("DELETE FROM member_master_tbl WHERE " +
                        "member_id='" + TextBox2.Text.Trim() + "'", con);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('member deleted Successful');</script>");

                    clearForm();
                    GridView1.DataBind();        // it will connect again with data source which will connect again to db and get the new refresh data 
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }

            
        }


        void clearForm()
        {
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox1.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = ""; 
            TextBox8.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";
        }



    }
}