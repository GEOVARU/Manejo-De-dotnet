using System;
using _5_Proyecto.Models;
using Microsoft.EntityFrameworkCore;
namespace _5_Proyecto.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }


        public DbSet<Libro> Libro { get;  set; }
    }
}