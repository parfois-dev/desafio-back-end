using FluentValidation;
using Parfois.DesafioBackEnd.Models.Dtos.AlterarStatusDoPedido;

namespace Parfois.DesafioBackEnd.Api.Validators
{
    public class AlterarStatusValidator : AbstractValidator<AlterarStatusRequest>
    {
        public AlterarStatusValidator()
        {
            RuleFor(request => request.Status).NotNull().NotEmpty();
            RuleFor(request => request.CodigoDoPedido).NotNull().NotEmpty();
            RuleFor(request => request.ItensAprovados).NotNull().NotEmpty().GreaterThanOrEqualTo(0);
            RuleFor(request => request.ValorAprovado).NotNull().NotEmpty().GreaterThanOrEqualTo(0);
        }
    }
}
