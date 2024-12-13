namespace BackendChallenge.Models
{
    public class StatusRequest
    {
        public string Status { get; set; }
        public int ItensAprovados { get; set; }
        public decimal ValorAprovado { get; set; }
        public string Pedido { get; set; }
    }
}
