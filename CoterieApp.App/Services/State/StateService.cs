using AssesmentCoterie.Domain.Entities;
using AutoMapper;
using CoterieApp.Data.Context;
using CoterieApp.Domain.Models;
using DemoLayers.Domain.Infrastructure.Utilities;
using Microsoft.EntityFrameworkCore;

namespace CoterieApp.App.Services
{
    public class StateService : IStateService
    {
        private readonly CoterieAppContext context;
        private readonly IMapper mapper;

        public StateService(CoterieAppContext context, IMapper mapper)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<GenericResponse<string>> AddState(StateDto stateDto)
        {
            var states = await Get();
            var exists = states.Any(s => s.Name.Equals(stateDto.Name, StringComparison.InvariantCultureIgnoreCase) || s.Abbreviation.Equals(stateDto.Abbreviation, StringComparison.InvariantCultureIgnoreCase));
            if (exists)
                return new GenericResponse<string>(false, "The abbreviation state or name state already exists");

            State state = mapper.Map<State>(stateDto);
            var result = context.States.Add(state);
            await context.SaveChangesAsync();

            if (result is not null)
                return new GenericResponse<string>();

            return new GenericResponse<string>(false, "Something goes wrong while try to connect database!");
        }

        public async Task<List<State>> Get()
        {
            var result = await context.States.ToListAsync();
            return result;
        }
    }
}
                                                        