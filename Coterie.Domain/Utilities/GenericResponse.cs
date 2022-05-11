namespace DemoLayers.Domain.Infrastructure.Utilities
{
    public class GenericResponse<T>
    {
        public GenericResponse(bool isSucces = true)
        {
            IsSucces = isSucces;           
        }

        public GenericResponse(bool isSucces, T data) 
        {
            IsSucces = isSucces;
            Data = data;
        }

        public GenericResponse(bool isSucces, string message)
        {
            IsSucces = isSucces;
            Message = message;           
        }

        public T? Data { get; set; }

        public bool IsSucces { get; set; }

        public string? Message { get; }
    }
}
