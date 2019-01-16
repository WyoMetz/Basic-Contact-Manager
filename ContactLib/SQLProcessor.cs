using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactLib
{
    public class SQLProcessor
    {
        DatabaseController databaseController = new DatabaseController();

        public void CreateTables()
        {
            string ContactTable = "CREATE TABLE IF NOT EXISTS Contacts (ID INTEGER PRIMARY KEY AUTOINCREMENT, FirstName VARCHAR(50) NOT NULL, LastName VARCHAR(80) NOT NULL, MI VARCHAR(3), VIP BOOL)";
            databaseController.DbCommand(ContactTable);
        }

        public string InsertCommand(ContactModel contact)
        {
            string ContactInsert = "INSERT INTO Contacts";
            string miNull = "(FirstName, LastName, VIP)";
            string InsertStatement;
            if(contact.MI != null)
            {
                InsertStatement = $"{ContactInsert} (FirstName, LastName, MI, VIP) VALUES ('{contact.FirstName}', '{contact.LastName}', '{contact.MI}', '{contact.VIP}')";
            }
            else
            {
                InsertStatement = $"{ContactInsert} (FirstName, LastName, VIP) VALUES ('{contact.FirstName}', '{contact.LastName}', '{contact.VIP}')";
            }

        }
    }
}
