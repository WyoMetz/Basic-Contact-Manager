using System.Collections.Generic;

namespace ContactLib
{
    public class Contact
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MI { get; set; }
        public List<PhoneNumber> PhoneNumber { get; set; }
        public List<EmailAddress> EmailAddress { get; set; }
        public string Company { get; set; }
        public bool VIP { get; set; }
    }
}
