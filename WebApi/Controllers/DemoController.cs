using System;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]

    /*Token Replacement concept*/

    [Route("[controller]/[action]")]
    public class DemoController : ControllerBase
    {
        /*Demo of Route Contraints*/
        [Route("{id:regex(a(b|c))}")]
        public string getString(string id)
        {
            return "Hello" + " " + id;
        }
        [Route("{id}")]
        public string getValues1(int id)
        {
            return "Hello" + id;
        }

        [Route("{id}")]
        public string getValues2(string id)
        {
            return "Hello" + id;
        }

        [Route("{id:min(10):max(55)}")]
        public string getValue(int id)
        {
            return "Hello"+" "+id;
        }
        [Route("books/{id}/author/{authId}")]
        public string getAllValue(int id,int authId)
        {
            return "Hello from Book" + " " + id + " " + "& Author" + " " + authId;
        }
    }
}
