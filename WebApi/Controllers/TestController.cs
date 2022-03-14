using System;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
   
    public class TestController:ControllerBase
    {
        [Route("api/test")]
        public string get()
        {
            return "Hello";
        }
        [Route("api/test2")]
        public string get1()
        {
            return "xyz";
        }
    }
}
