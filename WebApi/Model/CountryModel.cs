using System;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Model
{
    [ModelBinder(typeof(CustomCountryModelBinder))]
    public class CountryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }
        public int Area { get; set; }
    }
}
