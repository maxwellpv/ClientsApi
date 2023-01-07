using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.DomainClients.Domain.Models;
using WebApplication2.DomainClients.Domain.Services;
using WebApplication2.DomainClients.Resources;
using WebApplication2.Shared.Extensions;

namespace WebApplication2.DomainClients.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;

        public ClientController(IClientService clientService, IMapper mapper)
        {
            _mapper = mapper;
            _clientService = clientService;
        }
        
        [HttpGet]
        public async Task<IEnumerable<ClientResource>> GetAllClients()
        {
            var clients = await _clientService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Client>, IEnumerable<ClientResource>>(clients);
            return resources;
        }
        
        [HttpGet("{id:int}")]
        public async Task<ClientResource> GetClientById(int id)
        {
            var client = await _clientService.FindAsync(id);
            var resource = _mapper.Map<Client, ClientResource>(client);
            return resource;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveClientResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var client = _mapper.Map<SaveClientResource, Client>(resource);
            var result = await _clientService.SaveAsync(client);
            if (!result.Success)
                return BadRequest(result.Message);
            var clientResource = _mapper.Map<Client, ClientResource>(result.Resource);
            return Ok(clientResource);
        }
        
        [HttpPut ("{id:int}")]
        public async Task<IActionResult> PutAsync([FromBody] SaveClientResource resource, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var client = _mapper.Map<SaveClientResource, Client>(resource);
            var result = await _clientService.UpdateAsync(id, client);
            if (!result.Success)
                return BadRequest(result.Message);
            var clientResource = _mapper.Map<Client, ClientResource>(result.Resource);
            return Ok(clientResource);
        }
        
        [HttpDelete ("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _clientService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var clientResource = _mapper.Map<Client, ClientResource>(result.Resource);
            return Ok(clientResource);
        }


    }
}