using LifeLineDemo.Domain.Entities.Audit;

namespace LifeLineDemo.Domain.Entities
{
    public class Hospital : FullAuditedEntity<long>
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool EmergencyServicesAvailable { get; set; }
        public int AmbulanceCount { get; set; }
        public string? Specializations { get; set; }
        public double Rating { get; set; }
    }
}
