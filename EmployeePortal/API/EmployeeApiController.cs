using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using ServicesLibrary;

namespace EmployeePortal.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeApiController : ControllerBase
    {
        protected readonly EmployeeService EmployeeService;
        public EmployeeApiController(EmployeeService employeeService)
        {
            this.EmployeeService = employeeService;
        }
               
        [HttpGet]
        [Route("GetEmployees")]
        public List<Employee> GetEmployees()
        {
            return this.EmployeeService.GetEmployees();
        }

        [HttpGet]
        public Employee GetEmployee(int id)
        {
            return this.EmployeeService.GetEmployee(id) ;
        }

     
    }
}
