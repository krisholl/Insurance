using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Ticket
    {
        public int Id { get; set; }
        public int Claim { get; set; }
        public int Patient { get; set; }
        public int Policy { get; set; }
        public string Notes { get; set; } = null!;

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual Claim? ClaimNavigation { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual User? PatientNavigation { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual Policy? PolicyNavigation { get; set; }
    }
}
