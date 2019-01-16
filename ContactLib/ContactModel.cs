using System.Collections.Generic;

namespace ContactLib
{
    public class ContactModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MI { get; set; }
        public List<string> PhoneNumber { get; set; }
        public List<string> EmailAddress { get; set; }
        public string Company { get; set; }
        public bool VIP { get; set; }
    }
}
