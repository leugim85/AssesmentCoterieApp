using AssesmentCoterie.Domain.Models;
using DemoLayers.Domain.Infrastructure.Utilities;

namespace AssesmentCoterie.App.Services
{
    public interface IQuoteEngineService
    {
        Task<GenericResponse<QuoteDto>> AddQuote(Request request);
    }
}