using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Contactlist_web___3._0
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        int selID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            selID = Convert.ToInt32(Request.QueryString["id"]);
            loadCurrentPhonenumber();
            
        }

        private void loadCurrentPhonenumber()
        {
            int counter = 1;
            string test = " ";
            test += "<div class=\"container\">";
            test += "<table class=\"table\">";
            test += "<thead>";
            test += "<tr>";
            test += "<th>#</th>";
            test += "<th>Type</th>";
            test += "<th>Phonenumber</th>";
            test += "<th></th>";
            test += "<th></th>";
            test += "<th></th>";
            test += "</tr>";
            test += "</thead>";
            test += "<tbody>";

            SqlConnection myCon = new SqlConnection();
            myCon.ConnectionString = WebForm3.CON_STR;

            try
            {
                myCon.Open();
                SqlCommand cmdLoadP = new SqlCommand();
                cmdLoadP.Connection = myCon;
                cmdLoadP.CommandText = $"select * from phone where ID in (select PID from CPTable where CID = {selID})";

                SqlDataReader myReader = cmdLoadP.ExecuteReader();

                while (myReader.Read())
                {
                    test += "<tr>";
                    test += $"<td>{counter++}</td>";
                    test += $"<td>{myReader["type"]}</td>";
                    test += $"<td>{myReader["phonenumber"]}</td>";
                    test += $"<td></td>";
                    test += $"<td></td>";
                    test += $"<td><a href=\"#\" onClick=\"editPhone('{myReader["id"]}', '{myReader["type"]}', '{myReader["phonenumber"]}')\">Edit</a></td>";
                    test += $"<td><a href=\"#\">Delete</a></td>";
                    test += "</tr>";
                }

                test += "</tbody>";
                test += "</table>";
                test += "</div>";

                phoneLit.Text = test;

            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert({ex.Message})</script>");
                throw;
            }
            finally { myCon.Close(); }
        }



        private int addPhone()
        {
            int newPID = 0;
            SqlConnection myCon = new SqlConnection();
            myCon.ConnectionString = WebForm3.CON_STR;

            try
            {
                myCon.Open();

                SqlCommand cmdAddPhone = new SqlCommand();
                cmdAddPhone.Connection = myCon;
                cmdAddPhone.CommandType = CommandType.StoredProcedure;
                cmdAddPhone.CommandText = "spAddPhone";

                SqlParameter paramType = new SqlParameter("@type", SqlDbType.VarChar);
                paramType.Value = ddTypePhone.SelectedValue;
                cmdAddPhone.Parameters.Add(paramType);

                SqlParameter paramNumber = new SqlParameter("@phonenumber", SqlDbType.VarChar);
                paramNumber.Value = tboxPhonenumber.Text.Trim();
                cmdAddPhone.Parameters.Add(paramNumber);

                SqlParameter paramID = new SqlParameter("@newID", SqlDbType.Int);
                paramID.Direction = ParameterDirection.Output;
                cmdAddPhone.Parameters.Add(paramID);

                cmdAddPhone.ExecuteNonQuery();

                newPID = (int)paramID.Value;

            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert({ex.Message})</script>");
                throw;
            }
            finally { myCon.Close(); }
            return newPID;
        }

        protected void btnaddPhone_Click(object sender, EventArgs e)
        {
            int PID = addPhone();
            connectTables(PID);
            Response.Redirect($"./editContact.aspx?id={selID}");
        }

        private void connectTables(int pID)
        {
            SqlConnection myCon = new SqlConnection();
            myCon.ConnectionString = WebForm3.CON_STR;

            try
            {
                myCon.Open();
                SqlCommand cmdConnect = new SqlCommand();
                cmdConnect.Connection = myCon;
                cmdConnect.CommandType = CommandType.StoredProcedure;
                cmdConnect.CommandText = "spConnectCPTable";

                SqlParameter paramPID = new SqlParameter("@PID", SqlDbType.Int);
                paramPID.Value = pID;
                cmdConnect.Parameters.Add(paramPID);

                SqlParameter paramCID = new SqlParameter("@CID", SqlDbType.Int);
                paramCID.Value = selID;
                cmdConnect.Parameters.Add(paramCID);

                cmdConnect.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert({ex.Message})</script>");
                throw;
            }
            finally { myCon.Close(); }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            updatePhone();
            Response.Redirect($"./editContact.aspx?id={selID}");
        }

        private void updatePhone()
        {
            SqlConnection myCon = new SqlConnection();
            myCon.ConnectionString = WebForm3.CON_STR;

            try
            {
                myCon.Open();

                SqlCommand cmdUpdatePhone = new SqlCommand();
                cmdUpdatePhone.CommandType = CommandType.StoredProcedure;
                cmdUpdatePhone.CommandText = "spUpdatePhone";
                cmdUpdatePhone.Connection = myCon;

                SqlParameter paramPID = new SqlParameter("@ID", SqlDbType.Int);
                paramPID.Value = TextBox1.Text;
                cmdUpdatePhone.Parameters.Add(paramPID);

                SqlParameter paramType = new SqlParameter("@newType", SqlDbType.VarChar);
                paramType.Value = ddPhoneTypeEdit.SelectedValue;
                cmdUpdatePhone.Parameters.Add(paramType);

                SqlParameter paramNumber = new SqlParameter("@newPhonenumber", SqlDbType.VarChar);
                paramNumber.Value = tboxPhone.Text;
                cmdUpdatePhone.Parameters.Add(paramNumber);

                cmdUpdatePhone.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert({ex.Message})</script>");
                throw;
            }
            finally
            {
                myCon.Close();
            }

        }
    }
}