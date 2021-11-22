using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketApp.Models
{
    public class Manager
    {

        public string ID { get;private  set; }
        public string Name { get; private set; }
        public Employee Employee { get;  set; }

        public Manager()
        {
            ID = Guid.NewGuid().ToString();
        }

    }
}
