using System.Collections.Generic;
using System.Linq;
namespace DesafioBackend;

public class Pedido
{
    public string Numero { get; set; } = string.Empty;
    public List<Item> Itens { get; set; } = new List<Item>();

    public decimal ValorTotal => Itens.Sum(i => i.PrecoUnitario * i.Qtd);
    public int QuantidadeTotal => Itens.Sum(i => i.Qtd);
}
