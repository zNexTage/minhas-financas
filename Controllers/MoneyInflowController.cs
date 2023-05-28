using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MinhasFinancas.DTO.MoneyInflow;
using MinhasFinancas.Models;

namespace MinhasFinancas.Controllers;

[ApiController]
[Route("[Controller]")]
public class MoneyInflowController : ControllerBase{
    private AppDbContext _appDbContext;
    private IMapper _mapper;

    public MoneyInflowController(AppDbContext appDbContext, IMapper mapper)
    {
        _appDbContext = appDbContext;
        _mapper = mapper;
    }


    [HttpPost("Register")]
    public IActionResult Register([FromBody] CreateMoneyInflowDto moneyInflowDto){
        var moneyInflow = _mapper.Map<MoneyInflow>(moneyInflowDto);

        _appDbContext.MoneyInflows.Add(moneyInflow);
        _appDbContext.SaveChanges();
        
        return Created("", moneyInflow);
    }
}