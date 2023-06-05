using System;
using System.ComponentModel.DataAnnotations;

namespace MinhasFinancas.DTO.User;
public class CreateUserDto
{
    [Required]
    public string Username { get; set; }

    [Required]
    [StringLength(80, ErrorMessage = "Informe o primeiro nome do usuário")]
    public string FirstName { get; set; }

    [Required]
    [StringLength(80, ErrorMessage = "Informe o último nome do usuário")]
    public string LastName {get;set;}

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [Compare("Password")]
    public string RePassword { get; set; }

    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email {get;set;}
}
