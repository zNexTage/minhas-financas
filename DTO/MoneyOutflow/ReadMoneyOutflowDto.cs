using System;
using MinhasFinancas.DTO.User;

namespace MinhasFinancas.DTO.MoneyOutflow;

public class ReadMoneyOutflowDto
{
    public int Id { get; set; }
    public string Description { get; set; }
    public double Value { get; set; }
    public int Quantity { get; set; }
    public string PaymentMethod { get; set; }
    public string PaymentLocation { get; set; }

    // TODO: Create a field to save the payment PDF.
    // public string PdfFile { get; set; }
    public string PaymentCategory { get; set; }

    public ReadUserDto User { get; set; }

    public DateOnly Date { get; set; }
}
