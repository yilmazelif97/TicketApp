using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using TicketApp.Models;
using TicketApp.Repositories;
using TicketApp.Services;

namespace TicketApp.Pages
{
    public class TicketDetailsPage3Model : PageModel
    {
        private readonly TicketService _ticketservice;
        private readonly EmployeeService _employeeservice;
        private readonly TicketRepository _ticketrepository;
        private readonly EmployeeRepository _employerepository;
        private readonly CustomerRepository _customerRepository;
        private readonly SendingEmail _semdingmail;

        public TicketDetailsPage3Model(TicketService ticketservice, EmployeeService employeservice, TicketRepository tickerrepo, EmployeeRepository emprepo, CustomerRepository cusrepo, SendingEmail email)
        {
            _ticketrepository = tickerrepo;
            _ticketservice = ticketservice;
            _employeeservice = employeservice;
            _employerepository = emprepo;
            _customerRepository = cusrepo;
            _semdingmail = email;
        }

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

        //gelen id yi tutabilmek için
        [BindProperty]
        public string ID { get; set; }

        [BindProperty]
        public string Gender { get; set; }

        [BindProperty]
        public Priortiy priority { get; set; }

        public Array listpriority = Enum.GetValues(typeof (Priortiy));

        public Array listdifficulty = Enum.GetValues(typeof(LevelofDificulty));




        public void OnGet(string id)
        {
            ID = id;

            TicketInput = _ticketrepository.FindbyID(id);


        }


        public void OnPostSetPriorityandDifficulty()
        {

            _ticketservice.SetPriority(TicketInput);  //Update priority of task

            _ticketservice.SetDifficulty(TicketInput);  //Update difficulty of task

            TicketInput.status = StatusofTask.Assigned;

        }

        

    }
}
