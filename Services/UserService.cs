using System;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MinhasFinancas.DTO.User;
using MinhasFinancas.Models;

namespace MinhasFinancas.Services;

public class UserService
{
    private IMapper _mapper;
    private UserManager<User> _userManager;

    public UserService(
        IMapper mapper,
        UserManager<User> userManager
    )
    {
        _mapper =mapper;
        _userManager = userManager;
    }

    public async Task<IdentityResult> Register(CreateUserDto userDto){
        var user = _mapper.Map<User>(userDto);

        return await _userManager.CreateAsync(user, userDto.Password);
    }
}
