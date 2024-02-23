using Parfois.DesafioBackEnd.Models.Dtos.AlterarStatusDoPedido;
using Parfois.DesafioBackEnd.Repository;
using Parfois.DesafioBackEnd.Services.Helpers;
using Parfois.DesafioBackEnd.Services.Interfaces;

namespace Parfois.DesafioBackEnd.Services
{
    public class AlterarStatusDoPedidoService : IAlterarStatusDoPedidoService
    {
        private readonly IRepository _repository;
        public AlterarStatusDoPedidoService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<AlterarStatusResponse> AlterarStatusDoPedidoAsync(AlterarStatusRequest alterarStatusRequest)
        {
            var pedidoExiste = await _repository.PedidoExisteAsync(alterarStatusRequest.CodigoDoPedido);
            if (!pedidoExiste)
            {
                return new AlterarStatusResponse
                {
                    CodigoDoPedido = alterarStatusRequest.CodigoDoPedido,
                    Status = StatusDoPedidoHelper.ObterStatusDoPedido(null, default, default, default, default, alterarStatusRequest.Status)
                };
            }

            var pedido = await _repository.ObterPedidoAsync(alterarStatusRequest.CodigoDoPedido);

            return new AlterarStatusResponse
            {
                CodigoDoPedido = alterarStatusRequest.CodigoDoPedido,
                Status = StatusDoPedidoHelper.ObterStatusDoPedido(pedido.Codigo, pedido.ValorTotal, pedido.TotalDeItens, alterarStatusRequest.ValorAprovado, alterarStatusRequest.ItensAprovados, alterarStatusRequest.Status)
            };
        }
    }
}
