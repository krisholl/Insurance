using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Contact
    {
        public Contact()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public bool PoOrStreet { get; set; }
        public int PoNumber { get; set; }
        public int StreetNumber { get; set; }
        public string StreetName { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public int Zipcode { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<User> Users { get; set; }
    }
}
