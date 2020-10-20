using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogInApi.Models;

namespace LogInApi.Data
{
    public class AppClientContext : DbContext

    {

        public AppClientContext(DbContextOptions<AppClientContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppClient>().HasIndex(p => new {p.Nick, p.EmailAddress}).IsUnique(true);
        }

        public DbSet<AppClient> AppClientItems { get; set; }

    }
}
