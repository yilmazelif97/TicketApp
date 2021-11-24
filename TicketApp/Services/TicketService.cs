using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketApp.Models;
using TicketApp.Repositories;

namespace TicketApp.Services
{
    public class TicketService
    {
        TicketRepository _ticketRepository;
        EmployeeRepository _employeeRepository;


        public TicketService(TicketRepository ticketrepository)
        {
            _ticketRepository = ticketrepository;
        }

        
        public void CreateTicket(Ticket ticket)
        {

            if (ticket == null)
            {
                throw new Exception("You have to create ticket");
            }

         

            if (string.IsNullOrEmpty(ticket.Description))
            {
                throw new Exception("You should write description of ticket");

            }
            if (string.IsNullOrEmpty(ticket.Subject))
            {
                throw new Exception("You should write subject of ticket");
            }

           // ticket.CustomerId = id.ToString();


            _ticketRepository.AddTicket(ticket);


        }
        public void UpdateStatusofTask(Ticket ticket, StatusofTask status)
        {

            ticket.status = status;

            _ticketRepository.Update(ticket);

        }
        
      

        public void AssignTask(Ticket ticket, string empid,Employee employee)
        {

            var emp = _employeeRepository.Find(empid);

           
            if (((int)ticket.Priortiy) == 0 )
            {
                throw new Exception("You should select priority before assign task to employee");
            }

            if (((int)ticket.LevelofDificulty) == 0 )
            {
                throw new Exception("You should select dificulty level before assign tasK to employee");
            }



            int count = 0;

            foreach (var item in emp.Ticket)
            {
                if ( item.LevelofDificulty == LevelofDificulty.Hard  )
                {
                 
                    count += 1;

                    if (count==3)
                    {
                        throw new Exception("You can not assign task to this employee. Already has 3 Hard Task");
                    }

                  

                }

                if (emp.WorkHours > 160)
                {
                    throw new Exception("You can not assign task to this employee. His/Her Work hours is full");


                }

                emp.Ticket.Add(ticket);
                _employeeRepository.AssignTask(emp);

            }

            ticket.EmployeeID = empid;
            _ticketRepository.Update(ticket);

        }

        public void SetPriority(Ticket ticket)
        {
            _ticketRepository.Update(ticket);
        }

        public void SetDifficulty(Ticket ticket)
        {

            _ticketRepository.Update(ticket);

        }

       

    }
}
