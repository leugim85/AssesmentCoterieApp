using AssesmentCoterie.Domain.Entities;
using AutoMapper;
using CoterieApp.Domain.Models;

namespace CoterieApp.App
{
    public class MapperProfiles: Profile
    {
        public MapperProfiles()
        {
            CreateMap<Business, BusinessDto>();
            CreateMap<BusinessDto, Business>().ForMember(t => t.Id, act => act.Ignore());

            CreateMap<State, StateDto>();
            CreateMap<StateDto, State>().ForMember(t => t.Id, act => act.Ignore());
        }
    }
}
