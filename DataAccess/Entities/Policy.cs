using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Policy
    {
        public Policy()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public int Insurance { get; set; }
        public string Coverage { get; set; } = null!;

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual User? InsuranceNavigation { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
