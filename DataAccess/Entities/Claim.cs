using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Claim
    {
        public Claim()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public int? Patient { get; set; }
        public int? Doctor { get; set; }
        public int? Policy { get; set; }
        public string ReasonForVisit { get; set; } = null!;
        public string Status { get; set; } = null!;

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual User? DoctorNavigation { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual User? PatientNavigation { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual User? PolicyNavigation { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
