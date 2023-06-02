using System;
using AutoMapper;
using MinhasFinancas.DTO.CreateMoneyOutflowDto;
using MinhasFinancas.DTO.MoneyOutflow;
using MinhasFinancas.Models;

namespace MinhasFinancas.Services;

public class MoneyOutflowService
{
    private IMapper _mapper;
    private AppDbContext _appDbContext;

    public MoneyOutflowService(IMapper mapper, AppDbContext appDbContext)
    {
        _mapper = mapper;
        _appDbContext = appDbContext;
    }

    public MoneyOutflow Register(CreateMoneyOutflowDto moneyOutflowDto){
        var moneyOutflow = _mapper.Map<MoneyOutflow>(moneyOutflowDto);

        _appDbContext.MoneyOutflows.Add(moneyOutflow);
        _appDbContext.SaveChanges();

        return moneyOutflow;
    }

    public List<ReadMoneyOutflowDto> GetAll(){
        var moneyOutflows = _appDbContext.MoneyOutflows.ToList();

        return _mapper.Map<List<ReadMoneyOutflowDto>>(moneyOutflows);
    }
}
