using LifeLineDemo.Domain.Entities.Audit;

namespace LifeLineDemo.Domain.Entities
{
    public class UserRoles : FullAuditedEntity<long>
    {
        public long UserId { get; set; }
        public User? User { get; set; }
        public long RoleId { get; set; }
        public Role? Role { get; set; }
    }
}
