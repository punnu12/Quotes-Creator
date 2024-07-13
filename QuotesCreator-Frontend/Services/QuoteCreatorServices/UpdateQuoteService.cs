using QuotesCreator_Frontend.Models.RequestModels;
using QuotesCreator_Frontend.Models.ResponseModels;
using System.Net.Http.Json;
using static MudBlazor.CategoryTypes;

namespace QuotesCreator_Frontend.Services.QuoteCreatorServices
{
    public class UpdateQuoteService
{
        private readonly HttpClient _httpClient;
        public UpdateQuoteService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }
        public async Task<string> UpdateQuote(QuoteRequestModel quoteRequest)
        {
            if (quoteRequest.QuoteId != 0 && quoteRequest != null)
            {
                var quote = new QuoteApiResponse
                {
                    QuoteId = quoteRequest.QuoteId,
                    Author = quoteRequest.Author,
                    QuoteDesp = quoteRequest.QuoteDesp,
                    Tags = string.Join(", ", quoteRequest.Tags ?? Enumerable.Empty<string>())
                };
                var response = await _httpClient.PutAsJsonAsync($"/api/QuoteCreator/updatequote/{quoteRequest.QuoteId}", quote);
                if (response.IsSuccessStatusCode)
                {
                    return "Quote Updated Successfully";
                }
                var errorMessage = await response.Content.ReadAsStringAsync();
                return $"Failed to Update quote: {errorMessage}";
            }
            return $"Failed to Update quote: Quote Id is not available";
        }
    }
}
