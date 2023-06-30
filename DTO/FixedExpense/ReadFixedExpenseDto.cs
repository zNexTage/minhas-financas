using System;
using System.ComponentModel.DataAnnotations;
using MinhasFinancas.Enum;

namespace Backend.DTO.FixedExpense;

public class ReadFixedExpenseDto
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "Informe a descrição")]
    [MaxLength(100)]
    public string Description { get; set; }

    [DataType(DataType.Currency)]
    [Range(0.0, Double.MaxValue, ErrorMessage = "O campo deve ser maior que {1} e menor que {2}")]
    public double Value { get; set; }

    [Required(ErrorMessage = "Informe a categoria")]
    [MaxLength(50)]
    // TODO: Create a custom validation to PaymentCategory
    public string PaymentCategory { get; set; }
}
