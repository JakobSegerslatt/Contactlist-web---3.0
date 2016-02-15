using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contactlist_web___3._0
{
    public class ContactDetails
    {
        string id;
        string type;
        string value;

        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        public string Value
        {
            get
            {
                return value;
            }

            set
            {
                this.value = value;
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

        public ContactDetails(string type, string value, string id)
        {
            this.Type = type;
            this.Value = value;
            this.Id = id;
        }

        public override string ToString()
        {
            return Type + " " + Value;
        }
    }
}