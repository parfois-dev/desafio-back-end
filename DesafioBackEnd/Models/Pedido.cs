using System.ComponentModel.DataAnnotations.Schema;

namespace Parfois.DesafioBackEnd.Models
{
    public class Pedido
    {
        public long Id { get; set; }

        public string Codigo { get; set; }

        public ICollection<Item> Itens { get; set; }

        [NotMapped]
        public decimal ValorTotal => Itens.Sum(item => item.PrecoUnitario * item.Quantidade);

        [NotMapped]
        public decimal TotalDeItens => Itens.Sum(item =>  item.Quantidade);
    }
}
