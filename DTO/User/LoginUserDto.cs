using System;
using System.ComponentModel.DataAnnotations;

namespace MinhasFinancas.DTO.User;

public class LoginUserDto
{
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }

    public string NormalizedUserName { get => Username.ToUpper();  }
}
