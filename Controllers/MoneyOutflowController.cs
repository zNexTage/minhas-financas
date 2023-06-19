using System;
using System.Security.Claims;
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
    private UserService _userService;

    public MoneyOutflowController(
        MoneyOutflowService moneyOutflowService,
        UserService userService
        )
    {
        _moneyOutflowService = moneyOutflowService;
        _userService = userService;
    }

    [HttpPost("Register")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public async Task<IActionResult> Register([FromBody] CreateMoneyOutflowDto moneyOutflowDto){
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;

        var user = await _userService.GetById(userId);
        
        var moneyOutflow = _moneyOutflowService.Register(moneyOutflowDto, user);

        return CreatedAtAction(nameof(GetById),  new { id = moneyOutflow.Id }, moneyOutflow);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpGet]
    public IActionResult GetAll([FromQuery]int? month, [FromQuery]int? year){
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;

        var moneyOutflows = _moneyOutflowService.GetAll(userId, month, year);

        return Ok(moneyOutflows);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpGet("{id}")]
    public IActionResult GetById(int id){
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;

        try{            
            var moneyOutflow = _moneyOutflowService.GetById(id);

            if(moneyOutflow.User.Id != userId){
                return Unauthorized("Você não tem acesso a essa transação.");
            }

            return Ok(moneyOutflow);
        }
        catch(MoneyOutflow.DoesNotExists err){
            return NotFound(err.Message);
        }
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpGet("TotalByPeriod")]    
    public IActionResult GetTotalByPeriod([FromQuery] int month, [FromQuery] int year){
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;

        return Ok(_moneyOutflowService.GetTotalByPeriod(userId, month, year));
    }
}
