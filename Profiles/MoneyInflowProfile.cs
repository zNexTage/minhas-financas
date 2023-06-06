using System;
using AutoMapper;
using MinhasFinancas.DTO.MoneyInflow;
using MinhasFinancas.Models;

namespace MinhasFinancas.Profiles;

public class MoneyInflowProfile : Profile
{
    public MoneyInflowProfile()
    {
        CreateMap<CreateMoneyInflowDto, MoneyInflow>();  

        CreateMap<MoneyInflow, ReadMoneyInflowDto>()
        .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User));
    }
}
