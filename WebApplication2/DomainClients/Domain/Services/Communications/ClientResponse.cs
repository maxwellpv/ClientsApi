using WebApplication2.DomainClients.Domain.Models;

namespace WebApplication2.DomainClients.Domain.Services.Communications
{
    public class ClientResponse : BaseResponse<Client>
    {
        public ClientResponse(string message) : base(message){}
        public ClientResponse(Client resource): base(resource){}
    }
}