using AutoMapper;
using MinhasFinancas.DTO.User;
using MinhasFinancas.Models;

namespace MinhasFinancas.Profiles;

class UserProfile : Profile {
    public UserProfile()
    {
        CreateMap<CreateUserDto, User>();
        CreateMap<User,ReadUserDto>();
    }
}