using System;

namespace RepositoryLayer.Service
{
    internal class EmployeeModel
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Gender { get; set; }
        public long Salary { get; set; }
        public DateTime StartDate { get; set; }
        public string Notes { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentName1 { get; set; }
        public string DepartmentName2 { get; set; }
    }
}