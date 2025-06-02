using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LojaDeCarros.Models
{
    public class Note
    {
        public int Id { get; set; }
        [Display(Name = "Número")]
        public string Number { get; set; }
        [Display(Name = "Data de Emissão")]
        public DateTime IssueDate { get; set; }
        [Display(Name = "Garantia em mêses")]
        public int Warranty { get; set; }
        [Display(Name = "Valor de Venda")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal SaleValue { get; set; }

        public int BuyerId { get; set; }
        public Customer? Buyer { get; set; }

        public int SellerId { get; set; }
        [Display(Name = "Vendedor")]
        public Seller? Salesperson { get; set; }

        public int CarId { get; set; }
        [Display(Name = "Carro")]

        public Car? Car { get; set; }
        [NotMapped]
        [Display(Name = "Comissão")]
        public decimal Commission => Salesperson?.CalculateCommission(SaleValue) ?? 0;

    }
}
