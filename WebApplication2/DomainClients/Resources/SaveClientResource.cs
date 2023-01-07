using System.ComponentModel.DataAnnotations;

namespace WebApplication2.DomainClients.Resources
{
    public class SaveClientResource
    {
        [Required]
        public string Dni { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
    }
}