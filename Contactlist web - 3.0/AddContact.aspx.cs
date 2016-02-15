using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using ContactManager;

namespace Contactlist_web___3._0
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        const string CON_STR = @"Data Source=.;Initial Catalog=contactlist;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int cid = ContactManager.ContactManager.addContact(tboxFirstnameAdd.Text, tboxLastnameAdd.Text, tboxSSNAdd.Text);

            if (cid != 0)
            {
                Response.Redirect("./main.aspx");
            }
            else
            {
                Response.Write("Det e knas");
            }
        }
    }
}