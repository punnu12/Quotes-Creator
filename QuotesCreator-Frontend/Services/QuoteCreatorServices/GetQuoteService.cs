using QuotesCreator_Frontend.Models.RequestModels;
using QuotesCreator_Frontend.Models.ResponseModels;
using System.Net.Http;
using System.Net.Http.Json;

namespace QuotesCreator_Frontend.Services.QuoteCreatorServices
{
    public class GetQuoteService
    {
        private readonly HttpClient _httpClient;
        public GetQuoteService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }
        public async Task<QuoteRequestModel> GetQuoteById(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<QuoteApiResponse>($"/api/QuoteCreator/getquotebyid/{id}");
            var quote = new QuoteRequestModel { QuoteId = response.QuoteId, Author = response.Author, QuoteDesp = response.QuoteDesp, Tags = response.Tags?.Split(",").ToList() };
            return quote;
        }
    }
}
