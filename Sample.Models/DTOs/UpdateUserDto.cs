using System;

namespace Sample.Models.DTOs
{
    public class UpdateUserDto
    {
        public Guid UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? Age { get; set; }
    }
}
