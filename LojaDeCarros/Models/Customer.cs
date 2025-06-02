using System.ComponentModel.DataAnnotations;

namespace LojaDeCarros.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Display(Name = "Nome")]

        public string Name { get; set; }
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Display(Name = "E-mail")]

        public string Email { get; set; }
        [Display(Name = "Telefone")]

        public string Phone { get; set; }
        [Display(Name = "Endereço")]

        public string Address { get; set; }
        [Display(Name = "CPF")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve conter exatamente 11 dígitos.")]


        public string CPF { get; set; }

        public ICollection<Note>? Notes { get; set; }
    }
}
