using AssesmentCoterie.Domain.Entities;
using CoterieApp.Domain.Models;
using DemoLayers.Domain.Infrastructure.Utilities;

namespace CoterieApp.App.Services
{
    public interface IBusinessService
    {
        Task<GenericResponse<string>> Add(BusinessDto businessDto);
        Task<List<Business>> Get();
    }
}