using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketApp.Models;

namespace TicketApp.Repositories
{
    public class CustomerRepository
    {
        private readonly TicketDbContext _db;
        

        public Customer Find(string id)
        {
            return _db.Customer.Find(id);
        }

        public List<Customer> GetAll()
        {
            return _db.Customer.ToList();
        }
       
    }
}
