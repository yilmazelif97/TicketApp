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


        public TicketService(TicketRepository ticketrepository,EmployeeRepository employeeRepository)
        {
            _ticketRepository = ticketrepository;
            _employeeRepository = employeeRepository;
        }

        
        //creating new ticket in DB with using repository AddTicket method
        public void CreateTicket(Ticket ticket)
        {

            if (ticket == null)
            {
                throw new Exception("You have to create ticket");
            }

         
            //controlling description or subject of ticket is empty or not 

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

        //Method is for changing status of ticket like closed, opened..
        public void UpdateStatusofTask(Ticket ticket, StatusofTask status)
        {

            ticket.status = status;

            _ticketRepository.Update(ticket);

        }

        public List<Ticket> ticketList { get; set; } = new List<Ticket>();
        public Employee emp { get; set; }


        //Method is assign task to employee. There is some validation like counting hard and up priortiy task that employee has, if workhours of employee is bigger than 160
        //hours. Using employee, ticket object and employee id for reach emloyee from ticket which one is assigned for ticket

        public void AssignTask(Ticket ticket, string empid,Employee employee)
        {

            emp = _employeeRepository.Find(empid);

           
            if (((ticket.LevelofDificulty) == default(LevelofDificulty)))
            {
                throw new Exception("You should select priority before assign task to employee");
            }

            if ((ticket.LevelofDificulty) == default (LevelofDificulty) )
            {
                throw new Exception("You should select dificulty level before assign tasK to employee");
            }



            int count = 0;
            int count2 = 0;
            ticketList = emp.Ticket;
            if (ticketList != null)
            {
                foreach (var item in ticketList)
                {
                    if (item.LevelofDificulty == LevelofDificulty.Hard)
                    {

                        count += 1;


                        if (count == 3)
                        {
                            throw new Exception("You can not assign task to this employee. Already has 3 Hard Task");
                        }

                        if (item.OpenDate > DateTime.Now.Date)
                        {
                            throw new Exception("You can not assign task to this employee. Already has 3 Hard Task in ONE month");
                        }



                    }

                    if (item.Priortiy == Priortiy.Four || item.Priortiy == Priortiy.Five)
                    {
                        count2 += 1;

                        if (item.OpenDate > DateTime.Now.Date)
                        {
                            throw new Exception("You can not assign task to this employee. Already has 3 Hard Task in ONE month");
                        }

                        if (count2 == 5)
                        {
                            throw new Exception("You can not aissgn task to this employee. Already has 4 priority rank 4-5 task");
                        }
                    }

                    if (emp.WorkHours > 160 || item.OpenDate > DateTime.Now.Date)
                    {

                        throw new Exception("You can not assign task to this employee. His/Her Work hours is full");


                    }

                    ticketList.Add(ticket);
                    emp.Ticket = ticketList;
                    _employeeRepository.Update(emp);

                }
                ticketList.Add(ticket);
                emp.Ticket = ticketList;
                _employeeRepository.Update(emp);
            }
            

           // ticket.EmployeeID = empid;
            _ticketRepository.Update(ticket);

        }

        //Updating pritority like 5,4..
        public void SetPriority(Ticket ticket, Priortiy prio)
        {
            ticket.Priortiy = prio;
            _ticketRepository.Update(ticket);
           
        }

        //Updating difficulty of task like hard, easy..

        public void SetDifficulty(Ticket ticket, LevelofDificulty dif)
        {
            ticket.LevelofDificulty = dif;
            _ticketRepository.Update(ticket);

        }

        //Updating work hours of employee based on priority of task

        int workhour;
        public void SetWorkHours(Employee employee, Ticket ticket) 
        { 


            if ((int)ticket.Priortiy ==5 )
            {
                workhour = 8 * 5;
            }

            if ((int)ticket.Priortiy == 4)
            {
                workhour = 8 * 4;
            }
            if ((int)ticket.Priortiy == 3)
            {
                workhour = 8 * 3;
            }
            if ((int)ticket.Priortiy == 2)
            {
                workhour = 8 * 2;
            }
            if ((int)ticket.Priortiy == 1)
            {
                workhour = 8 * 1;
            }

            employee.WorkHours = workhour;

            _employeeRepository.Update(employee);


        }
        //Assign employee to task. it is updating employee id of task
        public void UpdateTicketEmployeeid(Ticket ticket, string id)
        {
            ticket.EmployeeID = id;
            _ticketRepository.Update(ticket);

        }

        //it updates sstatus of task as a closed
        public void CloseTask(Ticket ticket)
        {
            ticket.ClosedDate = DateTime.Now.Date;

            ticket.status = StatusofTask.Closed;


           

            _ticketRepository.Update(ticket);



        }

        //it updates sstatus of task as a Review
        public void ReviewTask(Ticket ticket)
        {
            ticket.status = StatusofTask.Review;
            ticket.ReviewDate = DateTime.Now.Date;

            _ticketRepository.Update(ticket);

        }

        //it updates sstatus of task as a Complete
        public void CompleteTask(Ticket ticket)
        {
            ticket.status = StatusofTask.Completed;
            ticket.CompleteDate = DateTime.Now.Date;

            _ticketRepository.Update(ticket);

        }



    }
}
