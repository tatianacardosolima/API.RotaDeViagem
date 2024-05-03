using Azure.Core;
using Bogus;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RotaDeViagem.Domain.Commands.Request;
using RotaDeViagem.Domain.Commands.Response;
using RotaDeViagem.Domain.Entities;
using RotaDeViagem.Integration.Tests.Fixture;
using RotaDeViagem.Shared.Interfaces.IResponse;
using Bogus.DataSets;

namespace RotaDeViagem.Integration.Tests.Controllers
{
    public class RotaControllerTest: IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private AddNewRotaRequest addNewRotaRequest;
        
        Faker faker = new Faker();
        public RotaControllerTest(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
            addNewRotaRequest = new AddNewRotaRequest()
            {
                Destino = faker.Random.String2(3),
                Origem = faker.Random.String2(3),
                Valor = 10
            };
        }


        [Fact(DisplayName ="Validar o cenário principal de cadastro de rota")]        
        public async Task Validate_SaveRota_ShuldBeTrue()
        {
            // Act
            var content = ContentHelper.GetStringContent(addNewRotaRequest);
            var response = await _client.PostAsync("/rotas", content);

            var result = JsonConvert.DeserializeObject<GenericResponse>(response.Content.ReadAsStringAsync().Result);

            Assert.NotNull(result);
            Assert.True(result.Success);

        }

        [Fact(DisplayName = "Validar o cenário principal de alteração de rota")]
        public async Task Validate_UpdateRota_ShuldBeTrue()
        {

            var faker = new Faker();
            UpdRotaRequest request = new UpdRotaRequest()
            {
                Destino = faker.Random.String2(3),
                Origem = faker.Random.String2(3),
                Valor = 10
            };

            // Act
            var content = ContentHelper.GetStringContent(request);
            var response = await _client.PostAsync("/rotas", content);

            var result = JsonConvert.DeserializeObject<GenericResponse>(response.Content.ReadAsStringAsync().Result);

            Assert.NotNull(result);
            Assert.True(result.Success);

            var data = JsonConvert.DeserializeObject<dynamic>(result.Data.ToString());

            request.UniqueId = data.uniqueId;
            request.Destino = faker.Random.String2(3);
            content = ContentHelper.GetStringContent(request);
            response = await _client.PutAsync("/rotas", content);

            result = JsonConvert.DeserializeObject<GenericResponse>(response.Content.ReadAsStringAsync().Result);

            Assert.NotNull(result);
            Assert.True(result.Success);

        }

        [Fact(DisplayName = "Validar o cenário principal de alteração de rota")]
        public async Task Validate_DeleteRota_ShuldBeTrue()
        {

            var faker = new Faker();
            UpdRotaRequest request = new UpdRotaRequest()
            {
                Destino = faker.Random.String2(3),
                Origem = faker.Random.String2(3),
                Valor = 10
            };

            // Act
            var content = ContentHelper.GetStringContent(request);
            var response = await _client.PostAsync("/rotas", content);

            var result = JsonConvert.DeserializeObject<GenericResponse>(response.Content.ReadAsStringAsync().Result);

            Assert.NotNull(result);
            Assert.True(result.Success);

            var data = JsonConvert.DeserializeObject<dynamic>(result.Data.ToString());

            request.UniqueId = data.uniqueId;
            
            content = ContentHelper.GetStringContent(request);
            response = await _client.DeleteAsync($"/rotas/{request.UniqueId}");

            result = JsonConvert.DeserializeObject<GenericResponse>(response.Content.ReadAsStringAsync().Result);

            Assert.NotNull(result);
            Assert.True(result.Success);

        }
    }
}
