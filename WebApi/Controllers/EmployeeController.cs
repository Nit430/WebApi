using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using WebApi.Repository;

namespace WebApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        /*Using Old Technique for communicate from Repository class*/
        //EmployeeRepository employeeRepository;
        private readonly IEmployeeRepository _employeeREpository;
        private readonly IEmployeeRepository _employeeREpository1;

        /*With Dependency Injection*/
        public EmployeeController(IEmployeeRepository employeeRepository,IEmployeeRepository employeeRepository1)
        {
            _employeeREpository = employeeRepository;
            _employeeREpository1 = employeeRepository1;
        }

        /*Service Without Dependency Injection
        public EmployeeController()
        {
            //employeeRepository = new EmployeeRepository();
        }*/

        public IActionResult AddEmployee([FromBody]EmployeeModel employeeModel,[FromQuery]int id)
        {
            _employeeREpository.AddEmployee(employeeModel);
            var list = _employeeREpository1.getEmployeeList();
            return Ok(new
            {
                IsSuccess = true,
                Message="OK",
                LstEmployees=list
            });
        }
        [HttpGet("")]
        public string Get()
        {
            var name=_employeeREpository.getName();
            return name;
        }
        [HttpGet("{name}")]
        public string getEmployeeName([FromForm]string name)
        {
            return name;
        }
    }
}