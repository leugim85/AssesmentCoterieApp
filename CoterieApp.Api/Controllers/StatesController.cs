using CoterieApp.App.Services;
using CoterieApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoterieApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatesController : ControllerBase
    {
        private readonly IStateService stateService;

        public StatesController(IStateService stateService)
        {
            this.stateService = stateService ?? throw new ArgumentNullException(nameof(stateService));
        }

        [HttpPost]
        public async Task<IActionResult> Add(StateDto stateDto) 
        {
            var result = await stateService.AddState(stateDto);
            if (result.IsSucces) 
                return Ok();

            return BadRequest(result.Message);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStates() 
        {
            var result = await stateService.Get();
            if (result is not null)
                return Ok(result);

            return NotFound();
        }
    }
}
