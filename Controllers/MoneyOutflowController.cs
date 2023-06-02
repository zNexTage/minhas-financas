using System;
using Microsoft.AspNetCore.Mvc;
using MinhasFinancas.DTO.CreateMoneyOutflowDto;
using MinhasFinancas.Services;

namespace MinhasFinancas.Controllers;

[ApiController]
[Route("[Controller]")]
public class MoneyOutflowController : ControllerBase
{   
    private MoneyOutflowService _moneyOutflowService;

    public MoneyOutflowController(MoneyOutflowService moneyOutflowService)
    {
        _moneyOutflowService = moneyOutflowService;
    }

    [HttpPost("Register")]
    public IActionResult Register([FromBody] CreateMoneyOutflowDto moneyOutflowDto){
        var moneyOutflow = _moneyOutflowService.Register(moneyOutflowDto);

        return Created("", moneyOutflow);
    }
}
