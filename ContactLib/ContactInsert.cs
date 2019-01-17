using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactLib
{
    public class ContactInsert
    {
        DatabaseController databaseController = new DatabaseController();

        public string ContactInsertCommand(Contact contact)
        {
            string ContactInsert = "INSERT INTO Contacts";
            string InsertStatement;
            if(contact.MI != null)
            {
                InsertStatement = $"{ContactInsert} (FirstName, LastName, MI, VIP) VALUES ('{contact.FirstName}', '{contact.LastName}', '{contact.MI}', '{contact.VIP}')";
            }
            else
            {
                InsertStatement = $"{ContactInsert} (FirstName, LastName, VIP) VALUES ('{contact.FirstName}', '{contact.LastName}', '{contact.VIP}')";
            }
            contact.ID = Convert.ToInt32(databaseController.DbCommand(InsertStatement));
            PhoneNumberInsert(contact);
            EmailAddressInsert(contact);
            return "Needs Completed.";
        }

        public void PhoneNumberInsert(Contact contact)
        {
            if(contact.PhoneNumber != null)
            {
                foreach (var number in contact.PhoneNumber)
                {
                    string Insert = $"INSERT INTO PhoneNumbers (PhoneNumber, ContactID) VALUES ('{number.Number}', '{contact.ID}')";
                    long ID = databaseController.DbCommand(Insert);
                    number.NumberID = Convert.ToInt32(ID);
                }
            }
        }

        public void EmailAddressInsert(Contact contact)
        {
            if(contact.EmailAddress != null)
            {
                foreach (var email in contact.EmailAddress)
                {
                    string Insert = $"INSERT INTO EmailAddresses (EmailAddress, ContactID) VALUES ('{email.Email}', {contact.ID}')";
                    long ID = databaseController.DbCommand(Insert);
                    email.EmailID = Convert.ToInt32(ID);
                }
            }
        }
    }
}
