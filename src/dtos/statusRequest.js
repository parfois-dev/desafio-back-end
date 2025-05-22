class StatusRequest {
  constructor({ status, itensAprovados, valorAprovado, pedido }) {
    this.status = status;
    this.itensAprovados = Number(itensAprovados);
    this.valorAprovado = Number(valorAprovado);
    this.pedido = pedido;
  }
}

module.exports = StatusRequest;
