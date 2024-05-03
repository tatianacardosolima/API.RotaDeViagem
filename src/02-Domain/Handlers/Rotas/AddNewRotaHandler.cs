using AutoMapper;
using MediatR;
using RotaDeViagem.Domain.Commands.Request;
using RotaDeViagem.Domain.Commands.Response;
using RotaDeViagem.Domain.Entities;
using RotaDeViagem.Domain.Interface.IRepositories;
using RotaDeViagem.Shared.Exceptions;
using RotaDeViagem.Shared.Interfaces.IResponse;

namespace RotaDeViagem.Domain.Handlers.Corretores
{
    public class AddNewRotaHandler : IRequestHandler<AddNewRotaRequest, IGenericResponse>
    {
        
        private readonly IRotaRepository _repository;
        private readonly IMapper _mapper;

        public AddNewRotaHandler(IRotaRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IGenericResponse> Handle(AddNewRotaRequest request, CancellationToken cancellationToken)
        {            
            DomainException.ThrowWhen(await ExistRotaAsync(request), "Rota já cadastrada");

            var entity = _mapper.Map<Rota>(request);
            DomainException.ThrowWhenInvalidEntity(entity);
            
            await _repository.InsertAsync(entity);
            await _repository.SaveChangesAsync();
            return new GenericResponse(true, "Rota inserida com sucesso");      
        }

        private async Task<bool> ExistRotaAsync(AddNewRotaRequest request)
        {
            return await _repository.ExistsAsync(x =>
                x.Origem.ToLower() == request.Origem.ToLower()
                && x.Destino.ToLower() == request.Destino.ToLower()) ;
        }
    }
}
