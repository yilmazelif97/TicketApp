using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketApp.Models
{
    public class TicketDbContext : DbContext
    {

        public TicketDbContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server= . ;Database= TicketDB; uid=sa;pwd=1234 ;MultipleActiveResultSets=true");


            base.OnConfiguring(optionsBuilder);
        }



        public DbSet<Customer> Customer {get;set;}
        public DbSet<Employee>  Employee { get; set; }
        public DbSet<Manager> Manager { get; set; }
        public DbSet<Ticket> Ticket { get; set; }






    }
}
