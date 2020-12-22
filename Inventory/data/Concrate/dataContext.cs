using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace data
{
    public class dataContext : IdentityDbContext<User>
    {
        
        public DbSet<Item> Items { get; set; }
        public dataContext(DbContextOptions<dataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<User>()
                .HasMany(c => c.Items)
                .WithOne(e => e.user);
            base.OnModelCreating(modelBuilder);
        }
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS; Initial Catalog=InvertoryData;Integrated Security=SSPI;");
        }*/
    }
}
