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

        public Employee Find(string id)
        {
            return _db.Employee.Find(id);
        }


        public List<Employee> GetAll()
        {
            return _db.Employee.ToList();
        }

        public void AssignTask(Employee employee) //update
        {

            _db.Employee.Update(employee);
            _db.SaveChanges();
        }

     
    }
}
