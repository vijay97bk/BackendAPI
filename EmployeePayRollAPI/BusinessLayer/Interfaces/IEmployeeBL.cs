using RepositoryLayer.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IEmployeeBL
    {
        public List<EmployeeModel> GetAllEmployeeRecords();
        public EmployeeModel GetEmployee(int employeeId);
        public bool UpdateEmployee(EmployeeModel employee);
        public bool DeleteContact(int id);
    }
}
