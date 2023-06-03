using System;
using System.ComponentModel.DataAnnotations;
using MinhasFinancas.Models;

namespace MinhasFinancas.Validations;

public class PaymentMethodValidation : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var paymenthMethod = value as string;

        var paymenthMethods = MoneyOutflow.PaymentMethods.ToList();

        if(!paymenthMethods.Contains(paymenthMethod)){
            return new ValidationResult(ErrorMessage ?? $"Método de pagamento inválido! Os métodos de pagamento disponíveis são: {String.Join(",", paymenthMethods)}");
        }

        return ValidationResult.Success;
    }
}
