using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Contactlist_web___3._0
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            bool success;
            success = ContactManager.ContactManager.updateContact(hiddenID.Text, tboxFirstName.Text, tboxLastName.Text, tboxSSN.Text);
            if (success)
            {
                Response.Redirect($"./main.aspx");
            }
            else { Response.Write("<p>De e knas</p>"); }

        }
    }
}