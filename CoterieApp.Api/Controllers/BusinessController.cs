using CoterieApp.App.Services;
using CoterieApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoterieApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessController : ControllerBase
    {
        private readonly IBusinessService businessService;

        public BusinessController(IBusinessService businessService)
        {
            this.businessService = businessService ?? throw new ArgumentNullException(nameof(businessService));
        }

        [HttpPost]
        public async Task<IActionResult> Add(BusinessDto businessDto)
        {
            var result = await businessService.Add(businessDto);
            if (result.IsSucces)
                return Ok();

            return BadRequest(result.Message);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBusiness()
        {
            var result = await businessService.Get();
            if (result is not null)
                return Ok(result);

            return NotFound();
        }
    }
}
