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

    public ReadMoneyOutflowDto Register(CreateMoneyOutflowDto moneyOutflowDto, User user){
        var moneyOutflow = _mapper.Map<MoneyOutflow>(moneyOutflowDto);
        moneyOutflow.User = user;
        moneyOutflow.UserId = user.Id;

        _appDbContext.MoneyOutflows.Add(moneyOutflow);
        _appDbContext.SaveChanges();

        return _mapper.Map<ReadMoneyOutflowDto>(moneyOutflow);
    }

    public List<ReadMoneyOutflowDto> GetAll(string userId){
        var moneyOutflows = _appDbContext.MoneyOutflows.ToList()
        .Where(moneyOutflow => moneyOutflow.UserId == userId);

        return _mapper.Map<List<ReadMoneyOutflowDto>>(moneyOutflows);
    }

    public ReadMoneyOutflowDto GetById(int id){
        var moneyOutflow = _appDbContext.MoneyOutflows.FirstOrDefault(moneyOut => moneyOut.Id == id);

        if(moneyOutflow == null) throw new MoneyOutflow.DoesNotExists($"Não foi encotrado um registro com id {id}");

        return _mapper.Map<ReadMoneyOutflowDto>(moneyOutflow);
    }
}
