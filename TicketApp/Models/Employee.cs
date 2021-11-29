using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketApp.Models
{
    public class Employee
    {

        //Employee Entity

        public string Id { get;  set; } = Guid.NewGuid().ToString();
        public string Name { get;  set; }
        public string Mail { get;   set; }
        public List<Ticket> Ticket { get; set; } = new List<Ticket>();
        public int WorkHours { get; set; } = 0;


        //public void SetTickettoEmp(Ticket ticket)
        //{
        //    Ticket.Add(ticket);
        //}

        //public void SetWorkHours(int hours)
        //{
        //    this.WorkHours = hours;
        //}

       


    }
}
