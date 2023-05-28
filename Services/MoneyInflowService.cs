using System;
using MinhasFinancas.Models;
using MinhasFinancas.DTO.MoneyInflow;
using AutoMapper;

namespace MinhasFinancas.Services;

public class MoneyInflowService
{
    private IMapper _mapper;
    private AppDbContext _appDbContext;

    public MoneyInflowService(IMapper mapper, AppDbContext appDbContext)
    {
        _mapper = mapper;
        _appDbContext = appDbContext;
    }
    public MoneyInflow Register(CreateMoneyInflowDto moneyInflowDto){
        var moneyInflow = _mapper.Map<MoneyInflow>(moneyInflowDto);

        _appDbContext.MoneyInflows.Add(moneyInflow);
        _appDbContext.SaveChanges();

        return moneyInflow;
    }
}
