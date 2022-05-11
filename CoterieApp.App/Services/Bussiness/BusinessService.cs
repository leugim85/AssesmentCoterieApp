using CoterieApp.Data.Context;
using CoterieApp.Domain.Models;
using AssesmentCoterie.Domain.Entities;
using DemoLayers.Domain.Infrastructure.Utilities;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace CoterieApp.App.Services
{
    public class BusinessService : IBusinessService
    {
        private readonly CoterieAppContext appContext;
        private readonly IMapper mapper;

        public BusinessService(CoterieAppContext appContext, IMapper mapper)
        {
            this.appContext = appContext ?? throw new ArgumentNullException(nameof(appContext));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<GenericResponse<string>> Add(BusinessDto businessDto)
        {
            var businesList = await Get();
            var exists = businesList.Any(s => s.Name.Equals(businessDto.Name, StringComparison.InvariantCultureIgnoreCase));
            if (exists)
                return new GenericResponse<string>(false, "The business already exists");

            var business = mapper.Map<Business>(businessDto);
            var result = appContext.Businesses.Add(business);
            await appContext.SaveChangesAsync();

            if (result is null)
                return new GenericResponse<string>(false, "Something Goes Wrong!");

            return new GenericResponse<string>();
        }

        public async Task<List<Business>> Get()
        {
            var businessList = await appContext.Businesses.ToListAsync();
            return businessList;
        }
    }
}
