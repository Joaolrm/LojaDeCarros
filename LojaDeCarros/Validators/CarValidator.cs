using LojaDeCarros.Models;

namespace LojaDeCarros.Validators
{
    public static class CarValidator
    {
        public static bool IsValidModelYear(int manufactureYear, int modelYear)
        {
            return modelYear >= manufactureYear && modelYear <= manufactureYear + 1;
        }

        public static bool IsValidPrice(decimal price)
        {
            return price > 0;
        }

        public static bool IsValid(Car car, out List<string> errors)
        {
            errors = new List<string>();

            if (!IsValidModelYear(car.ManufactureYear, car.ModelYear))
                errors.Add("O Ano do Modelo deve ser igual ou no máximo 1 ano após o Ano de Fabricação.");

            if (!IsValidPrice(car.Price))
                errors.Add("O Preço do carro deve ser maior que zero.");

            return errors.Count == 0;
        }
    }
}
