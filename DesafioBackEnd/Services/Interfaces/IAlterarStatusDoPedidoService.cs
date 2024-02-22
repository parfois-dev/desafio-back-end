using Parfois.DesafioBackEnd.Models.Dtos.AlterarStatusDoPedido;

namespace Parfois.DesafioBackEnd.Services.Interfaces
{
    public interface IAlterarStatusDoPedidoService
    {
        Task<AlterarStatusResponse> AlterarStatusDoPedidoAsync(AlterarStatusRequest alterarStatusRequest);
    }
}