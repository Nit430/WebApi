using System;
using Microsoft.AspNetCore.Mvc;
using WebApi.Model;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[action]")]
    //[BindProperties(SupportsGet = true)]
    public class CountryController : ControllerBase
    {
        [BindProperty]
        public Countries countries { get; set; }
        [HttpPost("")]
        public IActionResult AddCountry([FromRoute] Countries countries)
        {
            return Ok($"Name={countries.countryName}," + $"Capital={countries.countryCapital}," + $"Population={countries.countryPopulation},");
        }
        [HttpPost("")]
        public IActionResult AddCountries([FromBody] Countries countries)
        {
            return Ok($"Name={countries.countryName}," + $"Capital={countries.countryCapital}," + $"Population={countries.countryPopulation}");
        }
        [HttpPost("")]
        public IActionResult Names([FromHeader] string developername)
        {
            return Ok(developername);
        }

        /*Custom Model Binder(Example-1)*/

        [HttpGet("search")]
        public IActionResult searchCountry([ModelBinder(typeof(CustomModelBinder))] string[] countries)
        {
            return Ok(countries);
        }

        /*Custom Model Binder(Example-2)*/

        [HttpGet("{id}")]
        public IActionResult DisplayCountry([ModelBinder(Name ="Id")] CountryModel countries)
        {
            return Ok(new
            {
                IsSuccess = true,
                Message = "OK",
                LstCountries = countries
            });
        }
    }
}
