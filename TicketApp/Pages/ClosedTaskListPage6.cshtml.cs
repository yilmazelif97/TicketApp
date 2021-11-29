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
    public class ClosedTaskModel : PageModel
    {

        //There is functions for updating status of tasks as a complete or review

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



        public ClosedTaskModel(TicketService ticketservice, EmployeeService employeservice, TicketRepository tickerrepo, EmployeeRepository emprepo, CustomerRepository cusrepo, SendingEmail email, ManagerRepository managerrepository)
        {
            _ticketrepository = tickerrepo;
            _ticketservice = ticketservice;
            _employeeservice = employeservice;
            _employerepository = emprepo;
            _customerRepository = cusrepo;
            _semdingmail = email;

            OpenTickets = new List<Ticket>();

            _managerrepository = managerrepository;

        }

        //When page is  uploaded, automatically Cloesd tasks are filling with OnGet() function


        public void OnGet()
        {
            Tickets = _ticketrepository.Get();

            if (Tickets.Count != 0)
            {
                foreach (var item in Tickets)
                {
                    if (item.status == StatusofTask.Closed)
                    {
                        OpenTickets.Add(item);
                    }
                }
            }

        }

        //Find sended id in ticket table in DB and update status of task as Reviewed and send information mail to assigned employee to this task

        public void OnPostReviewTask(string id)
        {

            ID = id;

            TicketInput = _ticketrepository.FindbyID(id);

            EmployeeInput = _employerepository.Find(TicketInput.CustomerId);

            _ticketservice.ReviewTask(ticket: TicketInput);

            var manager = _managerrepository.Find("1");

            _semdingmail.SendEmail(from: "nbuy.oglen@gmail.com", to: EmployeeInput.Mail, message: $"{TicketInput.Id} nolu Task Reviewed", subject: "Ticket ID");

           


        }

        //Find sended id in ticket table in DB and update status of task as Complete and send information mail to assigned Customer to this task

        public void OnPostCompleteTask(string id)
        {


            ID = id;

            TicketInput = _ticketrepository.FindbyID(id);

            EmployeeInput = _employerepository.Find(TicketInput.CustomerId);

            _ticketservice.CompleteTask(ticket: TicketInput);

            var customer = _customerRepository.Find(TicketInput.CustomerId);

            var manager = _managerrepository.Find("1");


            _semdingmail.SendEmail(from: "nbuy.oglen@gmail.com", to: customer.Mail, message: $"{TicketInput.Id} nolu Task Açýlmýþtýr", subject: "Ticket ID");


        }

    }
}
