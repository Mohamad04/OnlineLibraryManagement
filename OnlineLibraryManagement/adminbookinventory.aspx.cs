using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineLibraryManagement
{
    public partial class adminbookinventory : System.Web.UI.Page
    {

        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        static string global_filepath; 
        static int global_actual_stock, global_current_stock, global_issued_books;    // static for final update


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Fillauthorpublishervalues();
            }
                GridView1.DataBind();
        }


        // Go button
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Getbookbyid();
        }


        // add button
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (CheckifbookExists())
            {
                Response.Write("<script>alert('the book already exists ');</script>");
            }
            else
            {
                Addnewbook();
            }
        }


        // update button
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (CheckifbookExists())
            {
                Updatebook();
            }
            else
            {
                Response.Write("<script>alert('the book donot exists ');</script>");
            }
        }


        // delete button
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (CheckifbookExists())
            {
                Deletebook();
            }
            else
            {
                Response.Write("<script>alert('the book donot exists ');</script>");
            }
        }




        // user defined functions
        void Getbookbyid()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from book_master_tbl WHERE book_id ='" + TextBox1.Text.Trim() + "' ;", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][1].ToString();
                    TextBox3.Text = dt.Rows[0][5].ToString();
                    TextBox9.Text = dt.Rows[0][7].ToString();
                    TextBox10.Text = dt.Rows[0]["book_cost"].ToString().Trim();
                    TextBox11.Text = dt.Rows[0]["no_of_pages"].ToString().Trim();
                    TextBox6.Text = dt.Rows[0][10].ToString();
                    TextBox4.Text = dt.Rows[0]["actual_stock"].ToString().Trim();
                    TextBox5.Text = dt.Rows[0]["current_stock"].ToString().Trim();
                    TextBox7.Text = "" + (Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString()) - Convert.ToInt32(dt.Rows[0]["current_stock"].ToString()));


                    DropDownList3.SelectedValue = dt.Rows[0]["author_name"].ToString().Trim();
                    DropDownList2.SelectedValue = dt.Rows[0]["publisher_name"].ToString().Trim();
                    DropDownList1.SelectedValue = dt.Rows[0]["langauge"].ToString().Trim();

                    ListBox1.ClearSelection();
                    string[] genre = dt.Rows[0]["genre"].ToString().Trim().Split(',');
                    for (int i = 0; i < genre.Length; i++)
                    {
                        for (int j = 0; j < ListBox1.Items.Count; j++)
                        {
                            if (ListBox1.Items[j].ToString() == genre[i])
                                ListBox1.Items[j].Selected = true;
                        }
                    }

                    global_actual_stock = Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString().Trim());
                    global_current_stock = Convert.ToInt32(dt.Rows[0]["current_stock"].ToString().Trim());
                    global_issued_books = global_actual_stock - global_current_stock;
                    global_filepath = dt.Rows[0]["book_img_link"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid book  ID  ');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }


        }





        void Fillauthorpublishervalues()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT author_name from author_master_tbl ;", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                DropDownList3.DataSource = dt;
                DropDownList3.DataValueField = "author_name";
                DropDownList3.DataBind();                          // to bind the data


                cmd = new SqlCommand("SELECT publisher_name from publisher_master_tbl ;", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                DropDownList2.DataSource = dt;
                DropDownList2.DataValueField = "publisher_name";
                DropDownList2.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }




        void Deletebook()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE FROM book_master_tbl WHERE " +
                    "book_id='" + TextBox1.Text.Trim() + "'", con);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert(' deleted Successful');</script>");

                //clearTexts();
                GridView1.DataBind();        // it will connect again with data source which will connect again to db and get the new refresh data 
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }






        void Updatebook()
        {
            try
            {
                int actual_stock = Convert.ToInt32(TextBox4.Text.Trim());
                int current_stock = Convert.ToInt32(TextBox5.Text.Trim());

                if (global_actual_stock == actual_stock)
                {
                }
                else          // update the actuak stock
                {
                    if (actual_stock < global_issued_books)
                    {   Response.Write("<script>alert('Actual Stock value cannot be less than the Issued books');</script>");
                        return;
                    }
                    else
                    {   current_stock = actual_stock - global_issued_books;
                        TextBox5.Text = "" + current_stock;
                    }
                }

                string genres = "";
                foreach (int i in ListBox1.GetSelectedIndices())
                {
                    genres = genres + ListBox1.Items[i] + ",";
                }
                genres = genres.Remove(genres.Length - 1);

                string filepath = "~/book_inventory/books1";                          // take filepath = book1   > default
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);   // filename from fileupload1
                if (filename == "" || filename == null)
                {
                    filepath = global_filepath;

                }
                else                  // if i change the image file
                {
                    FileUpload1.SaveAs(Server.MapPath("book_inventory/" + filename));
                    filepath = "~/book_inventory/" + filename;
                }

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE book_master_tbl SET book_name=@name,genre=@genre,author_name=@author ,pubisher_name=@publisher,publisher_date=@date,language=@language,edition=@edition,book_cost=@cost,no_of_pages=@pages,book_description=@description,actual_stock=@actual,current_stock=@current,book_img_link=@img WHERE book_id=@id", con);

                cmd.Parameters.AddWithValue("@id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@genre", genres);
                cmd.Parameters.AddWithValue("@author", DropDownList3.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publisher", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@date", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@edition", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@cost", TextBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@pages", TextBox11.Text.Trim());
                cmd.Parameters.AddWithValue("@description", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@actual", actual_stock.ToString());
                cmd.Parameters.AddWithValue("@current", current_stock.ToString());
                cmd.Parameters.AddWithValue("@img", filepath);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Book updated Successful');</script>");

                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }





        void Addnewbook()
        {
            try
            {
                string genres = "";
                foreach (int i in ListBox1.GetSelectedIndices())
                {
                    genres = genres + ListBox1.Items[i] + ",";
                }                                                   // genres = Adventure,Self Help,
                genres = genres.Remove(genres.Length - 1);             // to remove the last camma


                string filepath = "~/book_inventory/books1.png";              // default logo
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);  //  file is selected in fileupload1  -- FileName = b1.ppng
                FileUpload1.SaveAs(Server.MapPath("book_inventory/" + filename));   // the file is maped into book inventory folder
                filepath = "~/book_inventory/" + filename;                                // it has filepath and filename 


                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO book_master_tbl (book_id ,book_name,genre,author_name ,pubisher_name,publisher_date,language,edition,book_cost,no_of_pages,book_description,actual_stock,current_stock,book_img_link) VALUES (@bookid,@bookname,@genre,@author,@publisher,@date,@language,@edition,@cost,@pages,@description,@actual,@current,@img)", con);
                cmd.Parameters.AddWithValue("@bookid", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@bookname", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@genre", genres);
                cmd.Parameters.AddWithValue("@author", DropDownList3.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publisher", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@date", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@edition", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@cost", TextBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@pages", TextBox11.Text.Trim());
                cmd.Parameters.AddWithValue("@description", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@actual", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@current", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@img", filepath);             // img is saved as link so we need the path


                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert(' Successfully');</script>");
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }



        bool CheckifbookExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from book_master_tbl where book_id='" + TextBox1.Text.Trim() + "' OR book_name='" + TextBox2.Text.Trim() + "';", con);
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


    }
}