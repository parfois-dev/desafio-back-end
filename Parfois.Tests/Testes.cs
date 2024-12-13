using Xunit;
using BackendChallenge.Models; 

public class PedidoTests
{
    [Fact]
    public void CalcularValorTotalPedido_DeveRetornarZero_QuandoPedidoNaoTemItens()
    {
        
        var pedido = new Pedido
        {
            Itens = new List<Item>() 
        };

        
        var valorTotal = pedido.Itens.Sum(i => i.PrecoUnitario * i.Quantidade);

        
        Assert.Equal(0, valorTotal);
    }

    [Fact]
    public void AdicionarItem_DeveIncluirItemNaListaDeItens()
    {
        var pedido = new Pedido
        {
            Itens = new List<Item>()
        };

        var item = new Item { PrecoUnitario = 15, Quantidade = 2 };

        
        pedido.Itens.Add(item);

        
        Assert.Contains(item, pedido.Itens);
    }

    [Fact]
    public void RemoverItem_DeveRemoverItemDaListaDeItens()
    {
        
        var item1 = new Item { PrecoUnitario = 10, Quantidade = 2 };
        var item2 = new Item { PrecoUnitario = 5, Quantidade = 3 };

        var pedido = new Pedido
        {
            Itens = new List<Item> { item1, item2 }
        };

        
        pedido.Itens.Remove(item1);

        
        Assert.DoesNotContain(item1, pedido.Itens);
    }
}
