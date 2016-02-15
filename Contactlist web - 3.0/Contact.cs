using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contactlist_web___3._0
{
    public class Contact
    {
        private string firstName;
        string lastName;
        string ssn;
        string id;
        public List<ContactDetails> myDetails;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                lastName = value;
            }
        }

        public string Ssn
        {
            get
            {
                return ssn;
            }

            set
            {
                ssn = value;
            }
        }

        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public Contact(string fn, string ln, string ssn, string id)
        {
            FirstName = fn;
            LastName = ln;
            this.Ssn = ssn;
            this.Id = id;
            myDetails = new List<ContactDetails>();
        }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}