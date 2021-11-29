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
    //in there, creating a new ticket and showing customers in dropdownlist

    public class OpenTicketsModel : PageModel
    {

        private readonly TicketService _ticketservice;
        private readonly EmployeeService _employeeservice;
        private readonly TicketRepository _ticketrepository;
        private readonly EmployeeRepository _employerepository;
        private readonly CustomerRepository _customerRepository;
        private readonly SendingEmail _semdingmail;
        private readonly ManagerRepository _managerrepository;

        public OpenTicketsModel( TicketService ticketservice, EmployeeService employeservice, TicketRepository tickerrepo, EmployeeRepository emprepo,CustomerRepository cusrepo, SendingEmail email, ManagerRepository managerrepository)
        {
            _ticketrepository = tickerrepo;
            _ticketservice = ticketservice;
            _employeeservice = employeservice;
            _employerepository = emprepo;
            _customerRepository = cusrepo;
            _semdingmail = email;
            _managerrepository = managerrepository;
        }

        [BindProperty]

        public Ticket TicketInput { get; set; }

        [BindProperty]
        public Employee EmployeeInput { get; set; }

        public Customer CustomerInput { get; set; }

        public Customer displayCustomer { get; set; }

        public List<SelectListItem> SelectListItems = new List<SelectListItem>();

        [BindProperty]
        public string selectedcustomerid { get; set; }





        //Db'den customer verilerini alýyor, selectedlisitem framework tarafýndan saðlanýyor 
        public void OnGet()
        {
             var Customers = _customerRepository.GetAll();

            SelectListItems = Customers.Select(x => new SelectListItem
            {
                Value = x.ID,
                Text = x.Name
            }).ToList();

        }

        //Creating ticket and sending information mail to customer that include task is opened message

        public void OnPostCreateTicket()
        {
           
            if (ModelState.IsValid)
            {


                    TicketInput.OpenDate = DateTime.Now;
                    TicketInput.status = StatusofTask.Open;

                    _ticketservice.CreateTicket(TicketInput);

                    EmployeeInput.Ticket.Add(TicketInput);

                    var result = _ticketrepository.FindbyID(TicketInput.Id);

                    var customermail = _customerRepository.Find(TicketInput.CustomerId);

                    var manager = _managerrepository.Find("02c598ac-ef7f-4216-b170-c58de90c952f");


                if (result != null)
                    {
                        ViewData["Message"] = "Kayýt Baþarýlýdýr";

                        _semdingmail.SendEmail(from: "nbuy.oglen@gmail.com", to:customermail.Mail , message:$"{TicketInput.Id} nolu Task Açýlmýþtýr", subject: "Ticket ID");


                    }
                    else
                    {
                        ViewData["Message"] = "Tekrar deneyiniz";
                    }

          
            }

        }
    }
}
