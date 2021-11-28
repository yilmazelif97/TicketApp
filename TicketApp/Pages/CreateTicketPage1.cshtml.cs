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
    public class OpenTicketsModel : PageModel
    {

        private readonly TicketService _ticketservice;
        private readonly EmployeeService _employeeservice;
        private readonly TicketRepository _ticketrepository;
        private readonly EmployeeRepository _employerepository;
        private readonly CustomerRepository _customerRepository;
        private readonly SendingEmail _semdingmail;

        public OpenTicketsModel( TicketService ticketservice, EmployeeService employeservice, TicketRepository tickerrepo, EmployeeRepository emprepo,CustomerRepository cusrepo, SendingEmail email)
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

        [BindProperty]
        public Employee EmployeeInput { get; set; }

        public Customer CustomerInput { get; set; }

        public Customer displayCustomer { get; set; }

        public List<SelectListItem> SelectListItems = new List<SelectListItem>();

        [BindProperty]
        public string selectedcustomerid { get; set; }




        //Db'den customer verilerini al�yor, selectedlisitem framework taraf�ndan sa�lan�yor 
        public void OnGet()
        {
             var Customers = _customerRepository.GetAll();

            SelectListItems = Customers.Select(x => new SelectListItem
            {
                Value = x.ID,
                Text = x.Name
            }).ToList();

        }


        public void OnPostCreateTicket()
        {
           
            if (ModelState.IsValid)
            {


                //var ticket = new Ticket();



                    TicketInput.OpenDate = DateTime.Now;
                    TicketInput.status = StatusofTask.Open;

                    _ticketservice.CreateTicket(TicketInput);

                    EmployeeInput.Ticket.Add(TicketInput);

                    var result = _ticketrepository.FindbyID(TicketInput.Id);

                   // var customermail = _customerRepository.Find(selectedcustomerid.ToString());


                if (result != null)
                    {
                        ViewData["Message"] = "Kay�t Ba�ar�l�d�r";

                    //    _semdingmail.SendEmail(from:"elifyilmaz587@gmail.com", to:customermail.Mail, message:$"{TicketInput.Id} nolu Task A��lm��t�r", subject: "Ticket ID");


                    }
                    else
                    {
                        ViewData["Message"] = "Tekrar deneyiniz";
                    }

          
            }

        }
    }
}
