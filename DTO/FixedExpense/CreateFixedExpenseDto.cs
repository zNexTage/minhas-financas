using System;
using System.ComponentModel.DataAnnotations;
using MinhasFinancas.Enum;
using MinhasFinancas.Validations;

namespace MinhasFinancas.DTO.FixedExpense;

public class CreateFixedExpenseDto
{
    [Required(ErrorMessage = "Informe a descrição")]
    [MaxLength(100)]
    public string Description { get; set; }

    [DataType(DataType.Currency)]
    [Range(0.0, Double.MaxValue, ErrorMessage = "O campo deve ser maior que {1} e menor que {2}")]
    public double Value { get; set; }

    [PaymentCategoryValidation]
    [Required(ErrorMessage = "Informe a categoria")]
    [MaxLength(50)]
    // TODO: Create a custom validation to PaymentCategory
    public string PaymentCategory { get; set; }
}
