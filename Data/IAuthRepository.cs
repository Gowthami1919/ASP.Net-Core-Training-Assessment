using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieCrudOpe.Models;

namespace MovieCrudOpe.Data
{
    public interface IAuthRepository
    {
        Task<UserRegister> Register(UserRegister userRegister);

        Task<UserRegister> Login(string username, string password);

        Task<bool> UserExists(string username);

    }
}
