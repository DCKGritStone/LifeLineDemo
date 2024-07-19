namespace LifeLineDemo.Domain.Entities
{
    public class Credentials
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? PasswordKey { get; set; }
        public long UserId { get; set; }
        public User? User { get; set; }
    }
}
