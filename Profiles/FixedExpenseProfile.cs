using System;
using AutoMapper;
using Backend.DTO.FixedExpense;
using MinhasFinancas.DTO.FixedExpense;
using MinhasFinancas.Enum;
using MinhasFinancas.Models;

namespace Backend.Profiles;

public class FixedExpenseProfile : Profile
{
    public FixedExpenseProfile()
    {
        CreateMap<FixedExpense, ReadFixedExpenseDto>()
        .ForMember(dto => dto.PaymentCategory, opt => opt.MapFrom(src => src.PaymentCategory.Value));

        

        CreateMap<CreateFixedExpenseDto, FixedExpense>()
        .ForMember(dest => dest.PaymentCategory, opt => opt.MapFrom(src => new PaymentCategories { Value = src.PaymentCategory }));
    }
}
