using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketApp.Models;

namespace TicketApp.Repositories
{
    public class TicketRepository
    {
        private readonly TicketDbContext _db;

        public TicketRepository()
        {
            _db = new TicketDbContext();
        }
       
        //Adding ticket to DB
        public void AddTicket(Ticket ticket)
        {
            _db.Ticket.Add(ticket);
            _db.SaveChanges();
        }

        //Deleting specific ticket from ticket table 
        public void DeleteTicket(Ticket ticket)
        {
            _db.Ticket.Remove(ticket);
            _db.SaveChanges();
        }

        //updating ticket
        public void Update(Ticket ticket)
        {
            _db.Ticket.Update(ticket);
            _db.SaveChanges();
        }

        //finding specific id from ticket table
        public Ticket FindbyID(string id)
        {
            return _db.Ticket.Find(id);

        }

        //finding ticket by status of ticket 
        public Ticket FindbyStatus(StatusofTask status)
        {
            return _db.Ticket.Find(status);
        }

        //getting all ticket
        public List<Ticket> Get()
        {
            return _db.Ticket.ToList();
        }



    }
}
