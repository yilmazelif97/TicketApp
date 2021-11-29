using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TicketApp.Models;
using TicketApp.Repositories;
using TicketApp.Services;

namespace TicketApp.Pages
{
    public class ReviewPageModel : PageModel
    {


        private readonly TicketService _ticketservice;
        private readonly EmployeeService _employeeservice;
        private readonly TicketRepository _ticketrepository;
        private readonly EmployeeRepository _employerepository;
        private readonly CustomerRepository _customerRepository;
        private readonly SendingEmail _semdingmail;
        private readonly ManagerRepository _managerrepository;



        [BindProperty]

        public Ticket TicketInput { get; set; }

        [BindProperty]
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

        [BindProperty]
        public string ID { get; set; }



        public ReviewPageModel(TicketService ticketservice, EmployeeService employeservice, TicketRepository tickerrepo, EmployeeRepository emprepo, CustomerRepository cusrepo, SendingEmail email, ManagerRepository managerrepository)
        {
            _ticketrepository = tickerrepo;
            _ticketservice = ticketservice;
            _employeeservice = employeservice;
            _employerepository = emprepo;
            _customerRepository = cusrepo;
            _semdingmail = email;

            //OpenTickets = new List<Ticket>();

            _managerrepository = managerrepository;
        }



        public void OnGet()
        {

            Tickets = _ticketrepository.Get();

            if (Tickets.Count != 0)
            {
                foreach (var item in Tickets)
                {
                    if (item.status == StatusofTask.Review)
                    {
                        OpenTickets.Add(item);
                    }
                }
            }
        }

        public void OnPostCloseTask(string id)
        {

            ID = id;

            TicketInput = _ticketrepository.FindbyID(id);

            _ticketservice.CloseTask(ticket: TicketInput);

            var employeemail = _employerepository.Find(TicketInput.CustomerId);

            var manager = _managerrepository.Find("1");

            _semdingmail.SendEmail(from: "nbuy.oglen@gmail.com", to: manager.Mail, message: $"{TicketInput.Id} nolu Task Closed", subject: "Ticket ID");

          
        }

    }
}
