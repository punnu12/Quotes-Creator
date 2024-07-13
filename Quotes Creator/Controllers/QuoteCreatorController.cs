using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuotesCreator.AL.Services.Abstraction;
using QuotesCreator.DL;

namespace Quotes_Creator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]

    public class QuoteCreatorController : ControllerBase
    {
        private IAddQuoteCreatorService _addQuote;
        private IUpdateQuoteCreatorService _updateQuote;
        private IDeleteQuoteCreatorService _deleteQuote;
        private IGetQuoteCreatorService _getQuote;
        private ISearchQuoteCreatorService _searchQuote;
        public QuoteCreatorController(IAddQuoteCreatorService addQuote, IUpdateQuoteCreatorService updateQuote, IDeleteQuoteCreatorService deleteQuote, 
            IGetQuoteCreatorService getQuote, ISearchQuoteCreatorService searchQuote) { 
            _addQuote = addQuote;
            _updateQuote = updateQuote;
            _deleteQuote = deleteQuote;
            _getQuote = getQuote;
            _searchQuote = searchQuote;
        }

        [HttpGet("getfilterquotes")]
        public async Task<IActionResult> GetFilteredQuotes([FromQuery]QuoteFilter filterData)
        {
            var filteredData = await _searchQuote.GetAllFilteredQuoteList(filterData);
            return Ok(filteredData);
        }
        [HttpGet("getquotebyid/{quoteId}")]
        public async Task<IActionResult> GetQuoteById(int quoteId)
        { 
            var quote = await _getQuote.GetQuote(quoteId);
            return Ok(quote);
        }
        [HttpPost("createquote")]
        public async Task<IActionResult> CreateQuote([FromBody]List<Quote> quote)
        {
            var result = await _addQuote.Create(quote);
            if (result)
            {
                return Ok("Quotes Created Successfully");
            }
            return BadRequest("Failed To Create Quotes");
        }
        [HttpPut("updatequote/{id}")]
        public async Task<IActionResult> UpdateQuote([FromBody] Quote quote)
        {
            var result = await _updateQuote.Update(quote);
            if (result)
            {
                return Ok("Quote updated successfully");
            }
            return BadRequest("Failed to update quote");
        }

        [HttpDelete("deletequote/{id}")]
        public async Task<IActionResult> DeleteQuote(int id)
        {
            var result = await _deleteQuote.Delete(id);
            if (result)
            {
                return Ok("Quote deleted successfully");
            }
            return NotFound($"Quote with ID: {id} not found, deletion failed");
        }
    }
}
