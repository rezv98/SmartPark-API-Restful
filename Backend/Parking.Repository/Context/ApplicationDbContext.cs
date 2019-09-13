using Parking.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace Parking.Repository.Context
{
    public class ApplicationDbContext: DbContext
    {
         public DbSet<Assessment> assessments { get; set; }
         public DbSet<Booking> bookings { get; set; }
         public DbSet<Driver> drivers { get; set; }
         public DbSet<Owner> owners{get;set;}
         public DbSet<Parkings> parkings {get; set;}
         public DbSet<Rate> rates {get; set;}
         public DbSet<Space> spaces {get; set;}
         public DbSet<Vehicle> vehicles {get; set;}

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        //Write Fluent API configurations here


        }

    

    }
}