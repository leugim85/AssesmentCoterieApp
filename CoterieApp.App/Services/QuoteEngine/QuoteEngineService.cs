using AssesmentCoterie.Domain.Entities;
using AssesmentCoterie.Domain.Models;
using CoterieApp.App.Services;
using CoterieApp.Data.Context;
using CoterieApp.Domain.Models;
using DemoLayers.Domain.Infrastructure.Utilities;

namespace AssesmentCoterie.App.Services
{
    public class QuoteEngineService : IQuoteEngineService
    {
        private readonly CoterieAppContext appContext;
        private readonly IBusinessService businessService;
        private readonly IStateService stateService;

        public QuoteEngineService(CoterieAppContext appContext, IBusinessService businessService, IStateService stateService)
        {
            this.appContext = appContext ?? throw new ArgumentNullException(nameof(appContext));
            this.businessService = businessService ?? throw new ArgumentNullException(nameof(businessService));
            this.stateService = stateService ?? throw new ArgumentNullException(nameof(stateService));
        }
        public async Task<GenericResponse<QuoteDto>> AddQuote(Request request)
        {
            var quoteDto = new QuoteDto();
            var business = await GetBusiness(request.Business);
            var premiums = await GetPremiumsValue(request);
            if (!business.IsSucces || !premiums.IsSucces)
            {
                quoteDto.IsSuccesful = false;
                return new GenericResponse<QuoteDto>(false, $"{premiums.Message}");
            }

            quoteDto.Revenue = request.Revenue;
            quoteDto.Business = business.Data.Name;
            quoteDto.Premiums = premiums.Data;
            quoteDto.IsSuccesful = true;

            var quote = new Quote
            {
                Business = quoteDto.Business,
                Revenue = quoteDto.Revenue,
                IsSuccesful= quoteDto.IsSuccesful,
            };

            appContext.Quotes.Add(quote);
            await appContext.SaveChangesAsync();

            quoteDto.TransactionId = quote.TransactionId;            

            return new GenericResponse<QuoteDto>(true, quoteDto);
        }

        private async Task<GenericResponse<Business>> GetBusiness(string business)
        {
            if (business.Equals(string.Empty))
                return new GenericResponse<Business>(false, "The business field is required");

            var businessList = await businessService.Get();
            var result = businessList.FirstOrDefault(b => b.Name.Equals(business, StringComparison.InvariantCultureIgnoreCase));
            if (result is null)
                return new GenericResponse<Business>(false, "Bussines not found!");

            return new GenericResponse<Business>(true, result);
        }

        private async Task<GenericResponse<List<Premiums>>> GetPremiumsValue(Request request)
        {
            if (request.Revenue < 1)
                return new GenericResponse<List<Premiums>>(false, "The revenue value must be bigger than 0!");

            var statesData = await GetStatesData(request.States);
            var business = await GetBusiness(request.Business);
            if (!statesData.IsSucces || !business.IsSucces)
                return new GenericResponse<List<Premiums>>(false, $"{business.Message} {statesData.Message}");

            List<Premiums> premiumsList = new List<Premiums>();

            foreach (var state in statesData.Data)
            {
                Premiums premium = new Premiums();
                premium.Premium = (request.Revenue / 1000) * state.Factor * business.Data.BusinessFactor * 4;
                premium.state = state.Abbreviation;

                premiumsList.Add(premium);
            }

            return new GenericResponse<List<Premiums>>(true, premiumsList);
        }

        private async Task<GenericResponse<List<StateData>>> GetStatesData(List<string> statesNames)
        {
            if (statesNames.Count < 1)
                return new GenericResponse<List<StateData>>(false, "Must enter at least one state");

            List<StateData> statesDataList = new List<StateData>();
            var states = await stateService.Get();
            if (states is null)
                return new GenericResponse<List<StateData>>(false, "An error has occurred in the database connection");

            for (int i = 0; i < statesNames.Count; i++)
            {
                var state = states.FirstOrDefault(s => s.Name.Equals(statesNames[i], StringComparison.InvariantCultureIgnoreCase) ||
                                                  s.Abbreviation.Equals(statesNames[i], StringComparison.InvariantCultureIgnoreCase));
                if (state is null)
                    return new GenericResponse<List<StateData>>(false, $"Not found state '{statesNames[i]}' in the database");

                StateData stateData = new StateData();
                stateData.Factor = state.FactorState;
                stateData.Abbreviation = state.Abbreviation;

                statesDataList.Add(stateData);
            }
            return new GenericResponse<List<StateData>>(true, statesDataList);
        }
    }
}
