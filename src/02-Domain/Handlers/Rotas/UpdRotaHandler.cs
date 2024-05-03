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
    public class UpdRotaHandler : IRequestHandler<UpdRotaRequest, IGenericResponse>
    {
        
        private readonly IRotaRepository _repository;
        private readonly IMapper _mapper;

        public UpdRotaHandler(IRotaRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IGenericResponse> Handle(UpdRotaRequest request, CancellationToken cancellationToken)
        {
            
            var entity = await _repository.GetByUniqueIdAsync(request.UniqueId);
            DomainException.ThrowWhen(entity==null, "Rota não encontrada.");
            DomainException.ThrowWhen(await ExistRotaAsync(entity), 
                        "Existe uma outra rota cadastrada com a mesma origem e destino.");

            entity.Change(request.Origem, request.Destino, request.Valor);
            DomainException.ThrowWhenInvalidEntity(entity);
            
            await _repository.SaveChangesAsync();
            return new GenericResponse(true, "Rota alterada com sucesso");      
        }

        private async Task<bool> ExistRotaAsync(Rota entity)
        {
            return await _repository.ExistsAsync(x => 
                x.Origem.ToLower() == entity.Origem && 
                x.Destino == entity.Destino &&
                x.UniqueId != entity.UniqueId
                );
        }
    }
}
