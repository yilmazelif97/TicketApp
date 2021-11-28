using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketApp.Models
{
    public class Customer
    {

        //Customer Entity

        public string ID { get;  set; }
        public string Name { get;  set; }
        public string Mail { get; set; }

        public Customer(string name, string mail)
        {
            ID = Guid.NewGuid().ToString();
            Name = name;
            Mail = mail;

        }



    }
}
