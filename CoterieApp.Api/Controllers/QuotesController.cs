using AssesmentCoterie.App.Services;
using AssesmentCoterie.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoterieApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private readonly IQuoteEngineService service;

        public QuotesController(IQuoteEngineService service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpPost]
        public async Task<IActionResult> AddQuote(Request request) 
        {
            var result = await service.AddQuote(request);
            if (result.IsSucces)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }
    }
}
