using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectRF.ConsumerApi.Models
{
    public class RegisterDomain
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set;}
        public string Email { get; set; }
        public string Password { get; set; }
    }
}