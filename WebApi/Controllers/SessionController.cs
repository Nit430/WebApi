using System;
using Microsoft.AspNetCore.Mvc;
using WebApi.Model;

namespace WebApi.Controllers
{
    [Route("[controller]/[action]")]
    public class SessionController:ControllerBase
    {
        [HttpGet("")]
        public string name([FromHeader] string name)
        {
            return name;
        }
        [HttpPost("")]
        public string getEmployeeName([FromBody] EmployeeModel employeeModel)
        {
            return employeeModel.empName;
        }
        [HttpPost("{Id}")]
        public string getEmpName([FromRoute] string Id)
        {
            return Id;
        }
    }
}
