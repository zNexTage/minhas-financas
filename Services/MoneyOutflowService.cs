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
    
    /// <summary>
    /// Get all MoneyOutflow from the logged user and filtering by month and year.
    /// if the month or year is empty, it will be set with the current month and year
    /// </summary>
    public List<ReadMoneyOutflowDto> GetAll(string userId, int? month, int? year){
        if(month == null){
            month = DateTime.Now.Month;
        }

        if(year == null){
            year = DateTime.Now.Year;
        }
        
        var moneyOutflows = _appDbContext.MoneyOutflows.ToList()
        .Where(moneyOutflow => moneyOutflow.UserId == userId 
        && moneyOutflow.Date.Month == month && moneyOutflow.Date.Year == year);

        return _mapper.Map<List<ReadMoneyOutflowDto>>(moneyOutflows);
    }

    public ReadMoneyOutflowDto GetById(int id){
        var moneyOutflow = _appDbContext.MoneyOutflows.FirstOrDefault(moneyOut => moneyOut.Id == id);

        if(moneyOutflow == null) throw new MoneyOutflow.DoesNotExists($"Não foi encotrado um registro com id {id}");

        return _mapper.Map<ReadMoneyOutflowDto>(moneyOutflow);
    }
}
