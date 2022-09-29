using AutoMapper;
using DomainEntities.Users;
using DTO.Users;

namespace Configuration.AutoMapper
{
    public class UserProfile : Profile
    {
        #region constructors

        public UserProfile()
        {
            CreateMap<UserDTO, User>().ForMember(dest => dest.Id, opt => opt.MapFrom(src=> src.Id))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName));

            CreateMap<User,UserDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName));
        }

        #endregion
    }
}
