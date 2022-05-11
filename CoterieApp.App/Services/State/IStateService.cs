using AssesmentCoterie.Domain.Entities;
using CoterieApp.Domain.Models;
using DemoLayers.Domain.Infrastructure.Utilities;

namespace CoterieApp.App.Services
{
    public interface IStateService
    {
        Task<GenericResponse<string>> AddState(StateDto stateDto);
        Task<List<State>> Get();
    }
}