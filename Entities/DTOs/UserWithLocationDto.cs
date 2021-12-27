using System;
using Entities.Concrete;

namespace Entities.DTOs
{
	public class UserWithLocationDto
	{
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public Location Location { get; set; }
        public string ImagePath { get; set; }
    }
}

