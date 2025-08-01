using Microsoft.EntityFrameworkCore;
using RegistrationApi.Models;
using System.Collections.Generic;

namespace RegistrationApi.Context
{
    public class Contexts : DbContext
    {
        public Contexts(DbContextOptions<Contexts> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
