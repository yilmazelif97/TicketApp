using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketApp.Models
{
    public class Employee
    {

        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Mail { get; private  set; }
        public Ticket Ticket { get; set; }
        public int WorkHours { get; private set; }
        public Manager Manager { get; set; }

        public Employee(string name, string mail)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            Mail = mail;
        }

       


    }
}
