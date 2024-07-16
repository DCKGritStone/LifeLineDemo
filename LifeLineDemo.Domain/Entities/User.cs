using LifeLineDemo.Domain.Entities.Audit;

namespace LifeLineDemo.Domain.Entities
{
    public class User : FullAuditedEntity<long>
    {
        public string? UserName { get; set; }
        public long PhoneNumber { get; set; }
        public string? Email { get; set; }
        public long RoleId { get; set; }
        public Role? Role { get; set; }
    }
}
