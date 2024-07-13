namespace QuotesCreator_Frontend.Models.RequestModels
{
    public class QuoteRequestModel
    {
        public int QuoteId { get; set; }
        public string? Author { get; set; }
        public List<string> Tags { get; set; }
        public string? QuoteDesp { get; set; }
    }
}
