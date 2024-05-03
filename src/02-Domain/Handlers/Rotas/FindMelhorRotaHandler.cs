using AutoMapper;
using MediatR;
using RotaDeViagem.Domain.Commands.Request;
using RotaDeViagem.Domain.Commands.Response;
using RotaDeViagem.Domain.Entities;
using RotaDeViagem.Domain.Interface.IProviders;
using RotaDeViagem.Domain.Interface.IRepositories;
using RotaDeViagem.Shared.Extensions;
using RotaDeViagem.Shared.Interfaces.IRepositories;
using RotaDeViagem.Shared.Interfaces.IResponse;
using System.Collections.Generic;

namespace RotaDeViagem.Domain.Handlers.Corretores
{
    public class FindMelhorRotaHandler : IRequestHandler<FindRotaRequest, IGenericResponse>
    {
        private readonly IRotaProvider _provider;
     

        public FindMelhorRotaHandler(IRotaProvider provider)
        {
            _provider = provider;
            
        }
        public async Task<IGenericResponse> Handle(FindRotaRequest request, CancellationToken cancellationToken)
        {
            DomainException.ThrowWhen(request.Origem == request.Destino, "A rota destino deve ser diferente da rota origem.");

            List<RotaResponse> rotas = (await _provider.GetRotaByOrigemAsync(request.Origem)).ToList();            
            NotFoundException.ThrowWhenNullOrEmptyList(rotas, "Não há rotas para essa origem");
            
            List<RotaMaisBarataResponse> rotasMaisBarata = new List<RotaMaisBarataResponse>();
            double valorTotalRota = 0;
            string rotaCompleta = $"{request.Origem}";
            

            await FindMelhorRotaAsync(request.Origem, request.Destino, valorTotalRota, rotaCompleta,
                    rotasMaisBarata);

            var rotaEscolhida = rotasMaisBarata.OrderBy(x => x.ValorTotal).FirstOrDefault();
            return new GenericResponse(true, $"{rotaEscolhida.Rota} ao custo de ${rotaEscolhida.ValorTotal}", 
                rotasMaisBarata.OrderBy(x=> x.ValorTotal));
        }

        private async Task FindMelhorRotaAsync(string origemInicial, string destinoFinal, double valorTotal,
                    string rotaCompleta, 
                    List<RotaMaisBarataResponse> rotaMaisBarata) 
        {

            var rotaAlternativa = await _provider.GetRotaByOrigemAsync(origemInicial);
            foreach(var rota in rotaAlternativa) 
            {
                if (rota.Destino == destinoFinal)
                {
                    rotaMaisBarata.Add(new RotaMaisBarataResponse()
                    {
                        Rota = $"{rotaCompleta} - {rota.Destino}",
                        ValorTotal = valorTotal + rota.Valor,
                    });
                }
                else
                {
                    await FindMelhorRotaAsync(rota.Destino, destinoFinal, valorTotal + rota.Valor, 
                            rotaCompleta + $" - {rota.Destino}", rotaMaisBarata);
                }
            }

        }
    }
}
