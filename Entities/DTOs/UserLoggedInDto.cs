using System;
using Core.Entities;

namespace Entities.DTOs
{
    public class UserLoggedInDto : IDto
    {   
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string Expiration { get; set; }
    }
}
