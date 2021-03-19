using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;


namespace RepositoryLayer.Service
{
    class EmployeeRepo : CURDOperations
    {
       
         public static string ConnectionString = @"Data Source=DESKTOP-ERQSHRG;Initial Catalog=Employee_Payroll_Backend;Integrated Security=True";
            SqlConnection connection = new SqlConnection(ConnectionString);

        public void GetOperationFoEmployees()
        {
            EmployeeModel employee = new EmployeeModel();
            using (connection)
            {
                string query = @"SELECT * 
                                FROM employee_payroll;";
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        employee.EmployeeID = dr.GetInt32(0);
                        employee.EmployeeName = dr.GetString(1);
                        employee.Gender= dr.GetString(2);
                        employee.Salary = Convert.ToChar(dr.GetString(3));
                        employee.StartDate = dr.GetDateTime(4);
                        employee.Notes = dr.GetString(5);
                        employee.DepartmentName = dr.GetString(6);
                        employee.DepartmentName1 = dr.GetString(7);
                        employee.DepartmentName2 = dr.GetString(5);
                         
                        Console.WriteLine(employee.EmployeeID + "," + employee.EmployeeName + "," + employee.Gender+",");
                    }
                }
                this.connection.Close();
            }
        }
    }
}

