﻿namespace WebApplication2.DomainClients.Domain.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Dni { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    }
}