using System;
using Microsoft.AspNetCore.Mvc;
using MinhasFinancas.DTO.User;
using MinhasFinancas.Services;

namespace MinhasFinancas.Controllers;

[ApiController]
[Route("[Controller]")]
public class UserController : ControllerBase
{
    private UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(CreateUserDto userDto)
    {
        var result = await _userService.Register(userDto);

        if (result.Succeeded)
        {
            return Created("", "Usuário criado com sucesso");
        }

        return BadRequest(result.Errors);
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginUserDto loginUser)
    {
        try
        {
            var tokenDto = await _userService.Login(loginUser);

            return Ok(tokenDto);
        }
        catch (Exception err)
        {
            return Unauthorized(err.Message);
        }
    }
}
