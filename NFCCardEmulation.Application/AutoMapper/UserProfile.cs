using AutoMapper;
using NFCCardEmulation.Application.Users.Commands;
using NFCCardEmulation.Application.Users.Models;
using NFCCardEmulation.Domain.Entities;

namespace NFCCardEmulation.Application.AutoMapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterUserCommand, User>();

            CreateMap<UserDetailsModel, User>()
                .ForMember(dest => dest.PasswordHash, src => src.Ignore())
                .ForMember(dest => dest.PasswordSalt, src => src.Ignore())
                .ReverseMap();

            CreateMap<User, LoginUserModel>();

        }
    }
}
