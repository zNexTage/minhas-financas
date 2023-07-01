using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MinhasFinancas.DTO.FixedExpense;
using MinhasFinancas.Services;

namespace MinhasFinancas.Controllers;

[ApiController]
[Route("[Controller]")]
public class FixedExpenseController : ControllerBase
{
    private FixedExpenseService _fixedExpenseService;
    private UserService _userService;
    
    public FixedExpenseController(
        FixedExpenseService fixedExpenseService,
        UserService userService
    )
    {
        _fixedExpenseService = fixedExpenseService;
        _userService = userService;
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] CreateFixedExpenseDto fixedExpenseDto){
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;

        var user = await _userService.GetById(userId);
        
        var fixedExpense = _fixedExpenseService.Register(fixedExpenseDto, user);

        return Created("", fixedExpense);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpGet]
    public async Task<IActionResult> GetAll(){
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;

        var user = await _userService.GetById(userId);

        var fixedExpenses = _fixedExpenseService.GetAll(user.Id);

        return Ok(fixedExpenses);
    }
}
