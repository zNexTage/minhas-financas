using System;

namespace Backend.DTO.Token;

public class ReadTokenDto
{
    public string Token {get;set;}
    public DateTime ExpiresIn { get; set; }
}
