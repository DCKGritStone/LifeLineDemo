﻿using LifeLineDemo.Domain.Entities.Audit;

namespace LifeLineDemo.Domain.Entities
{
    public class User : FullAuditedEntity<long>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public int Pincode { get; set; }
        public char Gender { get; set; }
        public DateTime? Dob { get; set; }
        public string? BloodGroup { get; set; }
        public string? LicenseNumber { get; set; }
        public DateTime? LicenseExpiryDate { get; set; }
        public bool IsAvailable { get; set; }
        public long RoleId { get; set; }
        public Role? Role { get; set; }
    }
}
