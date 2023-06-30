using System;
using AutoMapper;
using Backend.DTO.FixedExpense;
using MinhasFinancas.DTO.FixedExpense;
using MinhasFinancas.Models;

namespace MinhasFinancas.Services;

public class FixedExpenseService
{
    private IMapper _mapper;
    private AppDbContext _appDbContext;

    public FixedExpenseService(IMapper mapper, AppDbContext appContext)
    {
        _mapper = mapper;
        _appDbContext = appContext;
    }

    public ReadFixedExpenseDto Register(CreateFixedExpenseDto expenseDto, User user) {
        var fixedExpense = _mapper.Map<FixedExpense>(expenseDto);
        fixedExpense.UserId = user.Id;
        fixedExpense.User = user;

        _appDbContext.FixedExpenses.Add(fixedExpense);
        _appDbContext.SaveChanges();

        return _mapper.Map<ReadFixedExpenseDto>(fixedExpense);
    }
}
