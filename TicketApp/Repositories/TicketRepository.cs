﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketApp.Models;

namespace TicketApp.Repositories
{
    public class TicketRepository
    {
        private readonly TicketDbContext _db;

        public void AddTicket(Ticket ticket)
        {
            _db.Ticket.Add(ticket);
            _db.SaveChanges();
        }

        public void DeleteTicket(Ticket ticket)
        {
            _db.Ticket.Remove(ticket);
            _db.SaveChanges();
        }

        public void Update(Ticket ticket)
        {
            _db.Ticket.Update(ticket);
            _db.SaveChanges();
        }

        public Ticket FindbyID(string id)
        {
            return _db.Ticket.Find(id);

        }

        public Ticket FindbyStatus(string status)
        {
            return _db.Ticket.Find(status);
        }

       

    }
}
