using AutoMapper;
using AutoMapper.Configuration.Annotations;
using WebProject.Dto;

namespace WebProject.Entities
{
    [AutoMap(typeof(UserDto))]
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        [Ignore]
        public byte[]? Password { get; set; }

        public string? address { get; set; }

        public DateOnly CreatedAt { get; set; }
        public DateOnly UpdatedAt { get; set; }
    }
}