using Parfois.DesafioBackEnd.Models.Dtos.CriarPedido;

namespace Parfois.DesafioBackEnd.Services.Interfaces
{
    public interface ICriarPedidoService
    {
        Task<bool> CriarPedidoAsync(CriarPedidoRequest request);
    }
}