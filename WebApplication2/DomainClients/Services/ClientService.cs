using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication2.DomainClients.Domain.Models;
using WebApplication2.DomainClients.Domain.Repositories;
using WebApplication2.DomainClients.Domain.Services;
using WebApplication2.DomainClients.Domain.Services.Communications;
using WebApplication2.Shared.Domain.Repositories;

namespace WebApplication2.DomainClients.Services
{
    public class ClientService : IClientService
    {
        private IClientRepository _clientRepository;
        private IUnitOfWork _unitOfWork;

        public ClientService(IClientRepository clientRepository, IUnitOfWork unitOfWork)
        {
            _clientRepository = clientRepository;
            _unitOfWork = unitOfWork;
        }
        
        public async Task<IEnumerable<Client>> ListAsync()
        {
            return await _clientRepository.ListAsync();
        }

        public async Task<Client> FindAsync(int id)
        {
            return await _clientRepository.FindAsync(id);
        }

        public async Task<ClientResponse> SaveAsync(Client client)
        {
            var existingClient = _clientRepository.FindByDniAsync(client.Dni);
            if (existingClient == null)
                return new ClientResponse("This DNI already exists.");
            try
            {
                await _clientRepository.AddAsync(client);
                await _unitOfWork.CompleteAsync();
                return new ClientResponse(client);
            }
            catch (Exception e)
            {
                return new ClientResponse($"An error occurred while saving the Client: {e.Message}");
            }
        }

        public async Task<ClientResponse> UpdateAsync(int id, Client client)
        {
            var existingClient = await _clientRepository.FindAsync(id);
            if (existingClient == null)
                return new ClientResponse("Client not found.");
            
            var existingDni = _clientRepository.FindByDniAsync(client.Dni);
            if (existingDni == null)
                return new ClientResponse("This DNI already exists.");
            existingClient.Dni = client.Dni;
            existingClient.Address = client.Address;
            existingClient.FirstName = client.FirstName;
            existingClient.LastName = client.LastName;
            try
            {
                 _clientRepository.UpdateAsync(existingClient);
                await _unitOfWork.CompleteAsync();
                return new ClientResponse(existingClient);
            }
            catch (Exception e)
            {
                return new ClientResponse($"An error occurred while updating the Client: {e.Message}");
            }
        }

        public async Task<ClientResponse> DeleteAsync(int id)
        {
            var existingClient = await _clientRepository.FindAsync(id);
            if (existingClient == null)
                return new ClientResponse("Client not found.");
            
            try
            {
                _clientRepository.Delete(existingClient);
                await _unitOfWork.CompleteAsync();
                return new ClientResponse(existingClient);
            }
            catch (Exception e)
            {
                return new ClientResponse($"An error occurred while deleting the Client: {e.Message}");
            }
        }
    }
}