using System;
using Microsoft.AspNetCore.Identity;

namespace MinhasFinancas.Models;

public class User : IdentityUser
{
    public virtual ICollection<MoneyOutflow> MoneyOutflows {get;set;}
}