using LojaDeCarros.Models;
using LojaDeCarros.Validators;
using Microsoft.AspNetCore.Mvc.ModelBinding;

public static class CustomerValidator
{
    public static void Validate(Customer customer, ModelStateDictionary modelState)
    {
        if (!CPFValidator.IsValid(customer.CPF))
            modelState.AddModelError("CPF", "CPF inválido.");

        if (!EmailValidator.IsValid(customer.Email))
            modelState.AddModelError("Email", "E-mail inválido.");

        if (!PhoneValidator.IsValid(customer.Phone))
            modelState.AddModelError("Phone", "Telefone inválido. Use apenas números com DDD.");
    }
}
