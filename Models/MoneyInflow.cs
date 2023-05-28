using System;
using System.ComponentModel.DataAnnotations;

namespace MinhasFinancas.Models;

public class MoneyInflow //Entrada de dinheiro
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "Informe a descrição")]
    [MaxLength(100)]
    public string Description { get; set; }

    [Required(ErrorMessage = "Informe o valor da entrada")]
    public decimal Value { get; set; }

    [Required(ErrorMessage = "Informe a data que o dinheiro entrou")]
    public DateTime Date { get; set; }
}
