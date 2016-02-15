using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using ContactManager;

namespace Contactlist_web___3._0
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        public const string CON_STR = @"Data Source=.;Initial Catalog=contactlist;Integrated Security=True";
        List<ContactManager.Contact> myContacts = new List<ContactManager.Contact>();
        public int selID;
        protected void Page_Load(object sender, EventArgs e)
        {
            myContacts = ContactManager.ContactManager.LoadContact();
            loadTable();

            if (Request.QueryString["delete"] != null)
            {
                string delCont = Request.QueryString["delete"];
                bool success = ContactManager.ContactManager.DeleteContact(delCont);

                if (success)
                {
                    Response.Redirect("./main.aspx");
                }
            }

        }

        private void loadTable()
        {
            int counter = 1;
            string test = " ";
            test += "<div class=\"container\">";
            test += "<table class=\"table\">";
            test += "<thead>";
            test += "<tr>";
            test += "<th>#</th>";
            test += "<th>Firstname</th>";
            test += "<th>Lastname</th>";
            test += "<th>SSN</th>";
            test += "<th></th>";
            test += "<th></th>";
            test += "<th></th>";
            test += <th></th>;
            test += "</tr>";
            test += "</thead>";
            test += "<tbody>";

            foreach (var temp in myContacts)
            {
                test += "<tr>";
                test += $"<td>{counter++}</td>";
                test += $"<td>{temp.FirstName}</td>";
                test += $"<td>{temp.LastName}</td>";
                test += $"<td>{temp.Ssn}</td>";
                test += $"<td></td>";
                test += $"<td><a href=\"#\" onClick=\"\"</td>";
                test += $"<td><a href=\"#\" onClick=\"editContact('{temp.Id}', '{temp.FirstName}', '{temp.LastName}', '{temp.Ssn}')\">Edit Contact</a></td>";
                test += $"<td><a href=\".\\editContact.aspx?id={temp.Id}\">Edit Phone</a></td>";
                test += $"<td><a href=\".\\main.aspx?delete={temp.Id}\">Delete</a></td>";
                test += "</tr>";
            }
            test += "</tbody>";
            test += "</table>";
            test += "</div>";

            mainlit.Text = test;
        }

        
    }
}
