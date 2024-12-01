using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using WebApplication1.DAL.Entities;
using WebApplication1.Domain.Interfaces;
using WebApplication1.Domain.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]//este es el nombre inicial de mu RUTA, URL o PATH
    [ApiController]
    public class StatesController : Controller
    {
        private readonly IStateService _stateService;

        public StatesController(IStateService stateService)
        {
            _stateService = stateService;
        }

        [HttpGet, ActionName("Get")]
        [Route("Getall")]
        public async Task<ActionResult<IEnumerable<State>>> GetActionResultAsync()
        {
            var states = await _stateService.GetStatesAsync();
            if (states == null || !states.Any())
            {
                return NotFound();
            }
            return Ok(states);
        }

        // get para traer estados por pais
        #region get estados por pais
        [HttpGet, ActionName("GetStatesByCountryId")]
        [Route("GetByCountryId/{id}")] //URL api/states by country/get
        public async Task<ActionResult<State>> GetStatesByCountryIdAsync(Guid id) // metodo nuevo estara bien ??
        {
            var states = await _stateService.GetStatesByCountryIdAsync(id);
            if (states == null)
            {
                return NotFound(); //NotFound = Status Code 404 
            }
            return Ok(states); //Ok = Status Code 404 
        }
        #endregion estados por pais


        [HttpGet, ActionName("Get")]
        [Route("GetById/{id}")] //URL api/countries/get
        public async Task<ActionResult<State>> GetStateByIdAsync(Guid id)
        {
            var state = await _stateService.GetStateByIdAsync(id);
            if (state == null)
            {
                return NotFound(); //NotFound = Status Code 404 
            }
            return Ok(state); //Ok = Status Code 404 
        }

        [HttpPost, ActionName("Create")]
        [Route ("Create")]
        public async Task <ActionResult<State>> CreateStateAsync(State state)
        {
            try
            {
                var newState = await _stateService.CreateStateAsync(state);
                if (newState == null)
                {
                    return NotFound();
                }
                return Ok(newState);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                {
                    return Conflict(string.Format("{0} ya existe", state.Name)); 
                }
                return Conflict(ex.Message);
            }
        }

        [HttpPut, ActionName("edit")]
        [Route("edit")]
        public async Task <ActionResult<State>> UpdateStateAsync(State state)
        {
            try
            {
                var editedState = await _stateService.UpdateStateAsync(state);
                if(editedState == null) return NotFound();
                return Ok(editedState);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                {
                    return Conflict(string.Format("{0} ya existe", state.Name));
                }
                return Conflict(ex.Message);
            }
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult<State>> DeleteStateAsync(Guid id)
        { 
            if (id == null) return BadRequest();

            var deletedState = await _stateService.DeleteStateAsync(id);
            if (deletedState == null) return NotFound();
            return Ok(deletedState);  
        }
    }
}
