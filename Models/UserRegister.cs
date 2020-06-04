using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCrudOpe.Models
{
    public class UserRegister
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int age { get; set; }
        public string Gender { get; set; }
        public int phoneNumber { get; set; }
        public string Address { get; set; }
    }
}
