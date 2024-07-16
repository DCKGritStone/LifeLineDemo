namespace LifeLineDemo.Domain.DTO
{
    public class CredDto
    {
        public long Id { get; set; }
        public string? Password { get; set; }
        public string? PasswordKey { get; set; }
        public long UserId { get; set; }
    }
}
