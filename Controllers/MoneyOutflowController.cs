using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MinhasFinancas.DTO.CreateMoneyOutflowDto;
using MinhasFinancas.Models;
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
    [Authorize(AuthenticationSchemes = "Bearer")]
    public IActionResult Register([FromBody] CreateMoneyOutflowDto moneyOutflowDto){
        var moneyOutflow = _moneyOutflowService.Register(moneyOutflowDto);

        return CreatedAtAction(nameof(GetById),  new { id = moneyOutflow.Id }, moneyOutflow);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpGet]
    public IActionResult GetAll(){
        return Ok(_moneyOutflowService.GetAll());
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpGet("{id}")]
    public IActionResult GetById(int id){
        try{
            var moneyOutflow = _moneyOutflowService.GetById(id);

            return Ok(moneyOutflow);
        }
        catch(MoneyOutflow.DoesNotExists err){
            return NotFound(err.Message);
        }
    }
}
