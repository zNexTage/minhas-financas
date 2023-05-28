using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MinhasFinancas.DTO.MoneyInflow;
using MinhasFinancas.Models;
using MinhasFinancas.Services;

namespace MinhasFinancas.Controllers;

[ApiController]
[Route("[Controller]")]
public class MoneyInflowController : ControllerBase{
    private MoneyInflowService _moneyInflowService;

    public MoneyInflowController(MoneyInflowService moneyInflowService)
    {
        _moneyInflowService = moneyInflowService;
    }


    [HttpPost("Register")]
    public IActionResult Register([FromBody] CreateMoneyInflowDto moneyInflowDto){
        var moneyInflow = _moneyInflowService.Register(moneyInflowDto);
        
        // TODO: Pass the URL to find the registered item
        return Created("", moneyInflow);
    }
}