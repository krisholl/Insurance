using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class User
    {
        public User()
        {
            ClaimDoctorNavigations = new HashSet<Claim>();
            ClaimPatientNavigations = new HashSet<Claim>();
            ClaimPolicyNavigations = new HashSet<Claim>();
            Policies = new HashSet<Policy>();
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? MiddleInit { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Role { get; set; }
        public int? ContactIdFk { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual Contact? ContactIdFkNavigation { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<Claim> ClaimDoctorNavigations { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<Claim> ClaimPatientNavigations { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<Claim> ClaimPolicyNavigations { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<Policy> Policies { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
