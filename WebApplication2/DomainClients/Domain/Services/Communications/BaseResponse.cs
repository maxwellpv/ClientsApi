namespace WebApplication2.DomainClients.Domain.Services.Communications
{
    public class BaseResponse<T>
    {
        public bool Success { get; protected set; }
        public string Message { get; protected set; }

        public T Resource { get; private set; }
        
        protected BaseResponse(string message)
        {
            Success = false;
            Message = message;
        }
        
        protected BaseResponse(T resource)
        {
            Success = true;
            Resource = resource;
        }

    }
}