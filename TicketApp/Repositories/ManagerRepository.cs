using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketApp.Models;

namespace TicketApp.Repositories
{
    public class ManagerRepository
    {

        private readonly TicketDbContext _db;

        public ManagerRepository()
        {
            _db = new TicketDbContext();
        }

        public Manager Find(string id)
        {
            return _db.Manager.Find(id);
        }

      

    }
}
