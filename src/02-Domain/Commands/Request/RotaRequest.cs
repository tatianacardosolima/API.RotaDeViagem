using RotaDeViagem.Domain.Interface.Request;

namespace RotaDeViagem.Domain.Commands.Request
{
    public class AddNewRotaRequest : RotaRequest,ICommandRequest
    {

    }

    public class UpdRotaRequest : RotaRequest, IUniqueIdCommandRequest
    {
        public Guid UniqueId { get; set; }
    }

    public class FindRotaRequest: ICommandRequest
    {
        public string Origem { get; set; }
        public string Destino { get; set; }
    
    }

    public class RotaRequest
    {
        public string Origem { get; set; }
        public string Destino { get; set; }
        public double Valor { get; set; }
    }

    public class DelRotaRequest:  IUniqueIdCommandRequest
    {
        public DelRotaRequest(Guid uniqueId)
        {            
            UniqueId = uniqueId;
        }

        public Guid UniqueId { get; set; }
    }    
}
