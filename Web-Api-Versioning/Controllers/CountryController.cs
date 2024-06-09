using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_Api_Versioning.Models.DTO;

namespace Web_Api_Versioning.v1.Controllers
{
    [Route("api/v{version:apiversion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class CountryController : ControllerBase
    {
        [MapToApiVersion("1.0")]
        [HttpGet]
        public IActionResult Get()
        {
            var countrylist = CountriesData.Get();
            var response=new List<CountryDtov1>();
            foreach(var country in countrylist)
            {
                response.Add(new CountryDtov1
                {
                    Id = country.Id,
                    Name = country.Name,

                });
            }
            return Ok(response);
        }

        [MapToApiVersion("2.0")]
        [HttpGet]
        public IActionResult Getv2()
        {
            var countrylist = CountriesData.Get();
            var response = new List<CountryDtov2>();
            foreach (var country in countrylist)
            {
                response.Add(new CountryDtov2
                {
                    Id = country.Id,
                    CountryName = country.Name,

                });
            }
            return Ok(response);
        }
    }
}
