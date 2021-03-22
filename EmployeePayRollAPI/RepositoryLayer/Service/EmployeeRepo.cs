using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;


namespace RepositoryLayer.Service
{
    public class EmployeeRepo : IEmployeeRL
    {

        public static string ConnectionString = @"Data Source=DESKTOP-ERQSHRG;Initial Catalog=Employee_Payroll_Backend;Integrated Security=True";
        SqlConnection connection = new SqlConnection(ConnectionString);
        public List<EmployeeModel> emp;
        public EmployeeModel employee = new EmployeeModel();

        /// <summary>
        /// Gets the operation for employees.
        /// </summary>
        /// <returns></returns>
        public List<EmployeeModel> GetOperationForEmployees()
        {
            try
            {
                using (this.connection)
                {
                    string StoredProcedure = "Er_GetAllEmployeeDetails";
                    SqlCommand cmd = new SqlCommand(StoredProcedure, this.connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                    this.connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    emp = new List<EmployeeModel>();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            emp.Add(new EmployeeModel
                            {
                                EmployeeID = dr.GetInt32(0),
                                EmployeeName = dr.GetString(1),
                                Gender = dr.GetString(2),
                                Salary = dr.GetInt64(3),
                                StartDate = dr.GetDateTime(4),
                                Notes = dr.GetString(5),
                                Picture = dr.GetString(6),
                                DepartmentName = dr.GetString(7),
                                DepartmentName2 = dr.GetString(8),
                                DepartmentName3 = dr.GetString(9)
                            }); ;
                        }
                    }

                    this.connection.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return emp;
        }
        /// <summary>
        /// Get one employee
        /// </summary>
        /// <param name="EmployeeId"></param>
        /// <returns></returns>
        public EmployeeModel GetEmployee(int id)
        {
            try
            {
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand("Er_GetOneEmployee", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id ", id);
                    connection.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();

                    //check if there r records
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            employee.EmployeeID = sqlDataReader.GetInt32(0);
                            employee.EmployeeName = sqlDataReader.GetString(1);
                            employee.Gender = sqlDataReader.GetString(2);
                            employee.Salary = sqlDataReader.GetInt64(3);
                            employee.StartDate = sqlDataReader.GetDateTime(4);
                            employee.Notes = sqlDataReader.GetString(5);
                            employee.Picture = sqlDataReader.GetString(6);
                            employee.DepartmentName = sqlDataReader.GetString(7);
                            employee.DepartmentName2 = sqlDataReader.GetString(8);
                            employee.DepartmentName3 = sqlDataReader.GetString(9);
                        }
                    }
                    sqlDataReader.Close();
                    connection.Close();
                    return employee;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        /// <summary>
        /// Update employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public bool UpdateEmployee(EmployeeModel employee)
        {
            using (connection)
            {
                connection.Open();
                SqlTransaction transaction;
                transaction = connection.BeginTransaction("Update Employee Transaction");
                try
                {
                    
                    SqlCommand sqlCommand = new SqlCommand("Er_UpdateEmployeeRecord", connection, transaction);
                    
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    
                    sqlCommand.Parameters.AddWithValue("@employeeID", employee.EmployeeID);
                    sqlCommand.Parameters.AddWithValue("@startDate", employee.StartDate);
                    sqlCommand.Parameters.AddWithValue("@employeeName", employee.EmployeeName);
                    sqlCommand.Parameters.AddWithValue("@gender", employee.Gender);
                    sqlCommand.Parameters.AddWithValue("@salary", employee.Salary);
                    sqlCommand.Parameters.AddWithValue("@pic", employee.Picture);
                    sqlCommand.Parameters.AddWithValue("@departmentName", employee.DepartmentName);
                    sqlCommand.Parameters.AddWithValue("@departmentName2", employee.DepartmentName2);
                    sqlCommand.Parameters.AddWithValue("@departmentName3", employee.DepartmentName3);
                    sqlCommand.ExecuteNonQuery();
                    transaction.Commit();
                    connection.Close();
                    return true;
                }

                catch (Exception)
                {
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                    return false;
                }
            }
        }
        public bool DeleteContact(int id)
        {
            try
            {
                using (connection)
                {

                    SqlCommand cmd = new SqlCommand("DeleteContact", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id ", id);
                    connection.Open();

                    SqlDataReader sqlDataReader = cmd.ExecuteReader();

                    if (sqlDataReader.HasRows == false)
                    {
                        while (sqlDataReader.Read())
                        {
                            employee.EmployeeID = sqlDataReader.GetInt32(0);
                            employee.EmployeeName = sqlDataReader.GetString(1);
                            employee.Gender = sqlDataReader.GetString(2);
                            employee.Salary = sqlDataReader.GetInt32(3);
                            employee.StartDate = sqlDataReader.GetDateTime(4);
                            employee.Notes = sqlDataReader.GetString(5);
                            employee.Picture = sqlDataReader.GetString(6);
                            employee.DepartmentName = sqlDataReader.GetString(7);
                            employee.DepartmentName2 = sqlDataReader.GetString(8);
                            employee.DepartmentName3 = sqlDataReader.GetString(9);
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //public EmployeeModel PUTOperation(EmployeeModel employee)
        //{
        //    emp.Add(employee){

        //    }
        //}
    }
}

      


