using System.ComponentModel.DataAnnotations;

namespace LojaDeCarros.Models
{
    public class Seller
    {
        public int Id { get; set; }
        [Display(Name = "Nome")]

        public string Name { get; set; }
        [Display(Name = "Data de Contratação")]
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }
        [Display(Name = "Registro")]
        public string RegistrationNumber { get; set; }
        [Display(Name = "Salário")]

        public decimal Salary { get; set; }


        public ICollection<Note>? Notes { get; set; }
        [Display(Name = "Comissão")]

        public decimal CalculateCommission(decimal saleValue) => saleValue * 0.05m;
    }
}
