using MediatR;
using RotaDeViagem.Domain.Commands.Request;
using RotaDeViagem.Domain.Handlers.Corretores;
using RotaDeViagem.Shared.Interfaces.IResponse;

namespace RotaDeViagem.API.Setup
{
    public static class HandlerSetup
    {
        public static void AddDependencyHandler(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddScoped<IRequestHandler<AddNewRotaRequest, IGenericResponse>, AddNewRotaHandler>();
            services.AddScoped<IRequestHandler<UpdRotaRequest, IGenericResponse>, UpdRotaHandler>();
            services.AddScoped<IRequestHandler<DelRotaRequest, IGenericResponse>, DelRotaHandler>();
            services.AddScoped<IRequestHandler<FindRotaRequest, IGenericResponse>, FindMelhorRotaHandler>();

        }
    }
}
