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
    public ReadMoneyInflowDto Register(CreateMoneyInflowDto moneyInflowDto, User user)
    {
        var moneyInflow = _mapper.Map<MoneyInflow>(moneyInflowDto);
        moneyInflow.User = user;
        moneyInflow.UserId = user.Id;

        _appDbContext.MoneyInflows.Add(moneyInflow);
        _appDbContext.SaveChanges();

        return _mapper.Map<ReadMoneyInflowDto>(moneyInflow);
    }

    public ReadMoneyInflowDto GetById(int id)
    {
        var moneyInflow = _appDbContext.MoneyInflows.FirstOrDefault(moneyInflow => moneyInflow.Id == id);

        if (moneyInflow == null)
        {
            throw new MoneyInflow.DoesNotExists($"Não foi localizado uma entrada de id {id}");
        }

        return _mapper.Map<ReadMoneyInflowDto>(moneyInflow);
    }
    ///<summary>
    /// Get all MoneyInflow from the logged user filtering by month and year;
    /// if the month or year is empty, it will be set with the current month and year
    ///</summary>
    public List<ReadMoneyInflowDto> GetAll(string userId, int? month, int? year)
    {
        if (month == null)
        {
            month = DateTime.Now.Month;
        }

        if (year == null)
        {
            year = DateTime.Now.Year;
        }

        var moneyInflows = _appDbContext.MoneyInflows.ToList()
        .Where(mi => mi.UserId == userId &&
        mi.Date.Month == month &&
        mi.Date.Year == year
        );

        return _mapper.Map<List<ReadMoneyInflowDto>>(moneyInflows);
    }

    ///<summary>
    /// Get the total of money inflows from a logged user in a determined period.
    ///</summary>
    public double GetTotalByPeriod(string userId, int month, int year)
    {
        double total = _appDbContext.MoneyInflows
        .Where(moneyInflow => moneyInflow.UserId == userId &&
        moneyInflow.Date.Month == month && moneyInflow.Date.Year == year
        )
        .Sum(moneyInflow => moneyInflow.Value);

        return total;
    }
}
