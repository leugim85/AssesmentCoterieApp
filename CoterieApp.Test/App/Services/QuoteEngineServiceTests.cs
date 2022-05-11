using AssesmentCoterie.App.Services;
using AssesmentCoterie.Domain.Entities;
using AssesmentCoterie.Domain.Models;
using AutoMapper;
using CoterieApp.App.Services;
using CoterieApp.Data.Context;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace CoterieApp.Test.App.Services
{
    public class QuoteEngineServiceTests
    {
        [Fact]
        public void When_Context_IsNull_ThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => new QuoteEngineService(null, GetBusinessServiceMock(), GetStateServiceMock()));
        }

        [Fact]
        public async void When_States_IsNull_Return_GenericResponse_IsSuccess_False()
        {
            var states = new List<string>();
            states.Add("TX");
            states.Add("FLorida");
            var mockStateService = GetStateServiceMock(false);
            var mockBusinessService = GetBusinessServiceMock();
            var mockContext = await GetDatabaseContext();

            var sut = new QuoteEngineService(mockContext, mockBusinessService, mockStateService);
            var quote = await sut.AddQuote(new Request { Business = "Plumber", Revenue = 60000, States = states });
            quote.IsSucces.Should().BeFalse();
        }

        [Fact]
        public async void When_All_Params_Ok_Return_GenericResponse_IsSuccess_True()
        {
            var states = new List<string>();
            states.Add("TX");
            states.Add("FLorida");
            var mockStateService = GetStateServiceMock();
            var mockBusinessService = GetBusinessServiceMock();
            var mockContext = await GetDatabaseContext();

            var sut = new QuoteEngineService(mockContext, mockBusinessService, mockStateService);
            var quote = await sut.AddQuote(new Request { Business = "Plumber", Revenue = 60000, States = states });
            quote.IsSucces.Should().BeTrue();
        }

        [Fact]
        public async void When_Request_Has_No_Register_state_Return_GenericResponse_Message()
        {
            var states = new List<string>();
            states.Add("NY");
            states.Add("FLorida");
            var mockStateService = GetStateServiceMock();
            var mockBusinessService = GetBusinessServiceMock();
            var mockContext = await GetDatabaseContext();

            var sut = new QuoteEngineService(mockContext, mockBusinessService, mockStateService);
            var quote = await sut.AddQuote(new Request { Business = "Plumber", Revenue = 60000, States = states });
            quote.Message.Should().Contain("Not found state 'NY' in the database");
        }

        [Fact]
        public async void When_Request_Has_Business_String_Empty_Return_GenericResponse_Message()
        {
            var states = new List<string>();
            states.Add("NY");
            states.Add("FLorida");
            var mockStateService = GetStateServiceMock();
            var mockBusinessService = GetBusinessServiceMock();
            var mockContext = await GetDatabaseContext();

            var sut = new QuoteEngineService(mockContext, mockBusinessService, mockStateService);
            var quote = await sut.AddQuote(new Request { Business = "", Revenue = 60000, States = states });
            quote.Message.Should().Contain("The business field is required");
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

        private IStateService GetStateServiceMock(bool returnData = true)
        {
            var mockStateService = new Mock<IStateService>();

            if (returnData)
            {
                mockStateService
                       .Setup(c => c.Get())
                       .ReturnsAsync(new List<State>
                       {
                            new State()   
                            {
                            Id = Guid.NewGuid(),
                            Name = "Florida",
                            Abbreviation = "FL",
                            FactorState = 1.2
                            },
                            new State()
                            {
                            Id = Guid.NewGuid(),
                            Name = "Texas",
                            Abbreviation = "TX",
                            FactorState = 1.2
                            }
                       });
            }
            else
            {
                mockStateService
                   .Setup(c => c.Get())
                    .ReturnsAsync(new List<State>());
            }

            return mockStateService.Object;
        }

        private IBusinessService GetBusinessServiceMock(bool returnData = true)
        {
            var mockbusinessService = new Mock<IBusinessService>();

            if (returnData)
            {
                mockbusinessService
                       .Setup(c => c.Get())
                       .ReturnsAsync(new List<Business>
                       {
                            new Business()
                            {
                                Id = Guid.NewGuid(),
                                Name = "Plumber",
                                BusinessFactor = 0.5
                            }
                       });
            }
            else
            {
                mockbusinessService
                   .Setup(c => c.Get())
                    .ReturnsAsync(new List<Business>());
            }
            return mockbusinessService.Object;
        }
    }
}
