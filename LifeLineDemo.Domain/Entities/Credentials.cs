using LifeLineDemo.Domain.Entities.Audit;

namespace LifeLineDemo.Domain.Entities
{
    public class Credentials : FullAuditedEntity<long>
    {
        public string? Password { get; set; }
        public string? PasswordKey { get; set; }
        public long UserId { get; set; }
        public User? User { get; set; }
    }
}
