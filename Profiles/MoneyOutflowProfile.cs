using System;
using AutoMapper;
using MinhasFinancas.DTO.CreateMoneyOutflowDto;
using MinhasFinancas.Models;

namespace MinhasFinancas.Profiles;

public class MoneyOutflowProfile : Profile
{
    public MoneyOutflowProfile()
    {
        CreateMap<CreateMoneyOutflowDto, MoneyOutflow>()
        .ForMember(dest => dest.PaymentMethod, opt => opt.MapFrom(src => new MoneyOutflow.PaymentMethods { Value = src.PaymentMethod }))
        .ForMember(dest => dest.PaymentCategory, opt => opt.MapFrom(src => new MoneyOutflow.PaymentCategories { Value = src.PaymentCategory }));
    }
}
