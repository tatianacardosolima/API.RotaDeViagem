using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RotaDeViagem.Domain.Entities;
using AutoMapper;
using RotaDeViagem.Domain.Commands.Request;

namespace RotaDeViagem.UnitTests.Fixture
{
    public class RotaFixture
    {
        public RotaFixture() { }

        public IMapper GetMapper()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Rota, AddNewRotaRequest>().ReverseMap();
            });
            return mockMapper.CreateMapper();
        }
        public Rota CriarRota()
        {
            Faker faker = new Faker();
            
            
            return new Rota();
        }
    }
}
