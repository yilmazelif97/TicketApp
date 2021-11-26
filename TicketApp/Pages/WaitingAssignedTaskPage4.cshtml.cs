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
    public class AssignedTaskModel : PageModel
    {


        private readonly TicketService _ticketservice;
        private readonly EmployeeService _employeeservice;
        private readonly TicketRepository _ticketrepository;
        private readonly EmployeeRepository _employerepository;
        private readonly CustomerRepository _customerRepository;
        private readonly SendingEmail _semdingmail;



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

        [BindProperty]
        public SelectListItem dene { get; set; }



        public AssignedTaskModel(TicketService ticketservice, EmployeeService employeservice, TicketRepository tickerrepo, EmployeeRepository emprepo, CustomerRepository cusrepo, SendingEmail email)
        {
            _ticketrepository = tickerrepo;
            _ticketservice = ticketservice;
            _employeeservice = employeservice;
            _employerepository = emprepo;
            _customerRepository = cusrepo;
            _semdingmail = email;

            OpenTickets = new List<Ticket>();

        }




        public void OnGet( )
        {

            

            var Employee = _employerepository.GetAll();


            SelectListItems = Employee.Select(x => new SelectListItem
            {
                Value = x.Id ,
                Text = x.Name
            }).ToList();


            Tickets = _ticketrepository.Get();

            if (Tickets.Count != 0)
            {
                foreach (var item in Tickets)
                {
                    if (item.status == StatusofTask.Readyforassignment)
                    {
                        OpenTickets.Add(item);
                    }
                }
            }

            


        }

        //Assigned iþþemini yapýyor employe ye sonra save ediyor.
        public void OnPostSave( )
        {


            dene.Value();


            TicketInput = _ticketrepository.FindbyID(id);

            var emp = _ticketrepository.FindbyID(id).EmployeeID;

            EmployeeInput = _employerepository.Find(emp);

            TicketInput.AssignedDate = DateTime.Now.Date;

           

            _ticketservice.AssignTask(ticket:TicketInput , empid: TicketInput.EmployeeID, employee:EmployeeInput);

            _ticketservice.SetWorkHours(employee: EmployeeInput, ticket: TicketInput);



        }



    }
}
