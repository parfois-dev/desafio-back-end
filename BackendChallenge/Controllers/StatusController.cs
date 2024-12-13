using BackendChallenge.Data;
using BackendChallenge.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

[ApiController]
[Route("api/status")]
public class StatusController : ControllerBase
{
    private readonly AppDbContext _context;

    
    public StatusController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> AlterarStatus([FromBody] StatusRequest statusRequest)
    {
        
        var pedido = await _context.Pedidos
            .Include(p => p.Itens) // Incluir itens associados ao pedido
            .FirstOrDefaultAsync(p => p.PedidoId == statusRequest.Pedido);

        if (pedido == null)
        {
            return Ok(new { pedido = statusRequest.Pedido, status = new[] { "CODIGO_PEDIDO_INVALIDO" } });
        }

       
        var valorTotalPedido = pedido.Itens.Sum(i => i.PrecoUnitario * i.Quantidade);
        var qtdTotalItens = pedido.Itens.Sum(i => i.Quantidade);
        var status = new List<string>();

        // Regras de mudança de status
        if (statusRequest.Status == "REPROVADO")
        {
            status.Add("REPROVADO");
        }
        else if (statusRequest.Status == "APROVADO")
        {
            
            if (statusRequest.ValorAprovado < valorTotalPedido)
            {
                status.Add("APROVADO_VALOR_A_MENOR");
            }
            else if (statusRequest.ValorAprovado > valorTotalPedido)
            {
                status.Add("APROVADO_VALOR_A_MAIOR");
            }

            
            if (statusRequest.ItensAprovados < qtdTotalItens)
            {
                status.Add("APROVADO_QTD_A_MENOR");
            }
            else if (statusRequest.ItensAprovados > qtdTotalItens)
            {
                status.Add("APROVADO_QTD_A_MAIOR");
            }

            
            if (statusRequest.ItensAprovados == qtdTotalItens && statusRequest.ValorAprovado == valorTotalPedido)
            {
                status.Add("APROVADO");
            }
        }

        return Ok(new { pedido = statusRequest.Pedido, status });
    }
}
