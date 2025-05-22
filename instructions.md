# Running the Back-end Challenge

This project requires the .NET SDK to build and run the API.

## Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) or later installed and available in your `PATH`.

Verify the installation with:

```bash
 dotnet --version
```

## Building the project

Run the following command in the repository root to restore dependencies and build the application:

```bash
 dotnet build
```

## Running the API

Execute the project using:

```bash
 dotnet run
```

By default the API will be available at `http://localhost:5000` or the port defined in the project.

The application uses an **in-memory database** so no additional setup is required.

## Running tests

If the project contains unit or integration tests, execute:

```bash
 dotnet test
```

## Sample requests

### Create or update a pedido

```bash
POST http://localhost:{porta}/api/pedido
Content-Type: application/json

{
  "pedido": "123456",
  "itens": [
    { "descricao": "Item A", "precoUnitario": 10, "qtd": 1 },
    { "descricao": "Item B", "precoUnitario": 5, "qtd": 2 }
  ]
}
```

### Change pedido status

```bash
POST http://localhost:{porta}/api/status
Content-Type: application/json

{
  "status": "APROVADO",
  "itensAprovados": 3,
  "valorAprovado": 20,
  "pedido": "123456"
}
```

These examples use the payloads described in `README.md`. The API responses will contain the processed order code and the list of status results.
