using FluentValidation.Results;

namespace Parfois.DesafioBackEnd.Api.Helpers
{
    public static class ErroHelper
    {
        public static string FormatarErros(ValidationResult resultadoDaValidacao) => string.Join(Environment.NewLine, resultadoDaValidacao.Errors.Select(error => error.ErrorMessage));
    }
}
