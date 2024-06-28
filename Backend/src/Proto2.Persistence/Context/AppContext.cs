using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;
using Proto2.Domain;

namespace Proto2.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Person> Person { get; set;}
        public DbSet<HomeCareCompany> HomeCareCompanies { get; set;}
        public DbSet<HomeCareContact> HomeCareContacts { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<HomeCareCompany>().HasMany(hc => hc.Contacts).WithOne(hc => hc.HomeCareCompany).OnDelete(DeleteBehavior.Cascade);
        }
    }
}