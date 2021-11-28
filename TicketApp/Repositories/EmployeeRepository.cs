using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketApp.Models;

namespace TicketApp.Repositories
{
    public class EmployeeRepository
    {

        private readonly TicketDbContext _db;

        public EmployeeRepository()
        {
            _db = new TicketDbContext();
        }


        //find specific employee from employee table 
        public Employee Find(string id)
        {
            return _db.Employee.Find(id);
        }

        // getting all employees
        public List<Employee> GetAll()
        {
            return _db.Employee.ToList();
        }

        //Updating employee
        public void Update(Employee employee) //update
        {

            _db.Employee.Update(employee);
            _db.SaveChanges();
        }

     
    }
}
