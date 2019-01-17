using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactLib.Core
{
    public class UpdateContact : Transaction
    {
        private Contact Contact = new Contact();

        public UpdateContact(Contact contact)
        {
            Contact = contact;
        }

        public void Update()
        {
            string Update = "UPDATE Contacts SET";
            string UpdateStatement;
            if(Contact.MI != null)
            {
                UpdateStatement = $"{Update} FirstName = {Contact.FirstName}, LastName = {Contact.LastName}, MI = {Contact.MI}, VIP = {Contact.VIP} WHERE ID = {Contact.ID}";
            }
            else
            {
                UpdateStatement = $"{Update} FirstName = {Contact.FirstName}, LastName = {Contact.LastName}, VIP = {Contact.VIP} WHERE ID = {Contact.ID}";
            }
            DbCommand(UpdateStatement);
        }
    }
}
