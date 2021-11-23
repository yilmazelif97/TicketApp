using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        public OpenTicketsModel( TicketService ticketservice, EmployeeService employeservice, TicketRepository tickerrepo, EmployeeRepository emprepo)
        {
            _ticketrepository = tickerrepo;
            _ticketservice = ticketservice;
            _employeeservice = employeservice;
            _employerepository = emprepo;
        }

        [BindProperty]

        public Ticket TicketInput { get; set; }

        [BindProperty]

        public Employee EmployeeInput { get; set; }

        public Customer CustomerInput { get; set; }

        public IEnumerable<Customer> displayCustomer { get; set; }

        

        //Db'den customer verilerini alýyor 
        public async Task OnGet()
        {
            displayCustomer = _customerRepository.GetAll();

        }


        public void OnPostCreateTicket()
        {
           
            if (ModelState.IsValid)
            {

                try
                {
                    var ticket = new Ticket("DescriptionofTask", "SubjectOfTask");
                    ticket.SetDifficulty(LevelofDificulty.Easy);
                    ticket.SetPriority(Priortiy.One);

                    _ticketrepository.AddTicket(ticket);

                    _ticketservice.CreateTicket(ticket, CustomerInput);

                    var result = _ticketrepository.FindbyID(ticket.Id);


                    if (result != null)
                    {
                        ViewData["Message"] = "Kayýt Baþarýlýdýr";
                    }
                    else
                    {
                        ViewData["Message"] = "Tekrar deneyiniz";
                    }

                }
                catch (Exception ex)
                {

                    ModelState.AddModelError("Hata", ex.Message);

                }

            }

        }
    }
}
