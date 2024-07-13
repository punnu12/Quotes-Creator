using QuotesCreator_Frontend.Models.RequestModels;
using QuotesCreator_Frontend.Models.ResponseModels;
using System.Net.Http.Json;

namespace QuotesCreator_Frontend.Services.QuoteCreatorServices
{
    public class AddQuoteService
    {
        private readonly HttpClient _httpClient;
        public AddQuoteService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            //_httpClient.BaseAddress = new Uri("https://localhost:7134/");
        }
        public async Task<string> AddQuotes(List<QuoteRequestModel> quotes)
        {
            var quotesList = quotes.Select(q => new QuoteApiResponse
            {
                Author = q.Author,
                Tags = q.Tags.Count > 0 ? string.Join(", ", q.Tags) : string.Empty,
                QuoteDesp = q.QuoteDesp
            }).ToList();
            var response = await _httpClient.PostAsJsonAsync("/api/QuoteCreator/createquote", quotesList);

            if (response.IsSuccessStatusCode)
            {
                return "Quotes created successfully";
            }

            var errorMessage = await response.Content.ReadAsStringAsync();
            return $"Failed to create quotes: {errorMessage}";
        }
    }
}
