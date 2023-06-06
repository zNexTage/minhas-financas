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
    public ReadMoneyInflowDto Register(CreateMoneyInflowDto moneyInflowDto, User user){
        var moneyInflow = _mapper.Map<MoneyInflow>(moneyInflowDto);
        moneyInflow.User = user;
        moneyInflow.UserId = user.Id;

        _appDbContext.MoneyInflows.Add(moneyInflow);
        _appDbContext.SaveChanges();

        return _mapper.Map<ReadMoneyInflowDto>(moneyInflow);
    }

    public ReadMoneyInflowDto GetById(int id){
        var moneyInflow = _appDbContext.MoneyInflows.FirstOrDefault(moneyInflow => moneyInflow.Id == id);

        if(moneyInflow == null) {
            throw new MoneyInflow.DoesNotExists($"Não foi localizado uma entrada de id {id}");
        }

        return _mapper.Map<ReadMoneyInflowDto>(moneyInflow);
    }

    public List<ReadMoneyInflowDto> GetAll(string userId){
        var moneyInfows = _appDbContext.MoneyInflows.ToList()
        .Where(mi => mi.UserId == userId);

        return _mapper.Map<List<ReadMoneyInflowDto>>(moneyInfows);
    }
}
