using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SQLite;
using System.Data.SqlClient;

namespace FgsHomeProgram
{
    public partial class Upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ImportCSV(object sender, EventArgs e)
        {
            string csvPath = Server.MapPath("~/Files/");
            if (!Directory.Exists(csvPath))
                Directory.CreateDirectory(csvPath);

            csvPath += Path.GetFileName(FileUpload1.PostedFile.FileName);
            FileUpload1.SaveAs(csvPath);

            //Create a DataTable.
            DataTable dt = new DataTable();
            //dt.Columns.AddRange(new DataColumn[11] { new DataColumn("Id", typeof(int)),
            dt.Columns.AddRange(new DataColumn[11] {new DataColumn("FirstName", typeof(string)),
            new DataColumn("LastName",typeof(string)),
            new DataColumn("Address1",typeof(string)),
            new DataColumn("Address2", typeof(string)),
             new DataColumn("City",typeof(string)),
             new DataColumn("State",typeof(string)),
             new DataColumn("ZipCode",typeof(string)),
             new DataColumn("ItemId",typeof(string)),
              new DataColumn("Quantity",typeof(string)),
             new DataColumn("Flag",typeof(string)),
             new DataColumn("CreatedDate",typeof(string))});

            //Read the contents of CSV file.
            string csvData = File.ReadAllText(csvPath);

            //Execute a loop over the rows.
            foreach (string row in csvData.Split('\n').Skip(1))
            {
                if (!string.IsNullOrEmpty(row))
                {
                    dt.Rows.Add();
                    int i = 0;

                    //Execute a loop over the columns.
                    foreach (string cell in row.Split(','))
                    {
                        dt.Rows[dt.Rows.Count - 1][i] = cell;
                        i++;
                    }
                }
            }


            string cs = @"URI=file:C:\Users\Admin\FGS.db";

            using (var con = new SQLiteConnection(cs))
            {
                con.Open();
                //foreach (DataRow r in dt.Rows)     values('"+@FirstName+"',@LastName,@Address1,@Address2,@City,@State,@ZipCode,@ItemId,@Quantity,@Flag,@CreatedDate)
                // for (int i = 0; i < dt.tables[0].Rows.Count; i++)
                try
                {
                    for (int i = 0; i < dt.Rows.Count; i++)

                        using (SQLiteCommand cmd1 = new SQLiteCommand("insert into Orders(FirstName,LastName,Address1,Address2,City,State,ZipCode,ItemId,Quantity,Flag,CreatedDate,Status,Reason) values('" + dt.Rows[i]["FirstName"] + "','" + dt.Rows[i]["LastName"] + "','" + dt.Rows[i]["Address1"] + "','" + dt.Rows[i]["Address2"] + "','" + dt.Rows[i]["City"] + "','" + dt.Rows[i]["State"] + "','" + dt.Rows[i]["ZipCode"] + "','" + dt.Rows[i]["ItemId"] + "','" + dt.Rows[i]["Quantity"] + "','" + dt.Rows[i]["Flag"] + "','" + dt.Rows[i]["CreatedDate"] + "','CREATED',null)"))
                        {

                            cmd1.CommandType = CommandType.Text;
                            cmd1.Connection = con;
                            //cmd1.Parameters.AddWithValue("@FirstName", "1");
                            //cmd1.Parameters.AddWithValue("@LastName", "2");
                            //cmd1.Parameters.AddWithValue("@Address1", "3");
                            //cmd1.Parameters.AddWithValue("@Address2", "4");
                            //cmd1.Parameters.AddWithValue("@City", "5");
                            //cmd1.Parameters.AddWithValue("@State", "6");
                            //cmd1.Parameters.AddWithValue("@ZipCode", "7");
                            //cmd1.Parameters.AddWithValue("@ItemId", "8");
                            //cmd1.Parameters.AddWithValue("@Quantity", 10);
                            //cmd1.Parameters.AddWithValue("@Flag", 1);
                            //cmd1.Parameters.AddWithValue("@CreatedDate", DateTime.Today.ToShortDateString());

                            cmd1.ExecuteNonQuery();

                        }
                }
                catch (Exception)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)

                        using (SQLiteCommand cmd1 = new SQLiteCommand("insert into Orders(FirstName,LastName,Address1,Address2,City,State,ZipCode,ItemId,Quantity,Flag,CreatedDate,Status,Reason) values('" + dt.Rows[i]["FirstName"] + "','" + dt.Rows[i]["LastName"] + "','" + dt.Rows[i]["Address1"] + "','" + dt.Rows[i]["Address2"] + "','" + dt.Rows[i]["City"] + "','" + dt.Rows[i]["State"] + "','" + dt.Rows[i]["ZipCode"] + "','" + dt.Rows[i]["ItemId"] + "','" + dt.Rows[i]["Quantity"] + "','" + dt.Rows[i]["Flag"] + "','" + dt.Rows[i]["CreatedDate"] + "','FAILED','An Error has Occured!!!')"))
                        {

                            cmd1.CommandType = CommandType.Text;
                            cmd1.Connection = con;
                            //cmd1.Parameters.AddWithValue("@FirstName", "1");
                            //cmd1.Parameters.AddWithValue("@LastName", "2");
                            //cmd1.Parameters.AddWithValue("@Address1", "3");
                            //cmd1.Parameters.AddWithValue("@Address2", "4");
                            //cmd1.Parameters.AddWithValue("@City", "5");
                            //cmd1.Parameters.AddWithValue("@State", "6");
                            //cmd1.Parameters.AddWithValue("@ZipCode", "7");
                            //cmd1.Parameters.AddWithValue("@ItemId", "8");
                            //cmd1.Parameters.AddWithValue("@Quantity", 10);
                            //cmd1.Parameters.AddWithValue("@Flag", 1);
                            //cmd1.Parameters.AddWithValue("@CreatedDate", DateTime.Today.ToShortDateString());

                            cmd1.ExecuteNonQuery();

                        }
                }
                //using (SQLiteCommand cmd1 = new SQLiteCommand("insert into Orders(FirstName,LastName,Address1,Address2,City,State,ZipCode,ItemId,Quantity,Flag,CreatedDate) values('aa1','bb3','cc','dd','ee','ff','gg','hh',2,3,null)"))
                //{

                //    cmd1.Connection = con;
                //    cmd1.CommandType = CommandType.Text;
                //    cmd1.ExecuteNonQuery();

                //}
                con.Close();
                Response.Redirect("Orders.aspx");


            }
        }

    }
}