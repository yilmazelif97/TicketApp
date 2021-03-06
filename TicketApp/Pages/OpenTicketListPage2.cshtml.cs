using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using TicketApp.Models;
using TicketApp.Repositories;
using TicketApp.Services;

namespace TicketApp.Pages
{
    public class OpenTicketListPage2Model : PageModel
    {

        private readonly TicketService _ticketservice;
        private readonly EmployeeService _employeeservice;
        private readonly TicketRepository _ticketrepository;
        private readonly EmployeeRepository _employerepository;
        private readonly CustomerRepository _customerRepository;
        private readonly SendingEmail _semdingmail;

      

        [BindProperty]

        public Ticket TicketInput { get; set; }


        public Employee EmployeeInput { get; set; }

        public Customer CustomerInput { get; set; }

        public Customer displayCustomer { get; set; }

        public List<SelectListItem> SelectListItems = new List<SelectListItem>();

        [BindProperty]
        public string selectedcustomerid { get; set; }

        [BindProperty]
        public List<Ticket> Tickets { get; set; }

        [BindProperty]
        public List<Ticket> OpenTickets { get; set; }

        public OpenTicketListPage2Model(TicketService ticketservice, EmployeeService employeservice, TicketRepository tickerrepo, EmployeeRepository emprepo, CustomerRepository cusrepo, SendingEmail email)
        {
            _ticketrepository = tickerrepo;
            _ticketservice = ticketservice;
            _employeeservice = employeservice;
            _employerepository = emprepo;
            _customerRepository = cusrepo;
            _semdingmail = email;

            OpenTickets = new List<Ticket>();

        }

        //When page is  uploaded, automatically Opened tasks are filling with OnGet() function

        public void OnGet()
        {

            Tickets = _ticketrepository.Get();

            if (Tickets.Count != 0)
            {
                foreach (var item in Tickets)
                {
                    if (item.status == StatusofTask.Open)
                    {
                        OpenTickets.Add(item);
                        
                    }
                }
            }

             OpenTickets=OpenTickets.OrderByDescending(x => x.OpenDate).ToList();


           
        }

        public void OnPostSetTech()
        {

        }
    }
}
