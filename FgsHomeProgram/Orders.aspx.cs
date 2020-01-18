using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FgsHomeProgram
{
    public partial class Orders : System.Web.UI.Page
    {
        private string SortDirection
        {
            get { return ViewState["SortDirection"] != null ? ViewState["SortDirection"].ToString() : "ASC"; }
            set { ViewState["SortDirection"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGrid();
            }
        }

        
        private void BindGrid(string sortExpression = null)
        {
            string cs = @"URI=file:C:\Users\Admin\FGS.db";
            // string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (var con = new SQLiteConnection(cs))
            {
                con.Open();
                //using (SQLiteConnection con = new SQLiteConnection(constr))
                {
                    string query = "SELECT OrderId,FirstName,LastName,Address1,Address2,City,State,ZipCode,ItemId,Quantity,CreatedDate,Status,Reason FROM Orders";
                    string status = ddlist.SelectedItem.Text;
                    if(status != "ALL")
                    {
                        query = "SELECT OrderId,FirstName,LastName,Address1,Address2,City,State,ZipCode,ItemId,Quantity,CreatedDate,Status,Reason FROM Orders where [Status] = '" + status +"'";
                    }
                    using (SQLiteCommand cmd = new SQLiteCommand(query))
                    {
                        using (SQLiteDataAdapter sda = new SQLiteDataAdapter())
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;                          
                            using (DataTable dt = new DataTable())
                            {
                                ViewState["dt"] = dt;
                                sda.Fill(dt);
                                if (sortExpression != null)
                                {
                                    DataView dv = dt.AsDataView();
                                    this.SortDirection = this.SortDirection == "ASC" ? "DESC" : "ASC";

                                    dv.Sort = sortExpression + " " + this.SortDirection;
                                    GridView1.DataSource = dv;
                                }
                                else
                                {
                                    GridView1.DataSource = dt;
                                }
                                //GridView1.DataSource = dt;
                                GridView1.DataBind();
                            }
                        }
                    }
                }
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.SelectedIndex = -1;
            GridView1.EditIndex = -1;
            this.BindGrid();
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            this.BindGrid(e.SortExpression);
        }

        protected void ddlist_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            DataTable dt = ViewState["dt"] as DataTable;

            //var orderid = e.Values[0];
            var orderid = dt.Rows[index]["OrderId"].ToString();
            delete (Convert.ToInt32(orderid));
            //dt.Rows[index].Delete();
            //ViewState["dt"] = dt;
            //GridView1.DataSource = dt;
            BindGrid();
        }

        private void delete(int orderid)
        {
            string cs = @"URI=file:C:\Users\Admin\FGS.db";

            using (var con = new SQLiteConnection(cs))
            {
                con.Open();               

                    using (SQLiteCommand cmd1 = new SQLiteCommand("delete from Orders where OrderId='"+orderid+"'"))
                    {

                        cmd1.CommandType = CommandType.Text;
                        cmd1.Connection = con;
                        cmd1.ExecuteNonQuery();
                }
                con.Close();
            }
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string item = e.Row.Cells[0].Text;
                foreach (Button button in e.Row.Cells[2].Controls.OfType<Button>())
                {
                    if (button.CommandName == "Delete")
                    {
                        button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + item + "?')){ return false; };";
                    }
                }
            }
        }
    }
}