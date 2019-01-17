using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            string ContactInsert = "INSERT INTO Contacts";
            string InsertStatement;
            if(Contact.MI != null)
            {
                InsertStatement = $"{ContactInsert} (FirstName, LastName, MI, VIP) VALUES ('{Contact.FirstName}', '{Contact.LastName}', '{Contact.MI}', '{Contact.VIP}')";
            }
            else
            {
                InsertStatement = $"{ContactInsert} (FirstName, LastName, VIP) VALUES ('{Contact.FirstName}', '{Contact.LastName}', '{Contact.VIP}')";
            }
            Contact.ID = Convert.ToInt32(DbCommand(InsertStatement));
            InsertPhoneNumber();
            InsertEmailAddress();
            return "Needs Completed.";
        }

        public void InsertPhoneNumber()
        {
            if(Contact.PhoneNumber != null)
            {
                foreach (var number in Contact.PhoneNumber)
                {
                    string Insert = $"INSERT INTO PhoneNumbers (PhoneNumber, ContactID) VALUES ('{number.Number}', '{Contact.ID}')";
                    long ID = DbCommand(Insert);
                    number.NumberID = Convert.ToInt32(ID);
                }
            }
        }

        public void InsertEmailAddress()
        {
            if(Contact.EmailAddress != null)
            {
                foreach (var email in Contact.EmailAddress)
                {
                    string Insert = $"INSERT INTO EmailAddresses (EmailAddress, ContactID) VALUES ('{email.Email}', '{Contact.ID}')";
                    long ID = DbCommand(Insert);
                    email.EmailID = Convert.ToInt32(ID);
                }
            }
        }
    }
}
