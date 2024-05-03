namespace RotaDeViagem.Domain.Commands.Response
{
    public class RotaResponse
    {
        public string Origem { get; set; }
        public string Destino { get; set; }
        public double Valor { get; set; }
    }

    public class RotaMaisBarataResponse
    {
        public string Rota { get; set; }
        public double ValorTotal { get; set; }
        //public List<RotaResponse> Rotas { get; set; }
    }

}
