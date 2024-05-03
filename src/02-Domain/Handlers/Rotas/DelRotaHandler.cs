using AutoMapper;
using MediatR;
using RotaDeViagem.Domain.Commands.Request;
using RotaDeViagem.Domain.Commands.Response;
using RotaDeViagem.Domain.Entities;
using RotaDeViagem.Domain.Interface.IRepositories;
using RotaDeViagem.Shared.Extensions;
using RotaDeViagem.Shared.Interfaces.IRepositories;
using RotaDeViagem.Shared.Interfaces.IResponse;

namespace RotaDeViagem.Domain.Handlers.Corretores
{
    public class DelRotaHandler : IRequestHandler<DelRotaRequest, IGenericResponse>
    {
        
        private readonly IRotaRepository _repository;
        private readonly IMapper _mapper;

        public DelRotaHandler(IRotaRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IGenericResponse> Handle(DelRotaRequest request, CancellationToken cancellationToken)
        {
            
            var entity = await _repository.GetByUniqueIdAsync(request.UniqueId);
            DomainException.ThrowWhen(entity==null, "Rota não encontrada.");

            _repository.Delete(entity);
            await _repository.SaveChangesAsync();
            return new GenericResponse(true, "Rota excluída com sucesso.");      
        }

        
    }
}
