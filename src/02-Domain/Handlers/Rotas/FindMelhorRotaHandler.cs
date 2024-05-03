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
    public class FindMelhorRotaHandler : IRequestHandler<FindRotaRequest, IGenericResponse>
    {
        
        private readonly IRotaRepository _repository;
        private readonly IMapper _mapper;

        public FindMelhorRotaHandler(IRotaRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IGenericResponse> Handle(FindRotaRequest request, CancellationToken cancellationToken)
        {
            
            //var entity = await _repository.GetByUniqueIdAsync(request.UniqueId);
            //DomainException.ThrowWhen(entity==null, "Rota não encontrada.");

            //_repository.LogicalDelete(entity);
            //await _repository.SaveChangesAsync();
            return new GenericResponse(true, "Rota alterada com sucesso");      
        }

       
    }
}
