using AutoMapper;
using Sample.Models.DTOs;
using Sample.Models.Entities;

namespace Sample.Models.Mapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<AddUserDto, User>()
                .ForMember(d => d.FullName, o => o.MapFrom(s => s.FullName.Trim()))
                .ForMember(d => d.Email, o => o.MapFrom(s => s.Email.Trim().ToLower()))
                .ForMember(d => d.Phone, o => o.MapFrom(s => string.IsNullOrEmpty(s.Phone) ? null : s.Phone.Trim()));
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
