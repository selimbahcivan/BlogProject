using AutoMapper;
using Entities.Concrete;
using Entities.DTOs;

namespace CoreMVC.AutoMapper.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserAddDto, User>();
            CreateMap<User, UserUpdateDto>();
        }
    }
}
