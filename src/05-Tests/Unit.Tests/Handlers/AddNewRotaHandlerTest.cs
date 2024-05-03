using AutoMapper;
using Moq;
using RotaDeViagem.Domain.Commands.Request;
using RotaDeViagem.Domain.Entities;
using RotaDeViagem.Domain.Handlers.Corretores;
using RotaDeViagem.Domain.Interface.IRepositories;
using RotaDeViagem.Shared.Exceptions;
using RotaDeViagem.Shared.Interfaces.IResponse;
using RotaDeViagem.UnitTests.Fixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaDeViagem.UnitTests.Entities
{
    public class AddNewRotaHandlerTest
    {

        [Fact(DisplayName ="01 - Validar quando origem da rota é vázio")]
        public async Task AddNewRota_WhenOrigemIsEmpty_ShouldError()
        {
            Mock<IRotaRepository> rotaRepository = new();

            var mapper = new RotaFixture().GetMapper();
            
            AddNewRotaHandler handler = new(rotaRepository.Object, mapper);
            AddNewRotaRequest request = new AddNewRotaRequest()
            {
                Destino = "AAA",
                Valor = 20,
                Origem = ""
            };
            var exception1 = await Assert.ThrowsAsync<DomainException>( () => handler.Handle(request, CancellationToken.None ));
            
            request = new AddNewRotaRequest()
            {
                Destino = "AAA",
                Valor = 20
            };
            var exception2 = await Assert.ThrowsAsync<DomainException>(() => handler.Handle(request, CancellationToken.None));

            Assert.True(exception1.Message == "O campo origem é obrigatório.");
            Assert.True(exception2.Message == "O campo origem é obrigatório.");

        }

        [Fact(DisplayName = "02 - Validar quando origem tem mais do que 3 caracteres")]
        public async Task AddNewRota_WhenOrigemMoreThan3Characters_ShouldError()
        {
            Mock<IRotaRepository> rotaRepository = new();

            var mapper = new RotaFixture().GetMapper();

            AddNewRotaHandler handler = new(rotaRepository.Object, mapper);
            AddNewRotaRequest request = new AddNewRotaRequest()
            {
                Destino = "AAA",
                Valor = 20,
                Origem = "BBBB"
            };
            var exception1 = await Assert.ThrowsAsync<DomainException>(() => handler.Handle(request, CancellationToken.None));
            Assert.True(exception1.Message == "A origem deve conter no máxim 3 caracteres.");

        }

        [Fact(DisplayName = "03 - Validar quando destino da rota é vázio")]
        public async Task AddNewRota_WhenDestinoIsEmpty_ShouldError()
        {
            Mock<IRotaRepository> rotaRepository = new();

            var mapper = new RotaFixture().GetMapper();

            AddNewRotaHandler handler = new(rotaRepository.Object, mapper);
            AddNewRotaRequest request = new AddNewRotaRequest()
            {
                Destino = "",
                Valor = 20,
                Origem = "AAA"
            };
            var exception1 = await Assert.ThrowsAsync<DomainException>(() => handler.Handle(request, CancellationToken.None));

            request = new AddNewRotaRequest()
            {
                Origem = "AAA",
                Valor = 20
            };
            var exception2 = await Assert.ThrowsAsync<DomainException>(() => handler.Handle(request, CancellationToken.None));

            Assert.True(exception1.Message == "O campo destino é obrigatório.");
            Assert.True(exception2.Message == "O campo destino é obrigatório.");

        }

        [Fact(DisplayName = "04 - Validar quando destino tem mais do que 3 caracteres")]
        public async Task AddNewRota_WhenDestinoMoreThan3Characters_ShouldError()
        {
            Mock<IRotaRepository> rotaRepository = new();

            var mapper = new RotaFixture().GetMapper();

            AddNewRotaHandler handler = new(rotaRepository.Object, mapper);
            AddNewRotaRequest request = new AddNewRotaRequest()
            {
                Destino = "AAAA",
                Valor = 20,
                Origem = "BBB"
            };
            var exception1 = await Assert.ThrowsAsync<DomainException>(() => handler.Handle(request, CancellationToken.None));
            Assert.True(exception1.Message == "O destino deve conter no máxim 3 caracteres.");

        }

        [Fact(DisplayName = "05 - Validar quando origem e destino são iguais")]
        public async Task AddNewRota_WhenOrigemEDestinoAreEquals_ShouldError()
        {
            Mock<IRotaRepository> rotaRepository = new();

            var mapper = new RotaFixture().GetMapper();

            AddNewRotaHandler handler = new(rotaRepository.Object, mapper);
            AddNewRotaRequest request = new AddNewRotaRequest()
            {
                Destino = "AAA",
                Valor = 20,
                Origem = "AAA"
            };
            var exception1 = await Assert.ThrowsAsync<DomainException>(() => handler.Handle(request, CancellationToken.None));
            Assert.True(exception1.Message == "A origem e o Destino devem ser diferentes.");

        }
    }
}
