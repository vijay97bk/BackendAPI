using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayRollAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
       
        IEmployeeBL employeeBL;

        public EmployeeController(IEmployeeBL employeeBL)                           //Constructor n passing an object to controller to access Business layer
        {
            this.employeeBL = employeeBL;
        }

        [HttpGet]                                                                    
        public IActionResult GetAllEmployeeRecords()                                        
        {
            try
            {                                                                                           
                List<EmployeeModel> result = employeeBL.GetAllEmployeeRecords();                    
                return this.Ok(new { Success = true, Message = "Get Successful", Data = result });
            }

            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, Message = e.Message });
            }
        }
        [HttpGet("{id}")]                                                                   
        public IActionResult GetEmployee(int id)                                        
        {
            try
            {                                                                                           
                EmployeeModel result = this.employeeBL.GetEmployee(id);                    
                return this.Ok(new { Success = true, Message = "Get Successful", Data = result });   
            }

            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, Message = e.Message });
            }
        }

        [HttpPut("{id}")]                                                                  
        public IActionResult UpdateRecord(EmployeeModel employee, int id)                                       
        {
                try
                {
                    bool successFlag = this.employeeBL.UpdateEmployee(employee);
                    if (successFlag)
                    {
                        return this.Ok(new { Success = successFlag, Message = "Contact Updated" });
                    }
                    else
                    {
                        return this.Ok(new { Success = successFlag, Message = "Contact Updation Failed" });
                    }

                }
                catch (Exception ex)
                {
                    return this.BadRequest(new { Success = false, Message = ex.Message });
                }
        }
        [HttpDelete("Delete/{id}")]                                                                
        public IActionResult DeleteRecord(int id)                                        
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool result = this.employeeBL.DeleteContact(id);                  
                    if (result != false)
                    {
                        return this.Ok(new { Success = true, Message = "Delete Employee Record Successfully" });   //(smd format)    //this.Ok returns the data in json format
                    }
                    else
                    {
                        return this.BadRequest(new { Success = false, Message = "Delete  Employee Record Unsuccessfully" });
                    }
                }

                else
                {
                    throw new Exception("Model is not valid");
                }

            }

            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, Message = e.Message });
            }

        }
       

    }
}
