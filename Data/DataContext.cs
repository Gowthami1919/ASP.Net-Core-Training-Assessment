using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieCrudOpe.Models;

namespace MovieCrudOpe.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> Options) : base(Options) { }
        public DbSet<UserLogin> Login { get; set; }
        public DbSet<UserRegister> Register { get; set; }
        public DbSet<Movie> Movies { get; set; }
    }
}
