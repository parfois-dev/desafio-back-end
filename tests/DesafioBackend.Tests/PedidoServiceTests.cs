using Xunit;
using DesafioBackend;

public class PedidoServiceTests
{
    [Fact]
    public void Criar_E_Pegar_Pedido()
    {
        var repo = new PedidoRepository();
        var service = new PedidoService(repo);
        var pedido = new Pedido { Numero = "1" };
        service.Criar(pedido);
        var result = service.Obter("1");
        Assert.NotNull(result);
        Assert.Equal("1", result?.Numero);
    }

    [Fact]
    public void Atualizar_Pedido()
    {
        var repo = new PedidoRepository();
        var service = new PedidoService(repo);
        var pedido = new Pedido { Numero = "1" };
        service.Criar(pedido);
        pedido.Itens.Add(new Item { Descricao = "A", PrecoUnitario = 1, Qtd = 1 });
        service.Atualizar(pedido);
        var result = service.Obter("1");
        Assert.Single(result!.Itens);
    }

    [Fact]
    public void Remover_Pedido()
    {
        var repo = new PedidoRepository();
        var service = new PedidoService(repo);
        var pedido = new Pedido { Numero = "1" };
        service.Criar(pedido);
        service.Remover("1");
        var result = service.Obter("1");
        Assert.Null(result);
    }
}
