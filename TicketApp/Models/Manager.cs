using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketApp.Models
{
    public class Manager


    {

        //Manager Entity

        public string ID { get;  set; }
        public string Name { get;  set; }

        public string Mail { get; set; }
        public string EmployeId { get; set; }
        public Employee Employee { get;  set; }

       


    }
}
