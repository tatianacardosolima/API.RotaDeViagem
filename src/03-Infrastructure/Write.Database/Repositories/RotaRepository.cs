using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RotaDeViagem.DatabaseRepository.Abastractions;
using RotaDeViagem.DatabaseRepository.Context;
using RotaDeViagem.Domain.Entities;
using RotaDeViagem.Domain.Interface.IRepositories;

namespace RotaDeViagem.DatabaseRepository.Repositories
{
    public class RotaRepository : AuditRepository<Rota, int>, IRotaRepository
    {
        public RotaRepository(RotaDeViagemContext context) : base(context)
        {
        }
    }
}
