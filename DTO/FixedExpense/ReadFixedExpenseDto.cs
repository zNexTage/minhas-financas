using System;
using System.ComponentModel.DataAnnotations;
using MinhasFinancas.Enum;

namespace Backend.DTO.FixedExpense;

public class ReadFixedExpenseDto
{
    public int Id { get; set; }
    public string Description { get; set; }
    
    public double Value { get; set; }
    
    public string PaymentCategory { get; set; }
}
