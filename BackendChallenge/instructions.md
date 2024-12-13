# Desafio Backend: Instruções

## Visão Geral
Este projeto é uma API desenvolvida para gerir **Pedidos** e os seus **Itens**. A API oferece funcionalidades para:
- Criar, consultar, atualizar e excluir pedidos.
- Alterar o status dos pedidos com base em condições como o valor aprovado e a quantidade de itens.

### Funcionalidades Principais
- **GET /api/Pedido**: Retorna todos os pedidos com os seus itens.
- **POST /api/status**: Atualiza o status de um pedido (ex: aprovado, reprovado, etc.).

## Requisitos
- **.NET 6.0 SDK** ou superior.
- **Visual Studio** (preferencialmente) ou outro editor de código que suporte C#.
- Base de dados configurada (utiliza **In-Memory Database**).

## Execução

- Ao correr a aplicação, a API estará disponível em https://localhost:5001 ou :7269

Endpoints da API

1. GET /api/Pedido
Descrição: Retorna todos os pedidos com os seus itens associados.

Exemplo de resposta:

[
  {
    "pedidoId": "123",
    "itens": [
      {
        "descricao": "Produto A",
        "precoUnitario": 100,
        "quantidade": 2
      }
    ]
  }
]

2. POST /api/status
Descrição: Altera o status de um pedido.

Corpo da requisição:

json
Copiar código
{
  "status": "APROVADO",
  "itensAprovados": 5,
  "valorAprovado": 500,
  "pedido": "123"
}
Exemplo de resposta:


{
  "pedido": "123",
  "status": ["APROVADO"]
}


Como Testar a API
1. Usando o Postman
Abra o Postman.
Crie uma nova requisição do tipo GET ou POST.
Defina a URL como https://localhost:5001/api/Pedido ou https://localhost:5001/api/status dependendo do endpoint.
Envie a requisição e observe a resposta da API.