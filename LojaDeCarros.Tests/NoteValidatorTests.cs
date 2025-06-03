using LojaDeCarros.Models;
using LojaDeCarros.Validators;
using Xunit;

namespace LojaDeCarros.Tests
{
    public class NoteValidatorTests
    {
        [Fact]
        public void Nota_Com_Data_Valida_Deve_Ser_Valida()
        {
            var note = new Note { IssueDate = DateTime.Now };
            var result = NoteValidator.IsValid(note, out var errors);

            Assert.True(result);
            Assert.Empty(errors);
        }

        [Fact]
        public void Nota_Com_Data_Futura_Deve_Ser_Invalida()
        {
            var note = new Note { IssueDate = DateTime.Now.AddDays(1) };
            var result = NoteValidator.IsValid(note, out var errors);

            Assert.False(result);
            Assert.Contains("A data de emissão não pode estar no futuro.", errors);
        }

        [Fact]
        public void Nota_Com_Data_Muito_Antiga_Deve_Ser_Invalida()
        {
            var note = new Note { IssueDate = DateTime.Now.AddDays(-4) };
            var result = NoteValidator.IsValid(note, out var errors);

            Assert.False(result);
            Assert.Contains("A data de emissão não pode ser anterior a 3 dias.", errors);
        }
    }
}
