using System;
using System.Collections.Generic;
using System.Text;

namespace ContactLib.Core
{
    public class SQLProcessor : Transaction
    {
        private Contact Contact { get; set; }
        private StringBuilder builder = new StringBuilder();
        private Type ContactValue = typeof(Contact);
        private Type PhoneType = typeof(PhoneNumber);
        private Type EmailType = typeof(EmailAddress);

        private IList<string> ContactColumns = new List<string>();
        private IList<string> ContactValues = new List<string>();
        private IList<string> PhoneColumns = new List<string>();
        private IList<string> PhoneValues = new List<string>();
        private IList<string> EmailColumns = new List<string>();
        private IList<string> EmailValues = new List<string>();

        public SQLProcessor(Contact contact)
        {
            Contact = contact;
            ValueBuilder();
        }

        public string InsertContact()
        {
            builder.Append("INSERT INTO Contacts (");

            foreach (var item in ContactColumns)
            {
                builder.Append($"{item}, ");
            }

            builder.Remove(builder.Length - 2, 2);
            builder.Append(") VALUES (");

            foreach (var item in ContactValues)
            {
                builder.Append($"'{item}', ");
            }

            builder.Remove(builder.Length - 2, 2);
            builder.Append(")");

            Contact.ID = Convert.ToInt32(DbCommand(builder.ToString()));
            return builder.ToString();
        }

        public string InsertPhoneNumbers()
        {
            builder.Clear();
            if (PhoneValues.Count > 0)
            {
                builder.Append("INSERT INTO PhoneNumbers (");

                foreach (var item in PhoneColumns)
                {
                    builder.Append($"{item}, ");
                }

                builder.Append("ContactID) VALUES (");

                foreach (var item in PhoneValues)
                {
                    builder.Append($"'{item}', ");
                }

                builder.Append($"'{Contact.ID}'");
                builder.Append(")");
            }
            return builder.ToString();
        }

        public string InserEmails()
        {
            builder.Clear();
            if (EmailValues.Count > 0)
            {
                builder.Append("INSERT INTO Emails (");

                foreach (var item in EmailColumns)
                {
                    builder.Append($"{item}, ");
                }

                builder.Append("ContactID) VALUES (");

                foreach (var item in EmailValues)
                {
                    builder.Append($"'{item}', ");
                }

                builder.Append($"'{Contact.ID}')");

            }
            return builder.ToString();
        }

        private void ValueBuilder()
        {
            foreach (var value in ContactValue.GetProperties())
            {
                if (value.Name != "PhoneNumber" && value.Name != "EmailAddress" && value.Name != "ID")
                {
                    if (value.GetValue(Contact, null) != null)
                    {
                        ContactColumns.Add($"{value.Name}");
                        ContactValues.Add($"{value.GetValue(Contact, null)}");
                    }
                }

                if (value.Name == "PhoneNumber")
                {
                    foreach (var phone in Contact.PhoneNumber)
                    {
                        foreach (var number in PhoneType.GetProperties())
                        {
                            if (number.Name != "ContactID" && number.Name != "NumberID")
                            {
                                PhoneColumns.Add($"{number.Name}");
                                PhoneValues.Add($"{number.GetValue(phone, null)}");
                            }
                        }
                    }
                }

                if (value.Name == "EmailAddress")
                {
                    foreach (var emails in Contact.EmailAddress)
                    {
                        foreach (var email in EmailType.GetProperties())
                        {
                            if (email.Name != "EmailID" && email.Name != "ContactID")
                            {
                                EmailColumns.Add($"{email.Name}");
                                EmailValues.Add($"{email.GetValue(emails, null)}");
                            }
                        }
                    }
                }

            }
        }
    }
}
