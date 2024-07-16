using LifeLineDemo.Domain.Entities.Audit;

namespace LifeLineDemo.Domain.Entities
{
    public class Role : FullAuditedEntity<long>
    {
        public string? RoleName { get; set; }
    }
}
