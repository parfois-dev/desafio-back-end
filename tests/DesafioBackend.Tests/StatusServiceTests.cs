using System.Collections.Generic;
using Xunit;
using DesafioBackend;

public class StatusServiceTests
{
    private Pedido CriarPedidoPadrao()
    {
        return new Pedido
        {
            Numero = "1",
            Itens = new List<Item>
            {
                new Item { Descricao = "A", PrecoUnitario = 10, Qtd = 1 },
                new Item { Descricao = "B", PrecoUnitario = 5, Qtd = 2 }
            }
        };
    }

    [Fact]
    public void Status_Aprovado_Total()
    {
        var pedido = CriarPedidoPadrao();
        var service = new StatusService();
        var req = new StatusRequest
        {
            Status = "APROVADO",
            ValorAprovado = pedido.ValorTotal,
            ItensAprovados = pedido.QuantidadeTotal
        };
        var result = service.Avaliar(pedido, req);
        Assert.Equal(new[]{"APROVADO"}, result);
    }

    [Fact]
    public void Status_Valor_Menor_Qtd_Menor()
    {
        var pedido = CriarPedidoPadrao();
        var service = new StatusService();
        var req = new StatusRequest
        {
            Status = "APROVADO",
            ValorAprovado = pedido.ValorTotal - 1,
            ItensAprovados = pedido.QuantidadeTotal - 1
        };
        var result = service.Avaliar(pedido, req);
        Assert.Contains("APROVADO_VALOR_A_MENOR", result);
        Assert.Contains("APROVADO_QTD_A_MENOR", result);
    }

    [Fact]
    public void Status_Valor_Maior_Qtd_Maior()
    {
        var pedido = CriarPedidoPadrao();
        var service = new StatusService();
        var req = new StatusRequest
        {
            Status = "APROVADO",
            ValorAprovado = pedido.ValorTotal + 1,
            ItensAprovados = pedido.QuantidadeTotal + 1
        };
        var result = service.Avaliar(pedido, req);
        Assert.Contains("APROVADO_VALOR_A_MAIOR", result);
        Assert.Contains("APROVADO_QTD_A_MAIOR", result);
    }

    [Fact]
    public void Status_Reprovado()
    {
        var pedido = CriarPedidoPadrao();
        var service = new StatusService();
        var req = new StatusRequest
        {
            Status = "REPROVADO",
            ValorAprovado = 0,
            ItensAprovados = 0
        };
        var result = service.Avaliar(pedido, req);
        Assert.Equal(new[]{"REPROVADO"}, result);
    }
}
