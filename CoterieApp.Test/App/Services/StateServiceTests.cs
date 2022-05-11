using AssesmentCoterie.Domain.Entities;
using AutoMapper;
using CoterieApp.App;
using CoterieApp.App.Services;
using CoterieApp.Data.Context;
using CoterieApp.Domain.Models;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CoterieApp.Test.App.Services
{
    public class StateServiceTests
    {
        [Fact]
        public void When_Context_IsNull_ThrowException() 
        {
            Assert.Throws<ArgumentNullException>(() => new StateService(null, GetMapper()));
        }

        [Fact]
        public async void When_Add_NewState_Already_Exists_IsNull_Return_Error_Message()
        {
            var stateDto = new StateDto() { Abbreviation = "FL", FactorState = 1, Name = "Florida" };
            var mockStateService = await GetDatabaseContext();
            var sut = new StateService(mockStateService, GetMapper());
            var state = await sut.AddState(stateDto);
            state.Message.Should().Contain("The abbreviation state or name state already exists");
        }

        [Fact]
        public async void When_Add_NewState_All_Params_Right_IsNull_Return_IsSucces_True()
        {
            var stateDto = new StateDto() { Abbreviation = "TX", FactorState = 1, Name = "Texas" };
            var mockStateService = await GetDatabaseContext();
            var sut = new StateService(mockStateService, GetMapper());
            var state = await sut.AddState(stateDto);
            state.IsSucces.Should().BeTrue();
        }


        private async Task<CoterieAppContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<CoterieAppContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new CoterieAppContext(options);
            databaseContext.Database.EnsureCreated();

            databaseContext.States.Add(new State()
            {
                Id = Guid.NewGuid(),
                Name = "Florida",
                Abbreviation = "FL",
                FactorState = 1.2
            });
            await databaseContext.SaveChangesAsync();

            databaseContext.Businesses.Add(new Business()
            {
                Id = Guid.NewGuid(),
                Name = "Plumber",
                BusinessFactor = 0.5
            });
            await databaseContext.SaveChangesAsync();
            return databaseContext;
        }

        private IMapper GetMapper()
        {
            var config = new MapperConfiguration(opts =>
            {
                opts.AddProfile<MapperProfiles>();
            });

            return config.CreateMapper();
        }
    }
}
