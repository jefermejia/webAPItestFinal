using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using WebApplication1.DAL.Entities;
using WebApplication1.Domain.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]//este es el nombre inicial de mu RUTA, URL o PATH
    [ApiController]
    public class CountriesController : Controller
    {
        private readonly ICountryService _countryService;

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet, ActionName("Get")]
        [Route("Getall")]
        public async Task<ActionResult<IEnumerable<Country>>> GetActionResultAsync()
        {
            var countries = await _countryService.GetCountriesAsync();
            if (countries == null || !countries.Any())
            {
                return NotFound();
            }
            return Ok(countries);
        }

        [HttpGet, ActionName("Get")]
        [Route("GetById/{id}")] //URL api/countries/get
        public async Task<ActionResult<Country>> GetCountryByIdAsync(Guid id)
        {
            var country = await _countryService.GetCountryByIdAsync(id);
            if (country == null)
            {
                return NotFound(); //NotFound = Status Code 404 
            }
            return Ok(country); //Ok = Status Code 404 
        }

        [HttpPost, ActionName("Create")]
        [Route ("Create")]
        public async Task <ActionResult<Country>> CreateCountryAsync (Country country)
        {
            try
            {
                var newCountry = await _countryService.CreateCountryAsync(country);
                if (newCountry == null)
                {
                    return NotFound();
                }
                return Ok(newCountry);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                {
                    return Conflict(string.Format("{0} ya existe", country.Name)); 
                }
                return Conflict(ex.Message);
            }
        }

        [HttpPut, ActionName("edit")]
        [Route("edit")]
        public async Task <ActionResult<Country>> UpdateCountryAsync(Country country)
        {
            try
            {
                var editedCountry = await _countryService.UpdateCountryAsync(country);
                if(editedCountry == null) return NotFound();
                return Ok(editedCountry);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                {
                    return Conflict(string.Format("{0} ya existe", country.Name));
                }
                return Conflict(ex.Message);
            }
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult<Country>> DeleteCountryAsync(Guid id)
        { 
            if (id == null) return BadRequest();

            var deletedCountry = await _countryService.DeleteCountryAsync(id);
            if (deletedCountry == null) return NotFound();
            return Ok(deletedCountry);  
        }
    }
}
