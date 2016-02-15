using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Contactlist_web___3._0
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        int selID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            selID = Convert.ToInt32(Request.QueryString["id"]);

            SqlConnection myCon = new SqlConnection();
            myCon.ConnectionString = WebForm3.CON_STR;

            try
            {
                myCon.Open();
                SqlCommand cmdGetContact = new SqlCommand();
                cmdGetContact.CommandText = $"select * from Contact where ID = '{selID}'";
                cmdGetContact.Connection = myCon;

                SqlDataReader myReader = cmdGetContact.ExecuteReader();
                while (myReader.Read())
                {
                    lblFirstname.Text = myReader["firstname"].ToString();
                    lblLastname.Text = myReader["lastname"].ToString();
                    lblSSN.Text = myReader["SSN"].ToString();
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('{ex.Message}')</script>");
                throw;
            }
            finally { myCon.Close(); }
            try
            {
                myCon.Open();
                SqlCommand getPhone = new SqlCommand();
                getPhone.CommandText = $"select * from phone where ID in (select PID from CPTable where CID = '{selID}')";
                getPhone.Connection = myCon;

                SqlDataReader reader = getPhone.ExecuteReader();
                while (reader.Read())
                {
                    //lblPhone.Text = reader["phonenumber"].ToString();
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('{ex.Message}')</script>");
                throw;
            }
            finally { myCon.Close(); }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            updateContact();
        }

        private void updateContact()
        {
            if (tboxFirstName.Text == null || tboxFirstName.Text.Trim().Length == 0)
            {
                tboxFirstName.Text = lblFirstname.Text;
            }
            if (tboxLastname.Text == null || tboxLastname.Text.Trim().Length == 0)
            {
                tboxLastname.Text = lblLastname.Text;
            }
            if (tboxSSN.Text == null || tboxSSN.Text.Trim().Length == 0)
            {
                tboxSSN.Text = lblSSN.Text;
            }

            SqlConnection myCon = new SqlConnection();
            myCon.ConnectionString = WebForm3.CON_STR;

            try
            {
                myCon.Open();
                SqlCommand cmdUpdate = new SqlCommand();
                cmdUpdate.CommandType = CommandType.StoredProcedure;
                cmdUpdate.CommandText = "spUpdateContact";
                cmdUpdate.Connection = myCon;

                SqlParameter paramID = new SqlParameter("@ID", SqlDbType.Int);
                paramID.Value = selID;
                cmdUpdate.Parameters.Add(paramID);

                SqlParameter paramFirst = new SqlParameter("@newFirstname", SqlDbType.VarChar);
                paramFirst.Value = tboxFirstName.Text;
                cmdUpdate.Parameters.Add(paramFirst);

                SqlParameter paramLast = new SqlParameter("@newLastname", SqlDbType.VarChar);
                paramLast.Value = tboxLastname.Text;
                cmdUpdate.Parameters.Add(paramLast);

                SqlParameter paramSSN = new SqlParameter("@newSSN", SqlDbType.VarChar);
                paramSSN.Value = tboxSSN.Text;
                cmdUpdate.Parameters.Add(paramSSN);

                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('{ex.Message}')</script>");
                throw;
            }
            finally { myCon.Close(); }
        }
    }
}