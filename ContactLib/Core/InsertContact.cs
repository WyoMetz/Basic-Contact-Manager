using ContactLib.Core;
using System;

namespace ContactLib
{
    public class InsertContact : Transaction
    {
        private Contact Contact = new Contact();

        public InsertContact(Contact contact)
        {
            Contact = contact;
        }

        public string Insert()
        {
            SQLProcessor sQL = new SQLProcessor(Contact);
            Contact.ID = Convert.ToInt32(DbCommand(sQL.InsertContact()));
            return "Complete";
        }
    }
}
