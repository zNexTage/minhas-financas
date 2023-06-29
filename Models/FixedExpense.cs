using System;
using System.ComponentModel.DataAnnotations;
using MinhasFinancas.Enum;

namespace MinhasFinancas.Models;

/// <summary>
/// This is used to register fixed expense, like: rent, electricity bill, water bill etc...
///</summary>
public class FixedExpense
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
    public PaymentCategories PaymentCategory { get; set; }

    public string UserId { get; set; } 

    [Required(ErrorMessage = "É necessário identificar quem realizou essa saída de dinheiro")]
    public virtual User User {get;set;}


}
