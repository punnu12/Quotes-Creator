using System.Net.Http;

namespace QuotesCreator_Frontend.Services.QuoteCreatorServices
{
    public class DeleteQuoteService
    {
        private readonly HttpClient _httpClient;
        public DeleteQuoteService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }
        public async Task<string> DeleteQuote(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/QuoteCreator/deletequote/{id}");
            if (response.IsSuccessStatusCode)
            {
                return "Quote Deleted Successfully";
            }

            // Handle error response
            var errorMessage = await response.Content.ReadAsStringAsync();
            return $"Failed to Delete quote: {errorMessage}";
        }
    }
}
