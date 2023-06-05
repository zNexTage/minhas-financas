using System;
using System.ComponentModel.DataAnnotations;
using MinhasFinancas.Models;
using MinhasFinancas.Validations;

namespace MinhasFinancas.DTO.CreateMoneyOutflowDto;


public class CreateMoneyOutflowDto
{
    [Required(ErrorMessage = "Informe a descrição")]
    [StringLength(100)]
    public string Description { get; set; }

    [Required(ErrorMessage = "Informe o valor")]
    [DataType(DataType.Currency)]
    [Range(0.0, Double.MaxValue, ErrorMessage = "O campo deve ser maior que {1} e menor que {2}")]
    public double Value { get; set; }

    [Required(ErrorMessage = "Informe uma quantidade")]
    public int Quantity { get; set; }

    [Required(ErrorMessage = "Informe o método de pagamento")]
    [StringLength(20)]
    [PaymentMethodValidation]
    public string PaymentMethod { get; set; }

    [Required(ErrorMessage = "Informe o local do pagamento")]
    [StringLength(50)]
    public string PaymentLocation { get; set; }

    // TODO: Must create a field to save the payment PDF.
    // public string PdfFile { get; set; }

    [Required(ErrorMessage = "Informe a categoria")]
    [StringLength(50)]
    [PaymentCategoryValidation]
    public string PaymentCategory { get; set; }

    [Required(ErrorMessage = "Informe o autor da saída do dinheiro")]
    public string UserId {get;set;}
}
