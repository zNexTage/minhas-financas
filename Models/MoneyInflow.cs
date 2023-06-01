using System;
using System.ComponentModel.DataAnnotations;

namespace MinhasFinancas.Models;

public class MoneyInflow : BaseModel //Entrada de dinheiro
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "Informe a descrição")]
    [MaxLength(100)]
    public string Description { get; set; }

    [Required(ErrorMessage = "Informe o valor")]
    [DataType(DataType.Currency)]
    [Range(0.0, Double.MaxValue, ErrorMessage = "O campo deve ser maior que {1} e menor que {2}")]
    public double Value { get; set; }

    [Required(ErrorMessage = "Informe a data que o dinheiro entrou")]
    public DateOnly Date { get; set; }
}
