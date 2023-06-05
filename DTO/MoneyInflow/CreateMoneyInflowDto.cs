using System;
using System.ComponentModel.DataAnnotations;

namespace MinhasFinancas.DTO.MoneyInflow;

public class CreateMoneyInflowDto
{
    [Required(ErrorMessage = "Informe a descrição")]
    [StringLength(100)]
    public string Description { get; set; }

    [Required(ErrorMessage = "Informe o valor da entrada")]
    public decimal Value { get; set; }

    [Required(ErrorMessage = "Informe a data que o dinheiro entrou")]
    public DateTime Date { get; set; }

    [Required(ErrorMessage = "Informe o autor da entrada do dinheiro")]
    public string UserId {get;set;}
}
