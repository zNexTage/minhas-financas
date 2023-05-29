using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MinhasFinancas.DTO.MoneyInflow;
using MinhasFinancas.Models;
using MinhasFinancas.Services;

namespace MinhasFinancas.Controllers;

[ApiController]
[Route("[Controller]")]
public class MoneyInflowController : ControllerBase
{
    private MoneyInflowService _moneyInflowService;

    public MoneyInflowController(MoneyInflowService moneyInflowService)
    {
        _moneyInflowService = moneyInflowService;
    }


    [HttpPost("Register")]
    public IActionResult Register([FromBody] CreateMoneyInflowDto moneyInflowDto)
    {
        var moneyInflow = _moneyInflowService.Register(moneyInflowDto);
        
        return CreatedAtAction(nameof(Get), new { id = moneyInflow.Id }, moneyInflow);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        try
        {
            var moneyInflow = _moneyInflowService.GetById(id);

            return Ok(moneyInflow);
        }
        catch (MoneyInflow.DoesNotExists err)
        {
            return NotFound(err.Message);
        }
    }
}