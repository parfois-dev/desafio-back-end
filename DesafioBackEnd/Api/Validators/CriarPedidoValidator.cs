using FluentValidation;
using Parfois.DesafioBackEnd.Models.Dtos.CriarPedido;

namespace Parfois.DesafioBackEnd.Api.Validators
{
    public class CriarPedidoValidator : AbstractValidator<CriarPedidoRequest>
    {
        public CriarPedidoValidator()
        {
            RuleFor(request => request.Numero).NotNull().NotEmpty();
            RuleFor(request => request.Itens).NotNull().NotEmpty();
            RuleForEach(request => request.Itens).ChildRules(item =>
            {
                item.RuleFor(itemAValidar => itemAValidar.Descricao).NotNull().NotEmpty();
                item.RuleFor(itemAValidar => itemAValidar.PrecoUnitario).NotNull().NotEmpty().GreaterThanOrEqualTo(0);
                item.RuleFor(itemAValidar => itemAValidar.Quantidade).NotNull().NotEmpty().GreaterThanOrEqualTo(1);
            });
        }
    }
}
