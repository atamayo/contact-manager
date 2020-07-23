using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class SocialNetwork
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProfileLink { get; set; }
        public Contact Contact { get; set; }
        public int ContactId { get; set; }
    }
}