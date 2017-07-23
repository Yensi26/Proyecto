using Domain;
using System.Collections.Generic;

namespace API.Classes
{
    public class UserResponse
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Picture { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }
    }

}