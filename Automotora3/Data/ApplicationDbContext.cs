using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Automotora3.Models;

namespace Automotora3.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Automotora3.Models.Sucursales> Sucursales { get; set; }
        public DbSet<Automotora3.Models.Vehiculos> Vehiculos { get; set; }
        public DbSet<Automotora3.Models.Clientes> Clientes { get; set; }
        public DbSet<Automotora3.Models.Correo> Correo { get; set; }
    }
}
