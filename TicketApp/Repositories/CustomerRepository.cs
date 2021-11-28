using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketApp.Models;

namespace TicketApp.Repositories
{

    //Controlling customer table in DB 
    public class CustomerRepository
    {
        private readonly TicketDbContext _db;
        public CustomerRepository()
        {
            _db = new TicketDbContext();
        }
        
        //find specific data from customer table
        public Customer Find(string id)
        {
            return _db.Customer.Find(id);
        }

        public Customer FindbyName(string name)
        {
            return _db.Customer.Find(name);
        }


      
        //getting all customer of db 
        public List<Customer> GetAll()
        {
            return _db.Customer.ToList();
        }
       
    }
}
