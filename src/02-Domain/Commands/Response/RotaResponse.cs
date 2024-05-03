using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaDeViagem.Domain.Commands.Response
{
    public class RotaResponse
    {
        public string Origem { get; set; }
        public string Destino { get; set; }
        public double Valor { get; set; }
    }
}
