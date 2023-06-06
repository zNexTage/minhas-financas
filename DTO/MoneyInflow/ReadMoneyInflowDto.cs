using System;
using MinhasFinancas.DTO.User;

namespace MinhasFinancas.DTO.MoneyInflow;

public class ReadMoneyInflowDto
{
    public int Id { get; set; }
    public string Description { get; set; }
    public decimal Value { get; set; }

    public DateOnly Date { get; set; }

    public ReadUserDto User { get; set; }
}
