﻿namespace LifeLineDemo.Domain.DTO
{
    public class UserDto
    {
        public long Id { get; set; }
        public long PhoneNumber { get; set; }
        public string? Email { get; set; }
        public long RoleId { get; set; }
    }
}
