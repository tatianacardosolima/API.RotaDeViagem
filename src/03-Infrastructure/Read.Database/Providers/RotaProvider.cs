using Dapper;
using RotaDeViagem.Domain.Commands.Response;
using RotaDeViagem.Domain.Interface.IProviders;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaDeViagem.Read.Database.Providers
{
    public class RotaProvider: IRotaProvider
    {
        private readonly IDbConnection _connection;

        public RotaProvider(IDbConnection connection) 
        {
            _connection = connection;
        }

        public async Task<IEnumerable<RotaResponse>> GetRotaByDestinoAsync(string destino)
        {
            var commandSql = @"Select Origem, Destino, Valor from Rota where destino = @destino";

            return await _connection.QueryAsync<RotaResponse>(commandSql, new
            {
                destino = destino
            });
        }

        public async Task<IEnumerable<RotaResponse>> GetRotaByOrigemAsync(string origem)
        {
            var commandSql = @"Select Origem, Destino, Valor from Rota where origem = @origem";

            return await _connection.QueryAsync<RotaResponse>(commandSql, new { origem = origem });
        }
    }
}
