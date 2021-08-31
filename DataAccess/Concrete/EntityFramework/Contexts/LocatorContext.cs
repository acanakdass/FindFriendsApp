using System;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class LocatorContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite(@"Data Source=/Users/ahmetcanakdas/Projects/FreelancerProject/FREELANCER/DataAccess");
            optionsBuilder.UseNpgsql(@"Server=localhost;Port=5432;Database=FINDMYFRIENDS;User Id=postgres;Password=acanakdas;Integrated Security=true;Pooling=true;");
        }

        public DbSet<Friends> Friends { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

    }
}
