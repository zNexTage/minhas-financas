using System;
using System.ComponentModel.DataAnnotations;
using MinhasFinancas.Enum;
using MinhasFinancas.Models;

namespace MinhasFinancas.Validations;

public class PaymentCategoryValidation : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var category = value as string;

        var categories = PaymentCategories.ToList();

        if(!categories.Contains(category)){
            return new ValidationResult(ErrorMessage ?? $"A categoria informada é inválida! As categorias disponíveis são: {String.Join(",", categories)}");
        }

        return ValidationResult.Success;
    }
}
