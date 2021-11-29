using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketApp.Models
{
    public class TicketDbContext : DbContext
    {

        //For reach to DB 
        public TicketDbContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=TicketAppDB;uid=sa;pwd=1234;MultipleActiveResultSets=true");


            base.OnConfiguring(optionsBuilder);
        }


        //Creating table of entity in DB
        public DbSet<Customer> Customer {get;set;}
        public DbSet<Employee>  Employee { get; set; }
        public DbSet<Manager> Manager { get; set; }
        public DbSet<Ticket> Ticket { get; set; }






    }
}
