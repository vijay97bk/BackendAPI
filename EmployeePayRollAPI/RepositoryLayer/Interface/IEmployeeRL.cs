using RepositoryLayer.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IEmployeeRL
    {
        public List<EmployeeModel> GetOperationForEmployees();
        public EmployeeModel GetEmployee(int EmployeeId);
        public bool UpdateEmployee(EmployeeModel employee);
        public bool DeleteContact(int id);
    }
}
