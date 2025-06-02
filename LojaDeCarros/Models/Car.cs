using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LojaDeCarros.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Display(Name = "Marca")]
        public string Brand { get; set; }

        [Display(Name = "Modelo")]
        public string Model { get; set; }

        [Display(Name = "Ano de Fabricação")]
        public int ManufactureYear { get; set; }

        [Display(Name = "Ano do Modelo")]
        public int ModelYear { get; set; }

        [Display(Name = "Número do Chassi")]
        public string ChassisNumber { get; set; }

        [Display(Name = "Preço")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Price { get; set; }

        public ICollection<Note>? Notes { get; set; }
    }
}