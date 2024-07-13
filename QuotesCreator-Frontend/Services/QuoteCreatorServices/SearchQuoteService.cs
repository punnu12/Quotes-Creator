using Microsoft.AspNetCore.Http;
using QuotesCreator_Frontend.Models.RequestModels;
using QuotesCreator_Frontend.Models.ResponseModels;
using System.Net.Http;
using System.Net.Http.Json;

namespace QuotesCreator_Frontend.Services.QuoteCreatorServices
{
    public class SearchQuoteService
    {
        private readonly HttpClient _httpClient;
        public SearchQuoteService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _httpClient.BaseAddress = new Uri("https://localhost:7134/");
        }
        public async Task<List<QuoteResponseModel>> GetQuotes(QuoteRequestModel quote)
        {
            var parameters = new List<KeyValuePair<string, string?>>()
            {
                new KeyValuePair<string, string?>("authorName", quote.Author ?? string.Empty),
                new KeyValuePair<string, string?>("tag", string.Join(", ",quote.Tags) ?? string.Empty),
                new KeyValuePair<string, string?>("desp", quote.QuoteDesp ?? string.Empty),
            };
            var list = await _httpClient.GetFromJsonAsync<List<QuoteApiResponse>>($"/api/QuoteCreator/getfilterquotes{QueryString.Create(parameters).ToString()}");
            var quoteList = list.Select(q => new QuoteResponseModel
            {
                Id = q.QuoteId,
                Author = q.Author,
                Tags = q.Tags?.Split(",").ToList() ?? [],
                QuoteDesp = q.QuoteDesp
            }).ToList();
            return quoteList;
        }
    }
}
