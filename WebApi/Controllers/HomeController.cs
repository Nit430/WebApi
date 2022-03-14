using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using WebApi.Repository;

namespace WebApi.Controllers
{
    [ApiController]

    /*Token Replacement Feature*/

    [Route("[controller]/[action]")]
    public class HomeController:ControllerBase
    {
        List<DemoModel> demoModels = new List<DemoModel>();
        public HomeController()
        {
            demoModels.Add(new DemoModel
            {
                ID=1,
                Name="Nitesh Kumar"
            });
            demoModels.Add(new DemoModel
            {
                ID = 2,
                Name = "Nimit Kumar"
            });
            demoModels.Add(new DemoModel
            {
                ID = 3,
                Name = "Nikesh Kumar"
            });
            demoModels.Add(new DemoModel
            {
                ID = 4,
                Name = "Nimesh Kumar"
            });
            demoModels.Add(new DemoModel
            {
                ID = 5,
                Name = "Nitin Kumar"
            });

        }
        //[Route("api/get")]
        public List<DemoModel> get()
        {
            return demoModels;
        }
        //[Route("api/getDatabyId/{id}")]
        [Route("{id}")]
        public IActionResult getDatabyId(int id)
        {
            var list = demoModels.Where(x => x.ID == id).FirstOrDefault();
            if (list != null)
            {
                return Ok(list);
            }
            else
            {
                return BadRequest();
            }
        }
        public IActionResult getvalue()
        {
            return Ok("Hello");
        }
        
        [Route("{id}")]
        public ActionResult<DemoModel> getValuebyId(int id)
        {
            var list = demoModels.Where(x => x.ID == id).FirstOrDefault();
            if (list != null)
            {
                return list;
            }
            else
            {
                return NotFound();
            }
        }
        [Route("test")]
        public IActionResult getValuebyIds()
        {
            return Accepted(demoModels);
        }

        /*Resolve the Service dependency directly in the Action Method*/

        [HttpGet("")]
        public string Get([FromServices] IEmployeeRepository _employeeREpository)
        {
            var name = _employeeREpository.getName();
            return name;
        }
    }
}
