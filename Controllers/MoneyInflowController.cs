using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    private UserService _userService;

    public MoneyInflowController(MoneyInflowService moneyInflowService, UserService userService)
    {
        _moneyInflowService = moneyInflowService;
        _userService = userService;
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] CreateMoneyInflowDto moneyInflowDto)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;

        var user = await _userService.GetById(userId);
        
        var moneyInflow = _moneyInflowService.Register(moneyInflowDto, user);
        
        return CreatedAtAction(nameof(GetById), new { id = moneyInflow.Id }, moneyInflow);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;

        try
        {
            var moneyInflow = _moneyInflowService.GetById(id);

            if(moneyInflow.User.Id != userId){
                return Unauthorized("Você não tem acesso a essa transação");
            }

            return Ok(moneyInflow);
        }
        catch (MoneyInflow.DoesNotExists err)
        {
            return NotFound(err.Message);
        }
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpGet]
    public IActionResult GetAll([FromQuery] int? month, [FromQuery] int? year){
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;

        return Ok(_moneyInflowService.GetAll(userId, month, year));
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpGet("TotalByPeriod")]
    public IActionResult GetTotalByPeriod([FromQuery] int month, [FromQuery] int year){
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;

        var total = _moneyInflowService.GetTotalByPeriod(userId, month, year);

        return Ok(total);
    }
}