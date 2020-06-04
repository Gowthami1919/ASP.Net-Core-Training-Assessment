using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieCrudOpe.Models;

namespace MovieCrudOpe.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _content;
        public AuthRepository(DataContext context)
        {
            _content = context;
        }
        public async Task<UserRegister> Login(string username, string password)
        {
            var user = await _content.Register.FirstOrDefaultAsync(x => x.UserName == username && x.Password==password);
            if (user == null)
                return null;
            return user;
        }

        public async Task<UserRegister> Register(UserRegister userRegister)
        {
            await _content.Register.AddAsync(userRegister);
            await _content.SaveChangesAsync();
            return userRegister;

        }

        public async Task<bool> UserExists(string username)
        {
            if (await _content.Register.AnyAsync(x => x.UserName == username))

                return true;
            return false;
        }
    }
}
