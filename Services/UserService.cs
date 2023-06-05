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
    private SignInManager<User> _signInManager;

    private TokenService _tokenService;

    public UserService(
        IMapper mapper,
        UserManager<User> userManager,
        SignInManager<User> signInManager,
        TokenService tokenService
    )
    {
        _mapper =mapper;
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    public async Task<IdentityResult> Register(CreateUserDto userDto){
        var user = _mapper.Map<User>(userDto);

        return await _userManager.CreateAsync(user, userDto.Password);
    }

    public async Task<string> Login(LoginUserDto loginUserDto){
        var result = await _signInManager.PasswordSignInAsync(
            loginUserDto.Username, 
            loginUserDto.Password,
            false, 
            false
        );

        if(!result.Succeeded){
            throw new Exception("Não foi possível realizar o login! Verifique as credenciais informadas.");
        }

        var user = _signInManager.UserManager.Users.FirstOrDefault(
            u => u.NormalizedUserName == loginUserDto.NormalizedUserName
        )!;

        return _tokenService.GenerateToken(user);
    }

    public async Task<User> GetById(string userId){
        var user = await _userManager.FindByIdAsync(userId);

        return user;
    }
}
