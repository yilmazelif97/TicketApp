using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketApp.Models
{
    public class Manager
    {

        public string ID { get;  set; }
        public string Name { get; private set; }

        public string EmployeId { get; set; }
        public Employee Employee { get;  set; }

        public Manager(string name)
        {
            ID = Guid.NewGuid().ToString();
            Name = name;
        }


    }
}
