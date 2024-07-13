namespace QuotesCreator_Frontend.Models.ResponseModels
{
    public class QuoteResponseModel
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public List<string> Tags { get; set; }
        public string QuoteDesp { get; set; }
    }
}
