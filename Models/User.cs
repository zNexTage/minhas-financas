using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace MinhasFinancas.Models;

public class User : IdentityUser
{
    [Required]
    [MaxLength(80, ErrorMessage = "Informe o primeiro nome do usuário")]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(80, ErrorMessage = "Informe o último nome do usuário")]
    public string LastName {get;set;}
    public virtual ICollection<MoneyOutflow> MoneyOutflows {get;set;}
    public virtual ICollection<MoneyInflow> MoneyInflows { get; set; }

    public string Fullname { get => $"{FirstName} {LastName}"; }
}