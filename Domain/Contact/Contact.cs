using System;

namespace Domain.Contact
{
    public class Contact : IContact
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
    }
}