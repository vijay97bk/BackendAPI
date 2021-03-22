using BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;

namespace BusinessLayer.Services
{
    public class EmployeeBL : IEmployeeBL
    {
        IEmployeeRL employeeRL;
        public EmployeeBL(IEmployeeRL employeeRL)
        {
            this.employeeRL = employeeRL;
        }

        /// <summary>
        /// Gets all employee records.
        /// </summary>
        /// <returns></returns>
        public List<EmployeeModel> GetAllEmployeeRecords()
        {
            try
            {
                return employeeRL.GetOperationForEmployees();                
            }

            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Gets the employee.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public EmployeeModel GetEmployee(int id)
        {
            try
            {

                return employeeRL.GetEmployee(id);                 
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Updates the employee. PUT operation
        /// </summary>
        /// <param name="employeeDetailModel">The employee detail model.</param>
        /// <returns></returns>
        public bool UpdateEmployee(EmployeeModel employee)
        {
            try
            {
                    return this.employeeRL.UpdateEmployee(employee);
            }

            catch (Exception e)
            {
                throw e;
            }
        }
        public bool DeleteContact(int id)
        {
            try
            {

                return this.employeeRL.DeleteContact(id);                 //throw exceptions
            }

            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
