using System;
using System.Collections.Generic;

namespace Domain
{
    public class Contact
    {
        public Contact()
        {
            SocialNetworks = new List<SocialNetwork>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public IList<SocialNetwork> SocialNetworks { get; set; }
    }
}