using RotaDeViagem.Shared.Interfaces.IResponse;

namespace RotaDeViagem.Domain.Commands.Response
{
    public class GenericResponse: IGenericResponse
    {
        public GenericResponse(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public GenericResponse(bool success, string message)
        {
            Success = success;
            Message = message;

        }
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
