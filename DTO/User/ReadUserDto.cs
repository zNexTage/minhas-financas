using System;

namespace MinhasFinancas.DTO.User;

public class ReadUserDto
{
    public string Id { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string FullName { get => $"{FirstName} {LastName}";  }
}
