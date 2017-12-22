using Microsoft.EntityFrameworkCore;
using NeighbourDelivery.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighbourDelivery.Database
{
    public class NdDbContext : DbContext
    {
        public NdDbContext(DbContextOptions<NdDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Course>().ToTable("Course");
        }
    }
}
