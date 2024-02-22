using FluentValidation;
using Parfois.DesafioBackEnd.Api.Controllers.Swagger;
using Parfois.DesafioBackEnd.Api.Validators;
using Parfois.DesafioBackEnd.Models.Dtos.AlterarStatusDoPedido;
using Parfois.DesafioBackEnd.Models.Dtos.CriarPedido;
using Parfois.DesafioBackEnd.Repository;
using Parfois.DesafioBackEnd.Services;
using Parfois.DesafioBackEnd.Services.Interfaces;
using Swashbuckle.AspNetCore.Filters;

namespace Parfois.DesafioBackEnd.Api.DI
{
    public static class RegistradorDeDependencias
    {
        public static void RegistrarComponentes(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IRepository, LocalRepository>();
            serviceCollection.AddTransient<ICriarPedidoService, CriarPedidoService>();
            serviceCollection.AddTransient<IAlterarStatusDoPedidoService, AlterarStatusDoPedidoService>();

            serviceCollection.AddTransient<AbstractValidator<CriarPedidoRequest>, CriarPedidoValidator>();
            serviceCollection.AddTransient<AbstractValidator<AlterarStatusRequest>, AlterarStatusValidator>();

            serviceCollection.AddSwaggerGen(options =>
            {
                options.ExampleFilters();
            });
            serviceCollection.AddSwaggerExamplesFromAssemblyOf<Program>();
        }
    }
}
