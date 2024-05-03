namespace RotaDeViagem.Shared.Interfaces.IResponse
{
    public interface IGenericResponse
    {
        bool Success { get; set; }

        string Message { get; set; }

        object Data { get; set; }
    }
}
