using System;
using System.ComponentModel.DataAnnotations;

namespace MinhasFinancas.Models;

public class MoneyOutflow : BaseModel
{   
    
    public class PaymentMethods {
        public string Value { get; set; }
        
        public static readonly PaymentMethods DEBIT = new PaymentMethods {Value = "Débito"};
        public static readonly PaymentMethods CREDIT = new PaymentMethods {Value = "Crédito"};
        public static readonly PaymentMethods PIX = new PaymentMethods {Value = "Pix"};
        public static readonly PaymentMethods MONEY = new PaymentMethods {Value = "Dinheiro"};
    }

    public class PaymentCategories {
        public string Value { get; set; }

        public static readonly PaymentCategories BANK_SLIP = new PaymentCategories {Value = "Boleto"};
        public static readonly PaymentCategories TRANSPORT = new PaymentCategories {Value = "Transporte"};
        public static readonly PaymentCategories FOOD = new PaymentCategories {Value = "Alimentação"};
        public static readonly PaymentCategories OTHERS = new PaymentCategories {Value = "Outros"};
    }

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

    [Required(ErrorMessage = "Informe uma quantidade")]
    public int Quantity { get; set; }

    [Required(ErrorMessage = "Informe o método de pagamento")]
    [MaxLength(20)]
    public PaymentMethods PaymentMethod { get; set; }

    [Required(ErrorMessage = "Informe o local do pagamento")]
    [MaxLength(50)]
    public string PaymentLocation { get; set; }

    // TODO: Create a field to save the payment PDF.
    // public string PdfFile { get; set; }

    [Required(ErrorMessage = "Informe a categoria")]
    [MaxLength(50)]
    public PaymentCategories PaymentCategory { get; set; }
}
