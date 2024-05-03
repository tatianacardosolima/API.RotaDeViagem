using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RotaDeViagem.Domain.Entities;

namespace RotaDeViagem.UnitTests.Fixture
{
    public class RotaFixture
    {
        public RotaFixture() { }

        public Rota CriarRota()
        {
            Faker faker = new Faker();
            
            
            return new Rota();
        }
    }
}
