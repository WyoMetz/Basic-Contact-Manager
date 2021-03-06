﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactLib;
using ContactLib.Core;

namespace TesterInterface
{
    class ContactInsertTest
    {
        private Contact Contact { get; set; }
        List<PhoneNumber> phoneNumber = new List<PhoneNumber>();
        List<EmailAddress> email = new List<EmailAddress>();

        PhoneNumber Number = new PhoneNumber()
        {
            Number = "8675309"
        };

        EmailAddress emailAddress = new EmailAddress()
        {
            Email = "Jason.Borne@identity.com"
        };

        Contact contact = new Contact()
        {
            LastName = "Borne",
            FirstName = "Jason",
            MI = "B"
            //Company = "UnKnown"
        };

        public ContactInsertTest()
        {
            build();
        }

        private void build()
        {
            Contact = contact;
            phoneNumber.Add(Number);
            email.Add(emailAddress);
            contact.PhoneNumber = phoneNumber;
            contact.EmailAddress = email;
        }

        public void execute()
        {
            InsertContact insert = new InsertContact(Contact);
            try
            {
                insert.Insert();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Executing " + ex.Message.ToString());
            }
            SQLProcessor processor = new SQLProcessor(Contact);
            Console.WriteLine(processor.InsertContact());
            Console.WriteLine(processor.InsertPhoneNumbers());
            Console.WriteLine(processor.InserEmails());
        }

        
    }
}
