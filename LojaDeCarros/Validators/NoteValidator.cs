using LojaDeCarros.Models;

namespace LojaDeCarros.Validators
{
    public static class NoteValidator
    {
        public static bool IsValid(Note note, out List<string> errors)
        {
            errors = new List<string>();

            var now = DateTime.Now.Date;
            var issueDate = note.IssueDate.Date;

            if (issueDate > now)
            {
                errors.Add("A data de emissão não pode estar no futuro.");
            }

            if ((now - issueDate).TotalDays > 3)
            {
                errors.Add("A data de emissão não pode ser anterior a 3 dias.");
            }

            return errors.Count == 0;
        }
    }
}
